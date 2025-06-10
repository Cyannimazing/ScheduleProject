using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.migration
{
    internal class SubjectsMigration
    {
        public static string CreateTable()
        {
            return @"CREATE TABLE IF NOT EXISTS Subjects (
                    id INTEGER PRIMARY KEY,
                    code TEXT UNIQUE NOT NULL,
                    name TEXT NOT NULL,
                    unit INTEGER NOT NULL,
                    is_gen_ed BOOLEAN DEFAULT 0,
                    created_at TEXT DEFAULT CURRENT_TIMESTAMP,
                    updated_at TEXT DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TRIGGER IF NOT EXISTS update_subjects_timestamp 
                AFTER UPDATE ON Subjects
                BEGIN
                    UPDATE Subjects SET updated_at = CURRENT_TIMESTAMP WHERE id = NEW.id;
                END;";
        }
    }
}
