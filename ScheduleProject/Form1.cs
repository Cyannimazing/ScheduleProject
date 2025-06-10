using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScheduleProject
{
    public partial class Form1 : Form
    {
        // Colors for UI
        private Color primaryColor = ColorTranslator.FromHtml("#2D3250");
        private Color secondaryColor = ColorTranslator.FromHtml("#424769");
        private Color accentColor = ColorTranslator.FromHtml("#7077A1");
        private Color lightColor = ColorTranslator.FromHtml("#F1F6F9");
        private Color hoverColor = ColorTranslator.FromHtml("#525C94");

        // Keep track of active button and user control
        private Button currentButton;
        private UserControl activeControl = null;

        // Left border for active button indicator
        private Panel leftBorderBtn;

        // Font for icons
        private Font iconFont;

        // User controls
        private readonly UC_Dashboard ucDashboard;
        private readonly UC_Lecturers ucLecturers;
        private readonly UC_Classes ucClasses;
        private readonly UC_Subjects ucSubjects;
        private readonly UC_Rooms ucRooms;
        private readonly UC_TimeSlots ucTimeSlots;
        private readonly UC_SchoolTerms ucSchoolTerms;
        private readonly UC_Programs ucPrograms;
        private readonly UC_Terms ucTerms;
        private readonly UC_Schedules ucSchedules;

        public Form1()
        {
            InitializeComponent();

            // Create a larger font for icons
            iconFont = new Font("Segoe UI Symbol", 14);

            // Initialize user controls
            ucDashboard = new UC_Dashboard();
            ucLecturers = new UC_Lecturers();
            ucClasses = new UC_Classes();
            ucSubjects = new UC_Subjects();
            ucRooms = new UC_Rooms();
            ucTimeSlots = new UC_TimeSlots();
            ucSchoolTerms = new UC_SchoolTerms();
            ucPrograms = new UC_Programs();
            ucTerms = new UC_Terms();
            ucSchedules = new UC_Schedules();

            // Set desired sidebar width
            panelSidebar.Width = 220;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create left border panel for active button indicator
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 45);
            leftBorderBtn.BackColor = Color.White;
            panelSidebar.Controls.Add(leftBorderBtn);

            // Add some margin to the header title
            lblMainTitle.Padding = new Padding(10, 0, 0, 0);

            // Add icons to buttons
            AddButtonIcons();

            // Set initial state
            ActivateButton(btnDashboard);
            OpenChildControl(ucDashboard);
        }

        private void AddButtonIcons()
        {
            // Add icons to buttons using Unicode symbols from Segoe UI Symbol font
            AddIconToButton(btnDashboard, "🏠");
            AddIconToButton(btnPrograms, "📋");
            AddIconToButton(btnLecturers, "👥");
            AddIconToButton(btnTerms, "🗓️");
            AddIconToButton(btnClasses, "🏫");
            AddIconToButton(btnSubjects, "📚");
            AddIconToButton(btnRooms, "🚪");
            AddIconToButton(btnTimeSlots, "🕒");
            AddIconToButton(btnSchoolTerms, "📅");
            AddIconToButton(btnSchedules, "⏰");
        }

        private void AddIconToButton(Button button, string iconChar)
        {
            button.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(40, 0, 0, 0);

            Label iconLabel = new Label
            {
                Text = iconChar,
                Font = iconFont,
                AutoSize = true,
                Location = new Point(15, (button.Height - 30) / 2),
                Size = new Size(30, 30),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                Tag = "icon"
            };

            foreach (Control c in button.Controls)
            {
                if (c is Label && c.Tag?.ToString() == "icon")
                {
                    button.Controls.Remove(c);
                    c.Dispose();
                }
            }

            button.Controls.Add(iconLabel);
            iconLabel.BringToFront();
        }

        private void NavButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && currentButton != btn)
            {
                ActivateButton(btn);

                switch (btn.Name)
                {
                    case "btnDashboard":
                        OpenChildControl(ucDashboard);
                        lblMainTitle.Text = "Dashboard";
                        break;
                    case "btnPrograms":
                        OpenChildControl(ucPrograms);
                        lblMainTitle.Text = "Programs Management";
                        break;
                    case "btnTerms":
                        OpenChildControl(ucTerms);
                        lblMainTitle.Text = "Terms Management";
                        break;
                    case "btnLecturers":
                        OpenChildControl(ucLecturers);
                        lblMainTitle.Text = "Lecturers Management";
                        break;
                    case "btnClasses":
                        OpenChildControl(ucClasses);
                        lblMainTitle.Text = "Classes Management";
                        break;
                    case "btnSubjects":
                        OpenChildControl(ucSubjects);
                        lblMainTitle.Text = "Subjects Management";
                        break;
                    case "btnRooms":
                        OpenChildControl(ucRooms);
                        lblMainTitle.Text = "Rooms Management";
                        break;
                    case "btnTimeSlots":
                        OpenChildControl(ucTimeSlots);
                        lblMainTitle.Text = "Time Slots Management";
                        break;
                    case "btnSchoolTerms":
                        OpenChildControl(ucSchoolTerms);
                        lblMainTitle.Text = "School Year Terms";
                        break;
                    case "btnSchedules":
                        OpenChildControl(ucSchedules);
                        lblMainTitle.Text = "Schedules Management";
                        break;
                }
            }
        }

        private void NavButton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (currentButton != btn)
            {
                btn.BackColor = hoverColor;
                foreach (Control c in btn.Controls)
                {
                    if (c is Label iconLabel)
                    {
                        iconLabel.ForeColor = Color.White;
                    }
                }
            }
        }

        private void NavButton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (currentButton != btn)
            {
                btn.BackColor = primaryColor;
                foreach (Control c in btn.Controls)
                {
                    if (c is Label iconLabel)
                    {
                        iconLabel.ForeColor = Color.White;
                    }
                }
            }
        }

        private void ActivateButton(Button button)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = primaryColor;
                currentButton.ForeColor = Color.White;
                currentButton.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                foreach (Control c in currentButton.Controls)
                {
                    if (c is Label iconLabel)
                    {
                        iconLabel.ForeColor = Color.White;
                    }
                }
            }

            currentButton = button;
            currentButton.BackColor = accentColor;
            currentButton.ForeColor = Color.White;
            currentButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            foreach (Control c in currentButton.Controls)
            {
                if (c is Label iconLabel)
                {
                    iconLabel.ForeColor = Color.White;
                }
            }

            leftBorderBtn.Location = new Point(0, button.Location.Y);
            leftBorderBtn.Visible = true;
            leftBorderBtn.BringToFront();
        }

        private void OpenChildControl(UserControl childControl)
        {
            if (activeControl != null)
            {
                panelMainContent.Controls.Remove(activeControl);
                if (!(activeControl == ucDashboard || activeControl == ucLecturers ||
                      activeControl == ucClasses || activeControl == ucSubjects ||
                      activeControl == ucRooms || activeControl == ucTimeSlots ||
                      activeControl == ucSchoolTerms || activeControl == ucPrograms ||
                      activeControl == ucTerms || activeControl == ucSchedules))
                {
                    activeControl.Dispose();
                }
            }

            activeControl = childControl;
            childControl.Dock = DockStyle.Fill;
            childControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            childControl.Size = panelMainContent.ClientSize;
            panelMainContent.Controls.Add(childControl);
            childControl.BringToFront();
            panelMainContent.PerformLayout();
        }
    }
}