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
            dataGridViewPrograms.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
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
                dataGridViewPrograms.Rows.Add(program.Id, program.Code, program.Name);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProgramsForm programsForm = new ProgramsForm();
            programsForm.ShowDialog();
            LoadAllPrograms();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllPrograms();
        }

    }
}