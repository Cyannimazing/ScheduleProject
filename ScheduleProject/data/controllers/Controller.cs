using ScheduleProject.data.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.controllers
{
    internal class Controller
    {
        public readonly static int PROGRAM = 0;
        public readonly static int SUBJECT = 1;
        public readonly static int TERM = 2;
        public readonly static int CLASS_GROUP = 3;
        public readonly static int TIME_SLOT = 4;
        public readonly static int SCHOOL_YEAR_TERM = 5;
        public readonly static int ROOM = 6;
        public readonly static int JUNCTION_PROGRAM_SUBJECT = 7;
        public readonly static int JUNCTION_LECTURER_SUBJECT = 8;
        public readonly static int LECTURER_SCHEDULE = 9;
        public readonly static int LECTURER = 10;

        //Getter Instance Controller 
        public static IController GetControllerInstance(int controller)
        {
            switch (controller)
            {
                case 0: return new ProgramController();
                case 1: return new SubjectController();
                case 2: return new TermController();
                case 3: return new ClassController();
                case 4: return new TimeSlotController();
                case 5: return new SchoolYearTermController();
                case 6: return new RoomController();
                case 7: return new ProgramSubjectController();
                case 8: return new LecturerSubjectController();
                case 9: return new LecturerScheduleController();
                case 10: return new LecturerController();
                default: return null;
            }
        }

        public static IFetchSubjects GetJunctionControllerInstance(int junction)
        {
            switch (junction)
            {
                case 7: return new ProgramSubjectController();
                case 8: return new LecturerSubjectController();
                default : return null;
            }
        }
    }
}
