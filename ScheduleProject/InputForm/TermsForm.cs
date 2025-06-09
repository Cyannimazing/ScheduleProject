using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScheduleProject.data.models;
using ScheduleProject.data.service;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace ScheduleProject.InputForm
{
    public partial class TermsForm : Form
    {
        public TermsForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Term term = new Term();
            term.Name = tb_Name.Text;

            try
            {
                int result = BaseService.Create(BaseService.TERM, term);
                if (result == 1)
                {
                    MessageBox.Show($"Term added successfully! {result} row(s) inserted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == -1)
                {
                    MessageBox.Show("Failed to add term: SQLite error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result == -2)
                {
                    MessageBox.Show("Failed to add term: Invalid controller instance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            tb_Name.Text = string.Empty;
        }
    }
}
