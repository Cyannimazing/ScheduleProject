using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.migration
{
    internal class TimeSlotsMigration
    {
        public static string CreateTable()
        {
            return @"CREATE TABLE IF NOT EXISTS Time_Slots (
                    id INTEGER PRIMARY KEY,
                    day TEXT NOT NULL,
                    start_time TEXT NOT NULL,
                    end_time TEXT NOT NULL,
                    UNIQUE (day, start_time)
                );";
        }
    }
}
