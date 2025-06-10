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
                    UNIQUE (day, time),
                    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP
    
                );
                CREATE TRIGGER IF NOT EXISTS update_time_slots
                AFTER UPDATE ON TimeSlots
                BEGIN
                    UPDATE TimeSlots SET updated_at = CURRENT_TIMESTAMP WHERE id = NEW.id;
                END;
                ";
        }
    }
}
