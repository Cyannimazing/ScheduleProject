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
            BaseService.Create(BaseService.SUBJECT, new Subject
            {
                Code = "CS101",
                Name = "Introduction to Computer Science",
                Unit = 3,
                IsGenEd = false,
                TermId = 1 // You can change this based on the actual existing Term ID
            });
            BaseService.Create(BaseService.SUBJECT, new Subject
            {
                Code = "EN101",
                Name = "English 1",
                Unit = 3,
                IsGenEd = true,
                TermId = 1 // You can change this based on the actual existing Term ID
            });
            BaseService.Create(BaseService.SUBJECT, new Subject
            {
                Code = "Cookery 101",
                Name = "Cookery 1",
                Unit = 3,
                IsGenEd = false,
                TermId = 1 // You can change this based on the actual existing Term ID
            });
        }
    }
}
