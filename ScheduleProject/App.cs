using ScheduleProject.data.controller;
using ScheduleProject.data.controllers;
using ScheduleProject.data.data;
using ScheduleProject.data.migration;
using ScheduleProject.data.models;
using ScheduleProject.data.service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleProject
{
    internal static class App
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //TEST 

            var db = new DatabaseService();

            //TimeSlot.TimeSlotSeeder();
            //Program.ProgramSeeder();
            //Lecturer.LecturerSeeder();
            //Term.TermSeeder();
            //Room.RoomSeeder();
            //Subject.SubjectSeeder();
            //Subject.SubjectSeeder();
            //ClassGroup.ClassGroupSeeder();
            //SchoolYearTerm.SchoolYearTermSeeder();

            //Trace.WriteLine(BaseService.Create(BaseService.LECTURER_SCHEDULE, LecturerSchedule.LecturerScheduleSeeder()));

            //List<Model> models = BaseService.GetAll(BaseService.LECTURER_SUBJECT);
            //foreach (LecturerSubject model in models)
            //{
            //    Trace.WriteLine(model.Lecturer.FName + " " + model.Subject.Name);
            //}

            //LecturerSubject lec_sub = (LecturerSubject)BaseService.GetSubjectsById(Controller.JUNCTION_LECTURER_SUBJECT,3);
            //ProgramSubject prog_sub = (ProgramSubject)BaseService.GetSubjectsById(Controller.JUNCTION_PROGRAM_SUBJECT,1);

            //            Trace.WriteLine($@"{lec_sub.Lecturer.Id}
            //{lec_sub.Lecturer.Title} {lec_sub.Lecturer.LName}, {lec_sub.Lecturer.FName} 
            //");

            //            foreach(Subject s in lec_sub.Subjects)
            //            {
            //                Trace.WriteLine($"{s.Code} {s.Name} {s.Unit} {s.TermId} {s.IsGenEd} ");
            //            }

            //            Trace.WriteLine($@"{prog_sub.Program.Code}
            //{prog_sub.Program.Name}");

            //            foreach (Subject s in prog_sub.Subjects)
            //            {
            //                Trace.WriteLine($"{s.Code} {s.Name} {s.Unit} {s.TermId} {s.IsGenEd} ");
            //            }


            //TEST

            Application.Run(new Form1());
        }   
    }
}
