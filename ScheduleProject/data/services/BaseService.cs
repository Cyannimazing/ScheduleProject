using ScheduleProject.data.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.service
{
    internal class BaseService
    {
        public readonly static int PROGRAM = 0;
        public readonly static int SUBJECT = 1;
        public readonly static int TERM = 2;
        public readonly static int CLASS_GROUP = 3;
        public readonly static int TIME_SLOT = 4;
        public readonly static int SCHOOL_YEAR_TERM = 5;
        public readonly static int ROOM = 6;
        public readonly static int PROGRAM_SUBJECT = 7;
        public readonly static int LECTURER_SUBJECT = 8;
        public readonly static int LECTURER_SCHEDULE = 9;
        public readonly static int LECTURER = 10;

        private static IController controllerInstance = null;


        /*Parameter:
         * controller = instance ex: BaseController.PROGRAM
         * model = make sure precise model is passed
         * 
         * Return:
         * 1 = (number of inserted rows) Successful
         * -1 = (sqlite error) Unsuccessful 
         * -2 = (invalid controller instance) Unsuccessful
         */
        public static int Create(int controller, models.Model model)
        {
            controllerInstance = GetDefaultInstance(controller);
            if(controllerInstance == null)
            {
                return -2;
            }
            return controllerInstance.Create(model);
        }

        /*Parameter:
         * controller = instance ex: BaseController.PROGRAM
         * 
         * Return:
         * List<Model> = model can have different instance
         * null = Invalid controller arguement
         */
        public static List<models.Model> GetAll(int controller)
        {
            controllerInstance = GetDefaultInstance(controller);
            if(controllerInstance == null)
            {
                return null;
            }

            return controllerInstance.GetAll();
        }

        private static IController GetDefaultInstance(int controller)
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
    }
}
