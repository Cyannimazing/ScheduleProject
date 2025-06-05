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

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProgCode { get; set; }
        public Program Program { get; set; }

        public static ClassGroup ClassGroupSeeder()
        {
            return new ClassGroup
            {
                Name = "CS-1A",
                ProgCode = "BSCS" // Make sure this code exists in your Program table
            };
        }
    }
}
