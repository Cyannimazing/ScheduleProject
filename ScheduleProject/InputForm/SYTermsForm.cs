using System;
using System.Windows.Forms;

namespace ScheduleProject.InputForm
{
    public partial class SYTermsForm : Form
    {
        public SYTermsForm()
        {
            InitializeComponent();
            YearOnly();

        }
        public void LoadTerm()
        {
            //GETALL TERM
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(startYear.Text);
            MessageBox.Show(endYear.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void YearOnly()
        {
            // Configure startYear DateTimePicker to show only year
            startYear.Format = DateTimePickerFormat.Custom;
            startYear.CustomFormat = "yyyy";
            startYear.ShowUpDown = true;

            // Configure endYear DateTimePicker to show only year
            endYear.Format = DateTimePickerFormat.Custom;
            endYear.CustomFormat = "yyyy";
            endYear.ShowUpDown = true;
        }
    }
}

