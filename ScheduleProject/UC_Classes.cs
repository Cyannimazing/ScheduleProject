using System;
using System.Drawing;
using System.Windows.Forms;
using ScheduleProject.data.controllers;
using ScheduleProject.data.models;
using ScheduleProject.data.service;
using ScheduleProject.InputForm;

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
            dataGridViewClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadSampleData()
        {
            var classes = BaseService.GetAll(Controller.CLASS_GROUP);
            dataGridViewClasses.Rows.Clear();

            foreach (ClassGroup c in classes)
            {
                dataGridViewClasses.Rows.Add(c.Id, c.Name, c.ProgCode, c.CreatedAt, c.UpdatedAt);
                dataGridViewClasses.ClearSelection();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClassesForm classesForm = new ClassesForm();
            classesForm.ShowDialog();
            LoadSampleData(); 
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