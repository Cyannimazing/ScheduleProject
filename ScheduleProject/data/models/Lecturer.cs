using ScheduleProject.data.controllers;
using ScheduleProject.data.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.models
{
    public class Lecturer : Model
    {
        public static string TBL_NAME = "Lecturers";
        public static string COL_TITLE = "title";
        public static string COL_FNAME = "fname";
        public static string COL_LNAME = "lname";

        public string Title { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public List<LecturerSubject> LecturerSubjects { get; set; }
        public List<LecturerSchedule> Schedules { get; set; }

        public static void LecturerSeeder()
        {
            BaseService.Create(Controller.LECTURER, new Lecturer
            {
                Title = "Prof.",
                FName = "Juan",
                LName = "Dela Cruz"
            });
            BaseService.Create(Controller.LECTURER, new Lecturer
            {
                Title = "Doc.",
                FName = "John",
                LName = "Doe"
            });
        }
    }


}
