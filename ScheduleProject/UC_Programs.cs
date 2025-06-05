using System;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using ScheduleProject.data.models;
using ScheduleProject.data.service;
using ScheduleProject.InputForm;

namespace ScheduleProject
{
    public partial class UC_Programs : UserControl
    {
        private Color primaryColor = ColorTranslator.FromHtml("#2D3250");
        private Color secondaryColor = ColorTranslator.FromHtml("#424769");
        private Color accentColor = ColorTranslator.FromHtml("#7077A1");
        private Color lightColor = ColorTranslator.FromHtml("#F1F6F9");
        private Color hoverColor = ColorTranslator.FromHtml("#525C94");
        private Program program;

        public UC_Programs()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridViewPrograms.BackgroundColor = lightColor;
            dataGridViewPrograms.DefaultCellStyle.BackColor = lightColor;
            dataGridViewPrograms.DefaultCellStyle.ForeColor = primaryColor;
            dataGridViewPrograms.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewPrograms.ColumnHeadersDefaultCellStyle.BackColor = secondaryColor;
            dataGridViewPrograms.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewPrograms.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewPrograms.EnableHeadersVisualStyles = false;
            dataGridViewPrograms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void LoadAllPrograms()
        {

            var programsList = BaseService.GetAll(BaseService.PROGRAM);
            

            //dataGridViewPrograms.Rows.Clear();

            //foreach (var program in programsList)
            //{
            //    dataGridViewPrograms.Rows.Add();
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProgramsForm programsForm = new ProgramsForm();
            programsForm.Show();
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