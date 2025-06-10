using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.migration
{
    internal class LecturersMigration
    {
        public static string CreateTable()
        {
            return @"CREATE TABLE IF NOT EXISTS Lecturers (
                    id INTEGER PRIMARY KEY,
                    title TEXT NOT NULL,
                    fname TEXT NOT NULL,
                    lname TEXT NOT NULL,
                    created_at TEXT DEFAULT CURRENT_TIMESTAMP,
                    updated_at TEXT DEFAULT CURRENT_TIMESTAMP,
                    UNIQUE (fname, lname)
                );

                CREATE TRIGGER IF NOT EXISTS update_lecturers_timestamp 
                AFTER UPDATE ON Lecturers
                BEGIN
                    UPDATE Lecturers SET updated_at = CURRENT_TIMESTAMP WHERE id = NEW.id;
                END;";
        }
    }
}
