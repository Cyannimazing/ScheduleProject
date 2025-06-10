using ScheduleProject.data.controllers;
using ScheduleProject.data.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.models
{
    public class Term : Model
    {
        public static string TBL_NAME = "Terms";
        public static string COL_NAME = "name";

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Subject> Subjects { get; set; }
        public List<SchoolYearTerm> SchoolYearTerms { get; set; }

        public static void TermSeeder()
        {
            for(int i = 1;  i <= 2; i++)
            {
                Term term = new Term
                {
                    Name = $"{i} Semester"
                };
                BaseService.Create(Controller.TERM, term);
            }
        }
    }
}
