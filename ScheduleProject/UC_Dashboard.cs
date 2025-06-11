using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace ScheduleProject
{
    public partial class UC_Dashboard : UserControl
    {
        private Color[] schedulePalette = new Color[] {
            ColorTranslator.FromHtml("#A2C8EC"),
            ColorTranslator.FromHtml("#F9C19F"),
            ColorTranslator.FromHtml("#C9E6A7"),
            ColorTranslator.FromHtml("#E6B0E4"),
            ColorTranslator.FromHtml("#FADF8A")
        };

        private DoubleBufferedTableLayoutPanel scheduleTable;
        private Panel[] scheduleCells;
        private Label loadingLabel;
        private bool isGridInitialized;
        private List<ScheduleEntry> currentEntries;
        private string[] timeSlots = { "08:00 - 09:00", "09:00 - 10:00", "10:00 - 11:00", "11:00 - 12:00", "1:00 - 2:00", "2:00 - 3:00", "3:00 - 4:00", "4:00 - 5:00" };
        private string[] dayNames = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday" };
        private System.Timers.Timer debounceTimer;

        public UC_Dashboard()
        {
            InitializeComponent();
            scheduleTable = new DoubleBufferedTableLayoutPanel();

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            currentEntries = new List<ScheduleEntry>();
            debounceTimer = new System.Timers.Timer(100) { AutoReset = false };
            debounceTimer.Elapsed += async (s, e) => await UpdateScheduleGridAsync();

            cmbClass.Items.AddRange(new object[] { "All", "GFP (C)", "GFP (B)", "GFP (A)" });
            cmbLecturer.Items.AddRange(new object[] { "Ms. Hawa Almujaini", "Dr. Ahmed Khalid", "Prof. Sara Ismail" });
            cmbRoom.Items.AddRange(new object[] { "All", "Room 101", "Room 102", "Room 103", "Lab 201", "Lab 202" });

            cmbClass.SelectedIndex = 0;
            cmbLecturer.SelectedIndex = 0;
            cmbRoom.SelectedIndex = 0;
            isGridInitialized = false;

            cmbClass.SelectedIndexChanged += (s, e) => DebounceUpdate();
            cmbLecturer.SelectedIndexChanged += (s, e) => DebounceUpdate();
            cmbRoom.SelectedIndexChanged += (s, e) => DebounceUpdate();
        }

        private void DebounceUpdate()
        {
            debounceTimer.Stop();
            debounceTimer.Start();
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            if (!isGridInitialized)
            {
                CreateLoadingLabel();
                CreateScheduleGrid();
                LoadSampleData();
                isGridInitialized = true;
                UpdateScheduleGrid();
            }
        }

        private void CreateLoadingLabel()
        {
            loadingLabel = new Label
            {
                Text = "Loading Schedule...",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(200, Color.WhiteSmoke),
                Visible = true
            };
            scheduleGridPanel.Controls.Add(loadingLabel);
            loadingLabel.BringToFront();
        }

        private void CreateScheduleGrid()
        {
            scheduleGridPanel.Controls.Clear();
            scheduleGridPanel.SuspendLayout();

            scheduleTable = new DoubleBufferedTableLayoutPanel
            {
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                RowCount = timeSlots.Length + 1,
                ColumnCount = 6,
                AutoSize = false,
                BackColor = Color.White
            };

            for (int i = 0; i < 6; i++)
            {
                scheduleTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 6));
            }

            scheduleTable.RowStyles.Clear();
            scheduleTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            for (int i = 0; i < timeSlots.Length; i++)
            {
                scheduleTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / timeSlots.Length));
            }

            scheduleGridPanel.Controls.Add(scheduleTable);
            scheduleGridPanel.Controls.Add(loadingLabel);

            string[] headers = { "Time", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday" };
            for (int i = 0; i < headers.Length; i++)
            {
                scheduleTable.Controls.Add(new Label
                {
                    Text = headers[i],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.LightGray,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                }, i, 0);
            }

            for (int row = 0; row < timeSlots.Length; row++)
            {
                scheduleTable.Controls.Add(new Label
                {
                    Text = timeSlots[row],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.WhiteSmoke,
                    Font = new Font("Segoe UI", 9)
                }, 0, row + 1);
            }

            scheduleCells = new Panel[timeSlots.Length * 5];
            int index = 0;
            for (int row = 1; row <= timeSlots.Length; row++)
            {
                for (int col = 1; col < 6; col++)
                {
                    Panel cell = new Panel
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    cell.Click += Cell_Click;
                    scheduleTable.Controls.Add(cell, col, row);
                    scheduleCells[index++] = cell;
                }
            }

            scheduleGridPanel.ResumeLayout(false);
        }

        private void UpdateScheduleGrid()
        {
            if (currentEntries == null || !currentEntries.Any() || scheduleTable == null || cmbLecturer.SelectedItem == null)
            {
                loadingLabel.Text = "No Data Available or No Lecturer Selected";
                loadingLabel.Visible = true;
                return;
            }

            loadingLabel.Visible = true;
            scheduleGridPanel.SuspendLayout();

            string selectedLecturer = cmbLecturer.SelectedItem.ToString();
            string selectedClass = cmbClass.SelectedItem?.ToString() ?? "All";
            string selectedRoom = cmbRoom.SelectedItem?.ToString() ?? "All";

            var cellUpdates = new List<(int Index, ScheduleEntry Entry)>();
            foreach (ScheduleEntry entry in currentEntries)
            {
                bool matchLecturer = entry.Lecturer == selectedLecturer;
                bool matchClass = selectedClass == "All" || entry.ClassName == selectedClass;
                bool matchRoom = selectedRoom == "All" || entry.Room == selectedRoom;

                if (matchLecturer && matchClass && matchRoom)
                {
                    int dayIndex = Array.IndexOf(dayNames, entry.Day);
                    int timeSlotIndex = Array.IndexOf(timeSlots, entry.TimeSlot);
                    if (dayIndex >= 0 && timeSlotIndex >= 0)
                    {
                        int index = timeSlotIndex * 5 + dayIndex;
                        if (index >= 0 && index < scheduleCells.Length)
                        {
                            cellUpdates.Add((index, entry));
                        }
                    }
                }
            }

            foreach (Panel cell in scheduleCells)
            {
                cell.Controls.Clear();
                cell.Tag = null;
                cell.BackColor = Color.White;
            }

            foreach (var update in cellUpdates)
            {
                AddScheduleEntry(scheduleCells[update.Index], update.Entry);
            }

            loadingLabel.Visible = false;
            scheduleGridPanel.ResumeLayout(true);
            scheduleGridPanel.Visible = true;
            scheduleGridPanel.Refresh();
        }

        private async Task UpdateScheduleGridAsync()
        {
            await Task.Run(() => Invoke((Action)UpdateScheduleGrid));
        }

        private void AddScheduleEntry(Panel cell, ScheduleEntry entry)
        {
            cell.BackColor = schedulePalette[entry.ColorIndex % schedulePalette.Length];

            DoubleBufferedTableLayoutPanel layout = new DoubleBufferedTableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3, // Reduced to 3 rows: Subject, ClassName, Room
                ColumnCount = 1,
                AutoSize = false
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 40f)); // Subject
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 30f)); // ClassName
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 30f)); // Room

            layout.Controls.Add(new Label { Text = entry.Subject, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 8) }, 0, 0);
            layout.Controls.Add(new Label { Text = entry.ClassName, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 8) }, 0, 1);
            layout.Controls.Add(new Label { Text = entry.Room, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 8) }, 0, 2);

            cell.Controls.Add(layout);
            cell.Tag = entry;
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            if (sender is Panel cell && cell.Tag is ScheduleEntry entry)
            {
                string details = $"Subject: {entry.Subject}\nClass: {entry.ClassName}\nLecturer: {entry.Lecturer}\nRoom: {entry.Room}\nDay: {entry.Day}\nTime: {entry.TimeSlot}";
                MessageBox.Show(details, "Schedule Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadSampleData()
        {
            currentEntries.Clear();
            currentEntries.AddRange(new[]
            {
                new ScheduleEntry("Sunday", "09:00 - 10:00", "ITI", "GFP (C)", "Ms. Hawa Almujaini", "Room 101", 4),
                new ScheduleEntry("Sunday", "10:00 - 11:00", "ITI", "GFP (B)", "Dr. Ahmed Khalid", "Room 102", 2),
                new ScheduleEntry("Sunday", "11:00 - 12:00", "ITI", "GFP (B)", "Prof. Sara Ismail", "Room 103", 2),
                new ScheduleEntry("Monday", "08:00 - 09:00", "IT2 (CBT27)", "GFP (A)", "Ms. Hawa Almujaini", "Room 101", 1),
                new ScheduleEntry("Monday", "10:00 - 11:00", "BTEA 102 Soft Skills", "GFP (B)", "Dr. Ahmed Khalid", "Lab 201", 3),
                new ScheduleEntry("Monday", "11:00 - 12:00", "ITI", "GFP (C)", "Prof. Sara Ismail", "Room 102", 4),
                new ScheduleEntry("Tuesday", "08:00 - 09:00", "ITI", "GFP (A)", "Ms. Hawa Almujaini", "Room 103", 0),
                new ScheduleEntry("Tuesday", "09:00 - 10:00", "BTEA 102", "GFP (B)", "Dr. Ahmed Khalid", "Lab 202", 3),
                new ScheduleEntry("Tuesday", "11:00 - 12:00", "ITI", "GFP (C)", "Prof. Sara Ismail", "Room 101", 4),
                new ScheduleEntry("Wednesday", "08:00 - 09:00", "Advanced IT", "GFP (A)", "Ms. Hawa Almujaini", "Room 102", 0),
                new ScheduleEntry("Thursday", "09:00 - 10:00", "Math 101", "GFP (B)", "Dr. Ahmed Khalid", "Room 103", 1),
                new ScheduleEntry("Wednesday", "10:00 - 11:00", "English", "GFP (C)", "Prof. Sara Ismail", "Lab 201", 3),
                new ScheduleEntry("Thursday", "11:00 - 12:00", "History", "GFP (A)", "Ms. Hawa Almujaini", "Lab 202", 4),
                new ScheduleEntry("Thursday", "08:00 - 09:00", "Literature", "GFP (B)", "Dr. Ahmed Khalid", "Room 101", 0)
            });
        }

        private void generate_report_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF files (*.pdf)|*.pdf";
                sfd.FileName = "Schedule_Report.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        scheduleGridPanel.Visible = true;
                        scheduleGridPanel.Update();
                        scheduleGridPanel.Refresh();

                        using (Bitmap bmp = new Bitmap(scheduleGridPanel.Width, scheduleGridPanel.Height))
                        {
                            scheduleGridPanel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                            using (var memoryStream = new System.IO.MemoryStream())
                            {
                                bmp.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                                memoryStream.Position = 0;

                                using (PdfDocument document = new PdfDocument())
                                {
                                    PdfPage page = document.AddPage();
                                    page.Size = PdfSharp.PageSize.A4;
                                    page.Orientation = PdfSharp.PageOrientation.Portrait;

                                    using (XGraphics gfx = XGraphics.FromPdfPage(page))
                                    {
                                        var fontTitle = new XFont("Segoe UI", 16, XFontStyle.Bold);
                                        var fontHeader = new XFont("Segoe UI", 12, XFontStyle.Regular);

                                        double margin = 40;
                                        double y = margin;

                                        gfx.DrawString("FOUNDATION PROGRAM", fontTitle, XBrushes.Black, new XPoint(page.Width / 2, y), XStringFormats.TopCenter);
                                        y += 25;
                                        gfx.DrawString("LECTURER'S LOAD", fontTitle, XBrushes.Black, new XPoint(page.Width / 2, y), XStringFormats.TopCenter);
                                        y += 40;

                                        string lecturerName = $"Lecturer Name: {cmbLecturer.SelectedItem ?? "Unknown"}";
                                        int teachingLoadCount = currentEntries.Count(entry => entry.Lecturer == (cmbLecturer.SelectedItem?.ToString() ?? "Unknown"));
                                        string teachingLoad = $"No. of Teaching Load: {teachingLoadCount}";
                                        string subjectsTaught = "Subjects Taught: " + string.Join(", ", currentEntries
                                            .Where(entry => entry.Lecturer == (cmbLecturer.SelectedItem?.ToString() ?? "Unknown"))
                                            .Select(entry => entry.Subject)
                                            .Distinct());

                                        gfx.DrawString(lecturerName, fontHeader, XBrushes.Black, margin, y);
                                        gfx.DrawString(teachingLoad, fontHeader, XBrushes.Black, page.Width - margin - 200, y);
                                        y += 20;
                                        gfx.DrawString(subjectsTaught, fontHeader, XBrushes.Black, margin, y);
                                        y += 30;

                                        using (XImage img = XImage.FromStream(memoryStream))
                                        {
                                            double imgWidth = img.PixelWidth * 72 / img.HorizontalResolution;
                                            double imgHeight = img.PixelHeight * 72 / img.VerticalResolution;

                                            double scale = 1.0;
                                            if (imgWidth > page.Width - 2 * margin)
                                            {
                                                scale = (page.Width - 2 * margin) / imgWidth;
                                            }

                                            double imgX = (page.Width - imgWidth * scale) / 2;
                                            double imgY = y;

                                            gfx.DrawImage(img, imgX, imgY, imgWidth * scale, imgHeight * scale);
                                            y += imgHeight * scale;
                                        }

                                        y += 30;
                                        gfx.DrawString("Signed by:", fontHeader, XBrushes.Black, margin, y);
                                        gfx.DrawLine(XPens.Black, margin + 60, y + 5, margin + 250, y + 5);
                                        gfx.DrawString("Lecturer", fontHeader, XBrushes.Black, margin + 60, y + 20);
                                    }

                                    document.Save(sfd.FileName);
                                }
                            }
                        }

                        MessageBox.Show("PDF saved successfully!", "PDF Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error generating PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

    public class ScheduleEntry
    {
        public string Day { get; }
        public string TimeSlot { get; }
        public string Subject { get; }
        public string ClassName { get; }
        public string Lecturer { get; }
        public string Room { get; }
        public int ColorIndex { get; }

        public ScheduleEntry(string day, string timeSlot, string subject, string className, string lecturer, string room, int colorIndex)
        {
            Day = day;
            TimeSlot = timeSlot;
            Subject = subject;
            ClassName = className;
            Lecturer = lecturer;
            Room = room;
            ColorIndex = colorIndex;
        }
    }
}