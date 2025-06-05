using ScheduleProject.data.controller;
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

            //Trace.WriteLine(BaseService.Create(BaseService.PROGRAM, Program.ProgramSeeder()));
            //Trace.WriteLine(BaseService.Create(BaseService.LECTURER, Lecturer.LecturerSeeder()));
            //Trace.WriteLine(BaseService.Create(BaseService.ROOM, Room.RoomSeeder()));
            //Trace.WriteLine(BaseService.Create(BaseService.TERM, Term.TermSeeder()));
            //Trace.WriteLine(BaseService.Create(BaseService.SUBJECT, Subject.SubjectSeeder()));
            //Trace.WriteLine(BaseService.Create(BaseService.PROGRAM_SUBJECT, ProgramSubject.ProgramSubjectSeeder()));
            //Trace.WriteLine(BaseService.Create(BaseService.LECTURER_SUBJECT, LecturerSubject.LecturerSubjectSeeder()));
            //Trace.WriteLine(BaseService.Create(BaseService.CLASS_GROUP, ClassGroup.ClassGroupSeeder()));
            //Trace.WriteLine(BaseService.Create(BaseService.SCHOOL_YEAR_TERM, SchoolYearTerm.SchoolYearTermSeeder()));
            //Trace.WriteLine(BaseService.Create(BaseService.LECTURER_SCHEDULE, LecturerSchedule.LecturerScheduleSeeder()));

            //List<Model> models = BaseService.GetAll(BaseService.LECTURER_SUBJECT);
            //foreach (LecturerSubject model in models)
            //{
            //    Trace.WriteLine(model.Lecturer.FName + " " + model.Subject.Name);
            //}

            //TEST

            Application.Run(new Form1());
        }   
    }
}
