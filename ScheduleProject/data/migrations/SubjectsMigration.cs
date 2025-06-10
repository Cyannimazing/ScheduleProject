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
                    term_id INTEGER NOT NULL,
                    created_at TEXT DEFAULT CURRENT_TIMESTAMP,
                    updated_at TEXT DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (term_id) REFERENCES Terms(id) ON UPDATE CASCADE ON DELETE RESTRICT
                );

                CREATE TRIGGER IF NOT EXISTS update_subjects_timestamp 
                AFTER UPDATE ON Subjects
                BEGIN
                    UPDATE Subjects SET updated_at = CURRENT_TIMESTAMP WHERE id = NEW.id;
                END;

                CREATE INDEX IF NOT EXISTS idx_subjects_term ON Subjects(term_id);";
        }
    }
}
