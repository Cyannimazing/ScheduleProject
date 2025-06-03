using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScheduleProject
{
    public partial class UC_Classes : UserControl
    {
        private Color primaryColor = ColorTranslator.FromHtml("#2D3250");
        private Color secondaryColor = ColorTranslator.FromHtml("#424769");
        private Color accentColor = ColorTranslator.FromHtml("#7077A1");
        private Color lightColor = ColorTranslator.FromHtml("#F1F6F9");
        private Color hoverColor = ColorTranslator.FromHtml("#525C94");

        public UC_Classes()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadSampleData();
        }

        private void InitializeDataGridView()
        {
            dataGridViewClasses.BackgroundColor = lightColor;
            dataGridViewClasses.DefaultCellStyle.BackColor = lightColor;
            dataGridViewClasses.DefaultCellStyle.ForeColor = primaryColor;
            dataGridViewClasses.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewClasses.ColumnHeadersDefaultCellStyle.BackColor = secondaryColor;
            dataGridViewClasses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewClasses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewClasses.EnableHeadersVisualStyles = false;
            dataGridViewClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadSampleData()
        {
            dataGridViewClasses.Rows.Add(1, "Class A", "CS101", DateTime.Now, DateTime.Now);
            dataGridViewClasses.Rows.Add(2, "Class B", "CS102", DateTime.Now, DateTime.Now);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add new class functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit class functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete class functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridViewClasses.Rows.Clear();
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