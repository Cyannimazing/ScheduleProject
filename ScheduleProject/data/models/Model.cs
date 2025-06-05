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
        public static string COL_CREATED_AT = "created_at";
        public static string COL_UPDATED_AT = "updated_at";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
