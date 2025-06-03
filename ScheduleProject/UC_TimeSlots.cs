using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScheduleProject
{
    public partial class UC_TimeSlots : UserControl
    {
        private Color primaryColor = ColorTranslator.FromHtml("#2D3250");
        private Color secondaryColor = ColorTranslator.FromHtml("#424769");
        private Color accentColor = ColorTranslator.FromHtml("#7077A1");
        private Color lightColor = ColorTranslator.FromHtml("#F1F6F9");
        private Color hoverColor = ColorTranslator.FromHtml("#525C94");

        public UC_TimeSlots()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadSampleData();
        }

        private void InitializeDataGridView()
        {
            dataGridViewTimeSlots.BackgroundColor = lightColor;
            dataGridViewTimeSlots.DefaultCellStyle.BackColor = lightColor;
            dataGridViewTimeSlots.DefaultCellStyle.ForeColor = primaryColor;
            dataGridViewTimeSlots.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewTimeSlots.ColumnHeadersDefaultCellStyle.BackColor = secondaryColor;
            dataGridViewTimeSlots.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewTimeSlots.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewTimeSlots.EnableHeadersVisualStyles = false;
            dataGridViewTimeSlots.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadSampleData()
        {
            dataGridViewTimeSlots.Rows.Add(1, "Monday", "08:00:00", "09:00:00", DateTime.Now);
            dataGridViewTimeSlots.Rows.Add(2, "Tuesday", "09:00:00", "10:00:00", DateTime.Now);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add new time slot functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit time slot functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete time slot functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridViewTimeSlots.Rows.Clear();
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