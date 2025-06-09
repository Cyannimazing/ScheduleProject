using System;
using System.Drawing;
using System.Windows.Forms;
using ScheduleProject.data.models;
using ScheduleProject.data.service;
using ScheduleProject.InputForm;

namespace ScheduleProject
{
    public partial class UC_Terms : UserControl
    {
        private Color primaryColor = ColorTranslator.FromHtml("#2D3250");
        private Color secondaryColor = ColorTranslator.FromHtml("#424769");
        private Color accentColor = ColorTranslator.FromHtml("#7077A1");
        private Color lightColor = ColorTranslator.FromHtml("#F1F6F9");
        private Color hoverColor = ColorTranslator.FromHtml("#525C94");

        public UC_Terms()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadAllTerms();
        }

        private void InitializeDataGridView()
        {
            dataGridViewTerms.BackgroundColor = lightColor;
            dataGridViewTerms.DefaultCellStyle.BackColor = lightColor;
            dataGridViewTerms.DefaultCellStyle.ForeColor = primaryColor;
            dataGridViewTerms.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewTerms.ColumnHeadersDefaultCellStyle.BackColor = secondaryColor;
            dataGridViewTerms.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewTerms.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewTerms.EnableHeadersVisualStyles = false;
            dataGridViewTerms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TermsForm termsForm = new TermsForm();
            termsForm.ShowDialog();
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

        public void LoadAllTerms()
        {
            var termsList = BaseService.GetAll(BaseService.TERM);
            dataGridViewTerms.Rows.Clear();

            foreach (Term term in termsList)
            {
                dataGridViewTerms.Rows.Add(term.Id, term.Name, term.CreatedAt, term.UpdatedAt);
            }
        }
    }
}