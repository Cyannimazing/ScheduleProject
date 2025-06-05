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

        public static Term TermSeeder()
        {
            return new Term
            {
                Name = "1st Semester"
            };
        }
    }
}
