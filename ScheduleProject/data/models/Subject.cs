using ScheduleProject.data.controllers;
using ScheduleProject.data.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.models
{
    public class Subject : Model
    {
        public static string TBL_NAME = "Subjects";
        public static string COL_CODE = "code";
        public static string COL_NAME = "name";
        public static string COL_UNIT = "unit";
        public static string COL_IS_GEN_ED = "is_gen_ed";
        public static string COL_TERM_ID = "term_id";

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public short Unit { get; set; } = 3;
        public bool IsGenEd { get; set; } = false;
        public int? TermId { get; set; }
        public Term Term { get; set; }

        public List<ProgramSubject> ProgramSubjects { get; set; }
        public List<LecturerSubject> LecturerSubjects { get; set; }

        public static void SubjectSeeder()
        {
            List<Subject> subjectLists = new List<Subject>();
            subjectLists.Add(new Subject
            {
                Code = "BTEA 1101",
                Name = "Technical Communication",
                Unit = 0,
                IsGenEd = false,
                TermId = 0,
            });
            subjectLists.Add(new Subject
            {
                Code = "BTEA 1102",
                Name = "Soft Skills I",
                Unit = 0,
                IsGenEd = false,
                TermId = 0,
            });
            subjectLists.Add(new Subject
            {
                Code = "MATH 1610",
                Name = "Engineering Mathematics I",
                Unit = 0,
                IsGenEd = false,
                TermId = 0,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 1001",
                Name = "Introduction to Automotive Technology",
                Unit = 0,
                IsGenEd = false,
                TermId = 0,
            });
            subjectLists.Add(new Subject
            {
                Code = "MECH 1404",
                Name = "Thermofluids",
                Unit = 0,
                IsGenEd = false,    
                TermId = 0,
            });
            subjectLists.Add(new Subject
            {
                Code = "MECH 1206",
                Name = "Fundamental of Engineering Mechanics",
                Unit = 0,
                IsGenEd = false,
                TermId = 0,
            });
            subjectLists.Add(new Subject
            {
                Code = "MECH 1502",
                Name = "Engineering Drawing",
                Unit = 0,
                IsGenEd = false,
                TermId = 0,
            });
        }
    }
}
