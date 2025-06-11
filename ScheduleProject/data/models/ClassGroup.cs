using ScheduleProject.data.controllers;
using ScheduleProject.data.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.models
{
    public class ClassGroup : Model
    {
        public static string TBL_NAME = "Classes";
        public static string COL_NAME = "name";
        public static string COL_PROGCODE = "prog_code";

        public string Name { get; set; }
        public string ProgCode { get; set; }
        public Program Program { get; set; }

        public static void ClassGroupSeeder()
        {
            BaseService.Create(Controller.CLASS_GROUP, new ClassGroup
            {
                Name = "A",
                ProgCode = "CBT 29" // Make sure this code exists in your Program table
            });
            BaseService.Create(Controller.CLASS_GROUP, new ClassGroup
            {
                Name = "B",
                ProgCode = "CBT 29" // Make sure this code exists in your Program table
            });
            BaseService.Create(Controller.CLASS_GROUP, new ClassGroup
            {
                Name = "C",
                ProgCode = "CBT 29" // Make sure this code exists in your Program table
            });
            BaseService.Create(Controller.CLASS_GROUP, new ClassGroup
            {
                Name = "D",
                ProgCode = "CBT 29" // Make sure this code exists in your Program table
            });
            BaseService.Create(Controller.CLASS_GROUP, new ClassGroup
            {
                Name = "E",
                ProgCode = "CBT 29" // Make sure this code exists in your Program table
            });
            BaseService.Create(Controller.CLASS_GROUP, new ClassGroup
            {
                Name = "F",
                ProgCode = "CBT 29" // Make sure this code exists in your Program table
            });

        }
    }
}
