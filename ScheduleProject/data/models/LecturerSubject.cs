using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.models
{
    public class LecturerSubject : Model
    {
        public static string TBL_NAME = "Lecturer_Subjects";
        public static string COL_LECTURER_ID = "lecturer_id";
        public static string COL_SUBJ_CODE = "subj_code";
        public static string COL_SY_TERM_ID = "sy_term_id";

        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        public string SubjCode { get; set; }
        public List<Subject> Subjects { get; set; }
        public Subject Subject { get; set; }

        public int SchoolYearTermId { get; set; }
        public SchoolYearTerm SchoolYearTerm { get; set; }

        public static LecturerSubject LecturerSubjectSeeder()
        {
            return new LecturerSubject
            {
                LecturerId = 1,
                SubjCode = "CS101"
            };
        }
    }


}
