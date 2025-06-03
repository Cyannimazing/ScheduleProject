using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScheduleProject
{
    public partial class UC_SchoolTerms : UserControl
    {
        private Color primaryColor = ColorTranslator.FromHtml("#2D3250");
        private Color secondaryColor = ColorTranslator.FromHtml("#424769");
        private Color accentColor = ColorTranslator.FromHtml("#7077A1");
        private Color lightColor = ColorTranslator.FromHtml("#F1F6F9");
        private Color hoverColor = ColorTranslator.FromHtml("#525C94");

        public UC_SchoolTerms()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadSampleData();
        }

        private void InitializeDataGridView()
        {
            dataGridViewSchoolTerms.BackgroundColor = lightColor;
            dataGridViewSchoolTerms.DefaultCellStyle.BackColor = lightColor;
            dataGridViewSchoolTerms.DefaultCellStyle.ForeColor = primaryColor;
            dataGridViewSchoolTerms.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewSchoolTerms.ColumnHeadersDefaultCellStyle.BackColor = secondaryColor;
            dataGridViewSchoolTerms.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewSchoolTerms.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewSchoolTerms.EnableHeadersVisualStyles = false;
            dataGridViewSchoolTerms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadSampleData()
        {
            dataGridViewSchoolTerms.Rows.Add(1, 1, DateTime.Now.Year, "2025-01-01", "2025-06-30", DateTime.Now, DateTime.Now);
            dataGridViewSchoolTerms.Rows.Add(2, 2, DateTime.Now.Year, "2025-07-01", "2025-12-31", DateTime.Now, DateTime.Now);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add new school term functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit school term functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete school term functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridViewSchoolTerms.Rows.Clear();
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