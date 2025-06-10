using ScheduleProject.data.controllers;
using ScheduleProject.data.models;
using ScheduleProject.data.service;
using ScheduleProject.InputForm;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScheduleProject
{
    public partial class UC_Subjects : UserControl
    {
        private Color primaryColor = ColorTranslator.FromHtml("#2D3250");
        private Color secondaryColor = ColorTranslator.FromHtml("#424769");
        private Color accentColor = ColorTranslator.FromHtml("#7077A1");
        private Color lightColor = ColorTranslator.FromHtml("#F1F6F9");
        private Color hoverColor = ColorTranslator.FromHtml("#525C94");

        public UC_Subjects()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadSampleData();
        }

        private void InitializeDataGridView()
        {
            dataGridViewSubjects.BackgroundColor = lightColor;
            dataGridViewSubjects.DefaultCellStyle.BackColor = lightColor;
            dataGridViewSubjects.DefaultCellStyle.ForeColor = primaryColor;
            dataGridViewSubjects.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewSubjects.ColumnHeadersDefaultCellStyle.BackColor = secondaryColor;
            dataGridViewSubjects.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewSubjects.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewSubjects.EnableHeadersVisualStyles = false;
            dataGridViewSubjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadSampleData()
        {
            var programsList = BaseService.GetAll(Controller.SUBJECT);
            dataGridViewSubjects.Rows.Clear();

            foreach (Subject subject in programsList)
            {
                dataGridViewSubjects.Rows.Add(subject.Id, subject.Code, subject.Name, subject.Unit, subject.IsGenEd, subject.CreatedAt, subject.UpdatedAt);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           SubjectsForm subjectsForm = new SubjectsForm();
           subjectsForm.ShowDialog();
            LoadSampleData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit subject functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete subject functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridViewSubjects.Rows.Clear();
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