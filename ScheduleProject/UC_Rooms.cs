using ScheduleProject.data.controllers;
using ScheduleProject.data.models;
using ScheduleProject.data.service;
using ScheduleProject.InputForm;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScheduleProject
{
    public partial class UC_Rooms : UserControl
    {
        private Color primaryColor = ColorTranslator.FromHtml("#2D3250");
        private Color secondaryColor = ColorTranslator.FromHtml("#424769");
        private Color accentColor = ColorTranslator.FromHtml("#7077A1");
        private Color lightColor = ColorTranslator.FromHtml("#F1F6F9");
        private Color hoverColor = ColorTranslator.FromHtml("#525C94");

        public UC_Rooms()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadSampleData();
        }

        private void InitializeDataGridView()
        {
            dataGridViewRooms.BackgroundColor = lightColor;
            dataGridViewRooms.DefaultCellStyle.BackColor = lightColor;
            dataGridViewRooms.DefaultCellStyle.ForeColor = primaryColor;
            dataGridViewRooms.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewRooms.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dataGridViewRooms.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewRooms.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewRooms.EnableHeadersVisualStyles = false;
            dataGridViewRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadSampleData()
        {
            var roomList = BaseService.GetAll(Controller.ROOM);
            dataGridViewRooms.Rows.Clear();

            foreach (Room room in roomList)
            {
                dataGridViewRooms.Rows.Add(room.Id, room.Name);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RoomsForm roomsForm = new RoomsForm();
            roomsForm.ShowDialog();
            LoadSampleData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridViewRooms.Rows.Clear();
            LoadSampleData();
        }

    }
}