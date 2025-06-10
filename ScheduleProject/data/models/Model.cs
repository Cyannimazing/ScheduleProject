using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.models
{
    public abstract class Model
    {
        public static string COL_ID = "id";
        public int Id { get; set; }
    }
}
