using System;
using System.Windows.Forms;
using ScheduleProject.data.controllers;
using ScheduleProject.data.models;
using ScheduleProject.data.service;

namespace ScheduleProject.InputForm
{
    public partial class LecturersForm : Form
    {
        public LecturersForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Lecturer lecturer = new Lecturer();
            lecturer.Title = tb_Title.Text;
            lecturer.FName = tb_fName.Text;
            lecturer.LName = tb_lastName.Text;

            try
            {
                int result = BaseService.Create(Controller.LECTURER, lecturer);
                if (result == 1)
                {
                    MessageBox.Show($"Lecturer added successfully! {result} row(s) inserted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == -1)
                {
                    MessageBox.Show("Failed to add lecturer: SQLite error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result == -2)
                {
                    MessageBox.Show("Failed to add lecturer: Invalid controller instance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ClearText()
        {
            tb_Title.Text = string.Empty;
            tb_lastName.Text = string.Empty;
            tb_fName.Text = string.Empty;
        }
    }
}
