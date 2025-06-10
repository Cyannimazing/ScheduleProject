using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.migration
{
    internal class ClassesMigration
    {
        public static string CreateTable()
        {
            return @"CREATE TABLE IF NOT EXISTS Classes (
                    id INTEGER PRIMARY KEY,
                    name TEXT NOT NULL,
                    prog_code TEXT NOT NULL,
                    created_at TEXT DEFAULT CURRENT_TIMESTAMP,
                    updated_at TEXT DEFAULT CURRENT_TIMESTAMP,
                    UNIQUE (name, prog_code),
                    FOREIGN KEY (prog_code) REFERENCES Programs(code) ON UPDATE CASCADE ON DELETE RESTRICT
                );

                CREATE TRIGGER IF NOT EXISTS update_classes_timestamp 
                AFTER UPDATE ON Classes
                BEGIN
                    UPDATE Classes SET updated_at = CURRENT_TIMESTAMP WHERE id = NEW.id;
                END;";
        }
    }
}
