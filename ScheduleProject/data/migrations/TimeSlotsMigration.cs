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
                    time TEXT NOT NULL,
                    created_at TEXT DEFAULT CURRENT_TIMESTAMP,
                    updated_at TEXT DEFAULT CURRENT_TIMESTAMP,
                    UNIQUE (day, time)
    
                );
                CREATE TRIGGER IF NOT EXISTS update_time_slots
                AFTER UPDATE ON Time_Slots
                BEGIN
                    UPDATE Time_Slots SET updated_at = CURRENT_TIMESTAMP WHERE id = NEW.id;
                END;
                ";
        }
    }
}
