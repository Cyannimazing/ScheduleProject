using ScheduleProject.data.controllers;
using ScheduleProject.data.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.models
{
    public class Program : Model
    {
        public static string TBL_NAME = "Programs";
        public static string COL_CODE = "code";
        public static string COL_NAME = "name";

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public List<ProgramSubject> ProgramSubjects { get; set; }

        public static void ProgramSeeder()
        {
            BaseService.Create(Controller.PROGRAM, new Program
            {
                Code = "BSCS",
                Name = "Computer Science"
            });
            BaseService.Create(Controller.PROGRAM, new Program
            {
                Code = "BSHM",
                Name = "Hospitality Management"
            });
        }
    }

}
