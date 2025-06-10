
﻿using System;
﻿using ScheduleProject.data.controllers;
using ScheduleProject.data.models;
using ScheduleProject.data.service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleProject.InputForm
{
    public partial class SYTermsForm : Form
    {
        public SYTermsForm()
        {
            InitializeComponent();
            YearOnly();
            LoadTerm();
        }

        private void LoadTerm()
        {
            var termList = BaseService.GetAll(Controller.TERM);
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
            try
            {
                var term = (Term)cb_Term.SelectedItem;
                if (term == null)
                {
                    //NullReference Logic
                    return;
                }
                int result = BaseService.Create(Controller.SCHOOL_YEAR_TERM, new SchoolYearTerm
                {
                    TermId = term.Id,
                    SchoolYear = startYear.Text + "-" + endYear.Text,
                    StartDate = DateFormatter(startDate),
                    EndDate = DateFormatter(endDate)
                });
                if (result == 1)
                {
                    MessageBox.Show($"School Year added successfully! {result} row(s) inserted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == -1)
                {
                    MessageBox.Show("Failed to add School Year: SQLite error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result == -2)
                {
                    MessageBox.Show("Failed to add School Year: Invalid controller instance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Unexpected result: {result}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.Close();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void YearOnly()
        {
            // Configure startYear DateTimePicker
            startYear.Format = DateTimePickerFormat.Custom;
            startYear.CustomFormat = "yyyy";
            startYear.ShowUpDown = true;

            // Configure endYear DateTimePicker
            endYear.Text = (startYear.Value.Year + 1) + "";
            endYear.Enabled = false;

            startDate.MinDate = new DateTime(startYear.Value.Year, 1, 1);
            startDate.MaxDate = new DateTime(Convert.ToInt32(endYear.Text), 12, 31);

            endDate.MinDate = new DateTime(startYear.Value.Year, 1, 1);
            endDate.MaxDate = new DateTime(Convert.ToInt32(endYear.Text), 12, 31);



            // Event to update endYear minimum date based on startYear selection
            startYear.ValueChanged += (sender, e) =>
            {
                endYear.Text = (startYear.Value.Year + 1) + "";


                startDate.MinDate = new DateTime(startYear.Value.Year, 1, 1);
                startDate.MaxDate = new DateTime(Convert.ToInt32(endYear.Text), 12, 31);

                endDate.MinDate = new DateTime(startYear.Value.Year, 1, 1);
                endDate.MaxDate = new DateTime(Convert.ToInt32(endYear.Text), 12, 31);
            };
        }

        private string DateFormatter(DateTimePicker date)
        {
            return date.Value.Year + "-" + date.Value.Month + "-" + date.Value.Day;
        }
    }
}

