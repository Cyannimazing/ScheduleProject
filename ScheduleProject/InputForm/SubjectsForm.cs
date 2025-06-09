using ScheduleProject.data.models;
using ScheduleProject.data.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleProject.InputForm
{
    public partial class SubjectsForm : Form
    {
        public SubjectsForm()
        {
            InitializeComponent();
            LoadTerm();
        }

        public void LoadTerm()
        {
            var termList = BaseService.GetAll(BaseService.TERM);
            var terms = new List<Term>();
            foreach (Term term in termList)
            {
                terms.Add(term);
            }
            cb_Term.DataSource = terms;
            cb_Term.DisplayMember = "Name";
            cb_Term.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var term = (Term) cb_Term.SelectedItem;
            var subject = new Subject { Code = tb_Code.Text, Name = tb_Name.Text, Unit = Convert.ToInt16(tb_Unit.Text), TermId = (int)term.Id, IsGenEd = rb_Yes.Checked };

            try
            {
                int result = BaseService.Create(BaseService.SUBJECT, subject);
                if (result == 1)
                {
                    MessageBox.Show($"Subject added successfully! {result} row(s) inserted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == -1)
                {
                    MessageBox.Show("Failed to add subject: SQLite error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result == -2)
                {
                    MessageBox.Show("Failed to add subject: Invalid controller instance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ClearText()
        {
            tb_Code.Clear();
            tb_Name.Clear();
            tb_Unit.Clear();
            rb_Yes.Checked = false;
            rb_No.Checked = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rb_Yes_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
