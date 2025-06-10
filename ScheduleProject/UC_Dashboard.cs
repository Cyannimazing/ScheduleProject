using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private DateTime currentWeekStart;
        private TableLayoutPanel scheduleTable;
        private Panel[] scheduleCells = new Panel[30]; // 5 days x 6 slots
        private bool isGridInitialized;
        private List<ScheduleEntry> currentEntries;



        public UC_Dashboard()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            cmbClass.SelectedIndex = 0;
            cmbLecturer.SelectedIndex = 0;
            cmbRoom.SelectedIndex = 0;

            btnApplyFilter.Click += BtnApplyFilter_Click;

            isGridInitialized = false;

        }


        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            UpdateScheduleGridAsync();
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            if (!isGridInitialized)
            {
                CreateScheduleGrid();
                isGridInitialized = true;
            }
        }

        private void CreateScheduleGrid()
        {
            scheduleGridPanel.Controls.Clear();

            scheduleTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                RowCount = 7,
                ColumnCount = 6,
                AutoSize = false
            };
            scheduleGridPanel.Controls.Add(scheduleTable);

            // Even column widths
            for (int i = 0; i < 6; i++)
            {
                scheduleTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 6));
            }

            // Even row heights
            scheduleTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40f)); // Header row
            for (int i = 1; i < 25; i++)
            {
                scheduleTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 24));
            }

            // Pre-allocate headers and time slots
            string[] dayNames = { "Time", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday" };
            for (int i = 0; i < dayNames.Length; i++)
            {
                Label label = new Label
                {
                    Text = dayNames[i],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.LightGray
                };
                scheduleTable.Controls.Add(label, i, 0);
            }

            string[] timeSlots = { "07:30 - 09:00", "09:00 - 10:30", "10:30 - 12:00", "13:00 - 14:30", "14:30 - 16:00", "16:00 - 17:30" };
            for (int row = 0; row < timeSlots.Length; row++)
            {
                Label label = new Label
                {
                    Text = timeSlots[row],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.WhiteSmoke
                };
                scheduleTable.Controls.Add(label, 0, row + 1);
            }

            // Pre-allocate cells
            int index = 0;
            for (int row = 1; row < 7; row++)
            {
                for (int col = 1; col < 6; col++)
                {
                    Panel cell = new Panel
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.White
                    };
                    cell.Click += Cell_Click;
                    scheduleTable.Controls.Add(cell, col, row);
                    scheduleCells[index++] = cell;
                }
            }
        }

        private async void UpdateScheduleGridAsync()
        {
            // Show loading screen
            loadingPanel.Visible = true;
            scheduleGridPanel.Visible = false;

            // Capture filter values on the UI thread
            string selectedClass = cmbClass.SelectedItem?.ToString() ?? "All Classes";
            string selectedLecturer = cmbLecturer.SelectedItem?.ToString() ?? "All Lecturers";
            string selectedRoom = cmbRoom.SelectedItem?.ToString() ?? "All Rooms";

            // Offload rendering to background thread
            await Task.Run(() =>
            {
                if (scheduleTable == null) return;

                // Update day headers
                var headerUpdates = new string[5];
                for (int i = 1; i < 6; i++)
                {
                    DateTime date = currentWeekStart.AddDays(i - 1);
                    headerUpdates[i - 1] = $"{new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" }[i - 1]}\n{date:MMM dd}";
                }

                // Fetch and filter entries
                int weekNumber = (int)Math.Ceiling(currentWeekStart.DayOfYear / 7.0);
                currentEntries = GetScheduleEntriesForWeek(weekNumber);

                var cellUpdates = new (int Index, ScheduleEntry Entry)[currentEntries.Count];
                int updateCount = 0;
                for (int i = 0; i < currentEntries.Count; i++)
                {
                    var entry = currentEntries[i];
                    if ((selectedClass == "All Classes" || entry.ClassName == selectedClass) &&
                        (selectedLecturer == "All Lecturers" || entry.Lecturer == selectedLecturer) &&
                        (selectedRoom == "All Rooms" || entry.Room == selectedRoom))
                    {
                        int index = (entry.Row - 1) * 5 + (entry.Col - 1);
                        if (index >= 0 && index < scheduleCells.Length)
                        {
                            cellUpdates[updateCount++] = (index, entry);
                        }
                    }
                }

                // Update UI on the main thread
                BeginInvoke((Action)(() =>
                {
                    // Apply header updates
                    for (int i = 0; i < headerUpdates.Length; i++)
                    {
                        if (scheduleTable.GetControlFromPosition(i + 1, 0) is Label label)
                        {
                            label.Text = headerUpdates[i];
                        }
                    }

                    // Clear all cells
                    for (int i = 0; i < scheduleCells.Length; i++)
                    {
                        scheduleCells[i].Controls.Clear();
                        scheduleCells[i].Tag = null;
                        scheduleCells[i].BackColor = Color.White;
                    }

                    // Apply cell updates
                    for (int i = 0; i < updateCount; i++)
                    {
                        var (index, entry) = cellUpdates[i];
                        AddScheduleEntry(scheduleCells[index], entry);
                    }

                    // Hide loading screen
                    loadingPanel.Visible = false;
                    scheduleGridPanel.Visible = true;
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

            layout.Controls.Add(new Label { Text = entry.Subject, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
            layout.Controls.Add(new Label { Text = entry.ClassName, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter }, 0, 1);
            layout.Controls.Add(new Label { Text = entry.Lecturer, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter }, 0, 2);
            layout.Controls.Add(new Label { Text = entry.Room, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter }, 0, 3);

            cell.Controls.Add(layout);
            cell.Tag = entry;
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            if (sender is Panel cell && cell.Tag is ScheduleEntry entry)
            {
                string details = $"Subject: {entry.Subject}\nClass: {entry.ClassName}\nLecturer: {entry.Lecturer}\nRoom: {entry.Room}";
                MessageBox.Show(details, "Schedule Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private List<ScheduleEntry> GetScheduleEntriesForWeek(int weekNumber)
        {
            var entries = new List<ScheduleEntry>(14);
            if (weekNumber % 2 == 0)
            {
                entries.Add(new ScheduleEntry(1, 1, "ITE101", "BSIT-1A", "Prof. John Smith", "Room 101", 0));
                entries.Add(new ScheduleEntry(2, 1, "ITE102", "BSIT-1A", "Prof. John Smith", "Lab 201", 1));
                entries.Add(new ScheduleEntry(3, 4, "GE101", "BSIT-1A", "Prof. Michael Brown", "Room 204", 2));
                entries.Add(new ScheduleEntry(1, 2, "ITE101", "BSIT-1B", "Prof. John Smith", "Room 101", 0));
                entries.Add(new ScheduleEntry(1, 3, "ITE201", "BSIT-2A", "Dr. Maria Garcia", "Room 102", 3));
                entries.Add(new ScheduleEntry(2, 2, "ITE102", "BSIT-1B", "Prof. John Smith", "Lab 201", 1));
                entries.Add(new ScheduleEntry(4, 2, "GE101", "BSCS-1A", "Prof. Michael Brown", "Room 204", 2));
            }
            else
            {
                entries.Add(new ScheduleEntry(3, 1, "ITE103", "BSIT-1A", "Prof. Lisa Johnson", "Room 103", 4));
                entries.Add(new ScheduleEntry(4, 1, "ITE204", "BSIT-2A", "Dr. Maria Garcia", "Lab 202", 3));
                entries.Add(new ScheduleEntry(2, 3, "GE102", "BSIT-1A", "Prof. Robert Wilson", "Room 203", 1));
                entries.Add(new ScheduleEntry(1, 4, "ITE103", "BSIT-1B", "Prof. Lisa Johnson", "Room 103", 4));
                entries.Add(new ScheduleEntry(1, 5, "ITE203", "BSIT-2B", "Prof. David Lee", "Room 105", 2));
                entries.Add(new ScheduleEntry(5, 2, "ITE104", "BSIT-1B", "Prof. Sarah Miller", "Lab 204", 0));
                entries.Add(new ScheduleEntry(3, 3, "GE102", "BSCS-1A", "Prof. Robert Wilson", "Room 203", 1));
            }
            return entries;
        }
    }

    public class ScheduleEntry
    {
        public int Col { get; }
        public int Row { get; }
        public string Subject { get; }
        public string ClassName { get; }
        public string Lecturer { get; }
        public string Room { get; }
        public int ColorIndex { get; }

        public ScheduleEntry(int col, int row, string subject, string className, string lecturer, string room, int colorIndex)
        {
            Col = col;
            Row = row;
            Subject = subject;
            ClassName = className;
            Lecturer = lecturer;
            Room = room;
            ColorIndex = colorIndex;
        }
    }
}