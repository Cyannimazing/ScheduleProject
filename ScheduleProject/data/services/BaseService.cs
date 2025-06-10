using ScheduleProject.data.controller;
using ScheduleProject.data.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.service
{
    internal class BaseService
    {
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
            controllerInstance = Controller.GetControllerInstance(controller);
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
            controllerInstance = Controller.GetControllerInstance(controller);
            if(controllerInstance == null)
            {
                return null;
            }

            return controllerInstance.GetAll();
        }

        /*Parameter:
         * controller = instance ex: BaseController.PROGRAM
         * id = id of the table
         * 
         * Return:
         * List<Model> = model can have different instance
         * Subjects are stored on Subjects not Subject 
         * model:
         * LecturerSubjects
         * ProgramSubject
         * 
         * null = Invalid controller arguement
         */
        public static models.Model GetSubjectsById(int junctionController, int id)
        {
            
            return Controller.GetJunctionControllerInstance(junctionController).GetSubjectsById(id);
            throw new NullReferenceException();
        }







    }
}
