using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScheduleProject
{
    public partial class UC_Schedules : UserControl
    {
        private Color primaryColor = ColorTranslator.FromHtml("#2D3250");
        private Color secondaryColor = ColorTranslator.FromHtml("#424769");
        private Color accentColor = ColorTranslator.FromHtml("#7077A1");
        private Color lightColor = ColorTranslator.FromHtml("#F1F6F9");
        private Color hoverColor = ColorTranslator.FromHtml("#525C94");

        public UC_Schedules()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridViewSchedules.BackgroundColor = lightColor;
            dataGridViewSchedules.DefaultCellStyle.BackColor = lightColor;
            dataGridViewSchedules.DefaultCellStyle.ForeColor = primaryColor;
            dataGridViewSchedules.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewSchedules.ColumnHeadersDefaultCellStyle.BackColor = secondaryColor;
            dataGridViewSchedules.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewSchedules.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewSchedules.EnableHeadersVisualStyles = false;
            dataGridViewSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Placeholder for Add form
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Placeholder for Edit form
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Placeholder for Delete confirmation
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Placeholder for data refresh
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