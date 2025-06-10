using System;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using ScheduleProject.data.controllers;
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
            LoadAllPrograms();
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
            var programsList = BaseService.GetAll(Controller.PROGRAM);
            dataGridViewPrograms.Rows.Clear();

            foreach (Program program in programsList)
            {
                dataGridViewPrograms.Rows.Add(program.Id, program.Code, program.Name, program.CreatedAt, program.UpdatedAt);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProgramsForm programsForm = new ProgramsForm();
            programsForm.ShowDialog();
            LoadAllPrograms();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //var selected = dataGridViewPrograms.SelectedRows;
            //foreach (DataGridViewRow item in selected)
            //{
            //    var value = item.Cells[1].Value;
            //    MessageBox.Show(value.ToString());
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Placeholder for Delete confirmation
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllPrograms();
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