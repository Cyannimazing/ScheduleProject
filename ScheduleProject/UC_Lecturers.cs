using System;
using System.Drawing;
using System.Windows.Forms;
using ScheduleProject.data.controllers;
using ScheduleProject.data.models;
using ScheduleProject.data.service;
using ScheduleProject.InputForm;

namespace ScheduleProject
{
    public partial class UC_Lecturers : UserControl
    {
        private Color primaryColor = ColorTranslator.FromHtml("#2D3250");
        private Color secondaryColor = ColorTranslator.FromHtml("#424769");
        private Color accentColor = ColorTranslator.FromHtml("#7077A1");
        private Color lightColor = ColorTranslator.FromHtml("#F1F6F9");
        private Color hoverColor = ColorTranslator.FromHtml("#525C94");

        public UC_Lecturers()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadAllLecturers();
        }

        private void InitializeDataGridView()
        {
            dataGridViewLecturers.BackgroundColor = lightColor;
            dataGridViewLecturers.DefaultCellStyle.BackColor = lightColor;
            dataGridViewLecturers.DefaultCellStyle.ForeColor = primaryColor;
            dataGridViewLecturers.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewLecturers.ColumnHeadersDefaultCellStyle.BackColor = secondaryColor;
            dataGridViewLecturers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewLecturers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewLecturers.EnableHeadersVisualStyles = false;
            dataGridViewLecturers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadAllLecturers()
        {
            var lecturerList = BaseService.GetAll(Controller.LECTURER);
            dataGridViewLecturers.Rows.Clear();

            foreach (Lecturer lecturer in lecturerList)
            {
                dataGridViewLecturers.Rows.Add(lecturer.Id, lecturer.Title, lecturer.FName, lecturer.LName, lecturer.CreatedAt, lecturer.UpdatedAt);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LecturersForm lecturersForm = new LecturersForm();
            lecturersForm.ShowDialog();
            LoadAllLecturers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit lecturer functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete lecturer functionality not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridViewLecturers.Rows.Clear();
            LoadAllLecturers();
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