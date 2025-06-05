using System;
using System.Windows.Forms;
using ScheduleProject.data.controller;
using ScheduleProject.data.models;
using ScheduleProject.data.service;

namespace ScheduleProject.InputForm
{
    public partial class ProgramsForm : Form
    {


        Program program;
        public ProgramsForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            program = new Program();
            program.Code = tb_Code.Text;
            program.Name = tb_Name.Text;

            try
            {
                int result = BaseService.Create(BaseService.PROGRAM, program);
                if (result == 1)
                {
                    MessageBox.Show($"Program added successfully! {result} row(s) inserted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == -1)
                {
                    MessageBox.Show("Failed to add program: SQLite error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result == -2)
                {
                    MessageBox.Show("Failed to add program: Invalid controller instance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Unexpected result: {result}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ClearText();
            }

        }

        public void ClearText()
        {
            tb_Code.Text = string.Empty;
            tb_Name.Text = string.Empty;
        }
    }
}
