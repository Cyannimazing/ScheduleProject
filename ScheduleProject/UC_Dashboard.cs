using System;
using System.Collections.Generic; // Changed from ArrayList to List
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Linq;

namespace ScheduleProject
{
    public partial class UC_Dashboard : UserControl
    {
        private Color[] schedulePalette = new Color[] {
            ColorTranslator.FromHtml("#A2C8EC"), // Light Blue
            ColorTranslator.FromHtml("#F9C19F"), // Light Peach
            ColorTranslator.FromHtml("#C9E6A7"), // Light Green
            ColorTranslator.FromHtml("#E6B0E4"), // Light Purple
            ColorTranslator.FromHtml("#FADF8A")  // Light Yellow
        };

        private TableLayoutPanel scheduleTable;
        private Panel[] scheduleCells;
        private bool isGridInitialized;
        private List<ScheduleEntry> currentEntries = new List<ScheduleEntry>(); // Initialized List<ScheduleEntry>
        private string[] timeSlots = { "08:00 - 09:00", "09:00 - 10:00", "10:00 - 11:00", "11:00 - 12:00", "1:00 - 2:00", "2:00 - 3:00", "3:00 - 4:00", "4:00 - 5:00" };
        private string[] dayNames = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday" };

        public UC_Dashboard()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            // Populate combobox items
            cmbClass.Items.AddRange(new object[] {
                "All",
                "GFP (C)",
                "GFP (B)",
                "GFP (A)"
            });
            cmbLecturer.Items.AddRange(new object[] {
                "Ms. Hawa Almujaini",
                "Dr. Ahmed Khalid",
                "Prof. Sara Ismail"
            });
            cmbRoom.Items.AddRange(new object[] {
                "All",
                "Room 101",
                "Room 102",
                "Room 103",
                "Lab 201",
                "Lab 202"
            });

            cmbClass.SelectedIndex = 0;
            cmbLecturer.SelectedIndex = 0;
            cmbRoom.SelectedIndex = 0;
            isGridInitialized = false;
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            if (!isGridInitialized)
            {
                CreateScheduleGrid();
                isGridInitialized = true;
                LoadSampleData();
                UpdateScheduleGridAsync(); // Initial load
            }
        }

        private void CreateScheduleGrid()
        {
            scheduleGridPanel.Controls.Clear();

            scheduleTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                RowCount = timeSlots.Length + 1, // Number of slots + header
                ColumnCount = 6,
                AutoSize = false,
                BackColor = Color.White
            };
            scheduleGridPanel.Controls.Add(scheduleTable);

            // Even column widths
            for (int i = 0; i < 6; i++)
            {
                scheduleTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 6));
            }

            // Headers and time slots
            string[] headers = { "Time", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday" };
            for (int i = 0; i < headers.Length; i++)
            {
                Label label = new Label
                {
                    Text = headers[i],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.LightGray,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };
                scheduleTable.Controls.Add(label, i, 0);
            }

            for (int row = 0; row < timeSlots.Length; row++)
            {
                Label label = new Label
                {
                    Text = timeSlots[row],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.WhiteSmoke,
                    Font = new Font("Arial", 9)
                };
                scheduleTable.Controls.Add(label, 0, row + 1);
            }

            // Pre-allocate cells dynamically
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
        }

        private async void UpdateScheduleGridAsync()
        {
            if (currentEntries == null)
            {
                return; // Safety check
            }

            scheduleGridPanel.Visible = false;

            string selectedLecturer = cmbLecturer.SelectedItem?.ToString();
            string selectedClass = cmbClass.SelectedItem?.ToString();
            string selectedRoom = cmbRoom.SelectedItem?.ToString();

            await Task.Run(() =>
            {
                if (scheduleTable == null) return;

                var cellUpdates = new List<Tuple<int, ScheduleEntry>>();
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
                                cellUpdates.Add(Tuple.Create(index, entry));
                            }
                        }
                    }
                }

                BeginInvoke((Action)(() =>
                {
                    for (int i = 0; i < scheduleCells.Length; i++)
                    {
                        scheduleCells[i].Controls.Clear();
                        scheduleCells[i].Tag = null;
                        scheduleCells[i].BackColor = Color.White;
                    }

                    foreach (var update in cellUpdates)
                    {
                        int index = update.Item1;
                        ScheduleEntry entry = update.Item2;
                        AddScheduleEntry(scheduleCells[index], entry);
                    }

                    scheduleGridPanel.Visible = true;
                    scheduleTable.Refresh();
                }));
            });
        }

        private void AddScheduleEntry(Panel cell, ScheduleEntry entry)
        {
            cell.BackColor = schedulePalette[entry.ColorIndex % schedulePalette.Length];

            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 4,
                ColumnCount = 1,
                AutoSize = false
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 30f));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));

            layout.Controls.Add(new Label { Text = entry.Subject, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 8) }, 0, 0);
            layout.Controls.Add(new Label { Text = entry.ClassName, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 8) }, 0, 1);
            layout.Controls.Add(new Label { Text = entry.Lecturer, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 8) }, 0, 2);
            layout.Controls.Add(new Label { Text = entry.Room, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 8) }, 0, 3);

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
            ScheduleEntry[] sharedData = new ScheduleEntry[]
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
            };

            currentEntries.AddRange(sharedData);
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
                        scheduleGridPanel.SuspendLayout();
                        scheduleGridPanel.ResumeLayout(true);
                        scheduleGridPanel.PerformLayout();

                        Bitmap bmp = new Bitmap(scheduleGridPanel.Width, scheduleGridPanel.Height);
                        scheduleGridPanel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                        using (var memoryStream = new System.IO.MemoryStream())
                        {
                            bmp.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                            memoryStream.Position = 0;

                            using (PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument())
                            {
                                PdfSharp.Pdf.PdfPage page = document.AddPage();
                                page.Size = PdfSharp.PageSize.A4;
                                page.Orientation = PdfSharp.PageOrientation.Portrait;

                                using (PdfSharp.Drawing.XGraphics gfx = PdfSharp.Drawing.XGraphics.FromPdfPage(page))
                                {
                                    var fontTitle = new PdfSharp.Drawing.XFont("Arial", 16, PdfSharp.Drawing.XFontStyle.Bold);
                                    var fontHeader = new PdfSharp.Drawing.XFont("Arial", 12, PdfSharp.Drawing.XFontStyle.Regular);

                                    double margin = 40;
                                    double y = margin;

                                    gfx.DrawString("FOUNDATION PROGRAM", fontTitle, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XPoint(page.Width / 2, y), PdfSharp.Drawing.XStringFormats.TopCenter);
                                    y += 25;
                                    gfx.DrawString("LECTURER'S LOAD", fontTitle, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XPoint(page.Width / 2, y), PdfSharp.Drawing.XStringFormats.TopCenter);
                                    y += 40;

                                    string lecturerName = $"Lecturer Name: {cmbLecturer.SelectedItem ?? "Unknown"}";
                                    int teachingLoadCount = currentEntries.Count(entry => entry.Lecturer == cmbLecturer.SelectedItem?.ToString());
                                    string teachingLoad = $"No. of Teaching Load: {teachingLoadCount}";
                                    string subjectsTaught = "Subjects Taught: IT, Soft Skills"; // Could be dynamically generated

                                    gfx.DrawString(lecturerName, fontHeader, PdfSharp.Drawing.XBrushes.Black, margin, y);
                                    gfx.DrawString(teachingLoad, fontHeader, PdfSharp.Drawing.XBrushes.Black, page.Width - margin - 200, y);
                                    y += 20;
                                    gfx.DrawString(subjectsTaught, fontHeader, PdfSharp.Drawing.XBrushes.Black, margin, y);
                                    y += 30;

                                    using (PdfSharp.Drawing.XImage img = PdfSharp.Drawing.XImage.FromStream(memoryStream))
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
                                    gfx.DrawString("Signed by:", fontHeader, PdfSharp.Drawing.XBrushes.Black, margin, y);
                                    gfx.DrawLine(PdfSharp.Drawing.XPens.Black, margin + 60, y + 5, margin + 250, y + 5);
                                    gfx.DrawString("Lecturer", fontHeader, PdfSharp.Drawing.XBrushes.Black, margin + 60, y + 10);
                                }

                                document.Save(sfd.FileName);
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