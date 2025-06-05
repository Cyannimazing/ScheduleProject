using System;
using System.Drawing;
using System.Windows.Forms;
using ScheduleProject.InputForm;

namespace ScheduleProject
{
    public partial class UC_Rooms : UserControl
    {
        private Color primaryColor = ColorTranslator.FromHtml("#2D3250");
        private Color secondaryColor = ColorTranslator.FromHtml("#424769");
        private Color accentColor = ColorTranslator.FromHtml("#7077A1");
        private Color lightColor = ColorTranslator.FromHtml("#F1F6F9");
        private Color hoverColor = ColorTranslator.FromHtml("#525C94");

        public UC_Rooms()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadSampleData();
        }

        private void InitializeDataGridView()
        {
            dataGridViewRooms.BackgroundColor = lightColor;
            dataGridViewRooms.DefaultCellStyle.BackColor = lightColor;
            dataGridViewRooms.DefaultCellStyle.ForeColor = primaryColor;
            dataGridViewRooms.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewRooms.ColumnHeadersDefaultCellStyle.BackColor = secondaryColor;
            dataGridViewRooms.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewRooms.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewRooms.EnableHeadersVisualStyles = false;
            dataGridViewRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadSampleData()
        {
            dataGridViewRooms.Rows.Add(1, "Room 101", DateTime.Now, DateTime.Now);
            dataGridViewRooms.Rows.Add(2, "Room 102", DateTime.Now, DateTime.Now);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RoomsForm roomsForm = new RoomsForm();
            roomsForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit room functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete room functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridViewRooms.Rows.Clear();
            LoadSampleData();
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = hoverColor;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = accentColor;
            }
        }
    }
}