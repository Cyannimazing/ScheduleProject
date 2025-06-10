using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScheduleProject.data.controllers;
using ScheduleProject.data.models;
using ScheduleProject.data.service;

namespace ScheduleProject.InputForm
{
    public partial class ClassesForm : Form
    {
        public ClassesForm()
        {
            InitializeComponent();
            LoadProgram();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cb_program.SelectedItem == null)
            {
                MessageBox.Show("Please select a program from the ComboBox.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var selectedProgram = (KeyValuePair<int, string>)cb_program.SelectedItem;
                string programCode = selectedProgram.Value;
                ClassGroup classGroup = new ClassGroup();
                classGroup.Name = tb_Name.Text;
                classGroup.ProgCode = programCode;

                try
                {
                    int result = BaseService.Create(Controller.CLASS_GROUP, classGroup);
                    if (result == 1)
                    {
                        MessageBox.Show($"ClassGroup added successfully! {result} row(s) inserted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (result == -1)
                    {
                        MessageBox.Show("Failed to add classGroup: SQLite error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (result == -2)
                    {
                        MessageBox.Show("Failed to add classGroup: Invalid controller instance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        public void LoadProgram()
        {
            //Load CB Program GetAll Program
            var programsList = BaseService.GetAll(Controller.PROGRAM);

            cb_program.Items.Clear(); 
            foreach (Program program in programsList)
            {
                cb_program.Items.Add(new KeyValuePair<int, string>(program.Id, program.Code));
            }
            cb_program.ValueMember = "Key";
            cb_program.DisplayMember = "Value";

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
