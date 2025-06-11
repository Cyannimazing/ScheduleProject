using ScheduleProject.data.controllers;
using ScheduleProject.data.models;
using ScheduleProject.data.service;
using ScheduleProject.InputForm;
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
            dataGridViewSchoolTerms.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dataGridViewSchoolTerms.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewSchoolTerms.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewSchoolTerms.EnableHeadersVisualStyles = false;
            dataGridViewSchoolTerms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadSampleData()
        {
            var syTermList = BaseService.GetAll(Controller.SCHOOL_YEAR_TERM);
            dataGridViewSchoolTerms.Rows.Clear();

            foreach (SchoolYearTerm syTerm in syTermList)
            {
                dataGridViewSchoolTerms.Rows.Add(syTerm.Id, syTerm.SchoolYear, syTerm.Term.Name, syTerm.StartDate, syTerm.EndDate);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SYTermsForm sYTermsForm = new SYTermsForm();
            sYTermsForm.ShowDialog();
            LoadSampleData();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSampleData();
        }
    }
}