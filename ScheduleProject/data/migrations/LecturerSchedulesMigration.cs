using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.migration
{
    internal class LecturerSchedulesMigration
    {
        public static string CreateTable()
        {
            return @"CREATE TABLE IF NOT EXISTS Lecturer_Schedules (
                    id INTEGER PRIMARY KEY,
                    lecturer_id INTEGER NOT NULL,
                    subj_code TEXT NOT NULL,
                    room_code TEXT NOT NULL,
                    time_slot_id INTEGER NOT NULL,
                    class_id INTEGER NOT NULL,
                    sy_term_id INTEGER NOT NULL,
                    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                    UNIQUE (room_code, time_slot_id, sy_term_id),
                    FOREIGN KEY (lecturer_id) REFERENCES Lecturers(id) ON UPDATE CASCADE ON DELETE RESTRICT,
                    FOREIGN KEY (subj_code) REFERENCES Subjects(code) ON UPDATE CASCADE ON DELETE RESTRICT,
                    FOREIGN KEY (room_code) REFERENCES Rooms(name) ON UPDATE CASCADE ON DELETE RESTRICT,
                    FOREIGN KEY (time_slot_id) REFERENCES Time_Slots(id) ON UPDATE CASCADE ON DELETE RESTRICT,
                    FOREIGN KEY (class_id) REFERENCES Classes(id) ON UPDATE CASCADE ON DELETE RESTRICT,
                    FOREIGN KEY (sy_term_id) REFERENCES School_Year_Terms(id) ON UPDATE CASCADE ON DELETE RESTRICT
                );

                CREATE TRIGGER IF NOT EXISTS update_lecturer_schedules_timestamp 
                AFTER UPDATE ON Lecturer_Schedules
                BEGIN
                    UPDATE Lecturer_Schedules SET updated_at = CURRENT_TIMESTAMP WHERE id = NEW.id;
                END;

                CREATE INDEX IF NOT EXISTS idx_lecturer_schedules_lecturer ON Lecturer_Schedules(lecturer_id);
                CREATE INDEX IF NOT EXISTS idx_lecturer_schedules_time ON Lecturer_Schedules(time_slot_id);
                CREATE INDEX IF NOT EXISTS idx_lecturer_schedules_room ON Lecturer_Schedules(room_code);";
        }
    }
}
