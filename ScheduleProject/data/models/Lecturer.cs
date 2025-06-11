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
            List<Lecturer> lecturers = new List<Lecturer>();
            lecturers.Add(new Lecturer
            {
                Title = "Ms.",
                FName = "Hawa",
                LName = "ALmujaini"
            });
            lecturers.Add(new Lecturer
            {
                Title = "Dr.",
                FName = "Harpreet"
            });
            lecturers.Add(new Lecturer
            {
                Title = "Mr.",
                FName = "Yunus"
            });
            lecturers.Add(new Lecturer
            {
                Title = "Dr.",
                FName = "Rose",
            });
            lecturers.Add(new Lecturer
            {
                Title = "Ms.",
                FName = "Bishara",
            });
            lecturers.Add(new Lecturer
            {
                Title = "Dr.",
                FName = "Shaimaa Al",
                LName = "Tabib"
            });

            foreach (var item in lecturers)
            {
                BaseService.Create(Controller.LECTURER, item);
            }
        }
    }


}
