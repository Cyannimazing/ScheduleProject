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
        public static string COL_NAME = "updated_at";
        public static string COL_DESCRIPTION = "created_at";
        public int Id { get; set; }
        public string Created_At { get; set; } = DateTime.Now.ToString();
        public string Updated_At { get; set; } = DateTime.Now.ToString();
    }
}
