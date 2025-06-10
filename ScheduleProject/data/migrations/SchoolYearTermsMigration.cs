using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.migration
{
    internal class SchoolYearTermsMigration
    {
        public static string CreateTable()
        {
            return @"CREATE TABLE IF NOT EXISTS School_Year_Terms (
                    id INTEGER PRIMARY KEY,
                    term_id INTEGER NOT NULL,
                    school_year TEXT NOT NULL,
                    start_date TEXT NOT NULL,
                    end_date TEXT NOT NULL,
                    created_at TEXT DEFAULT CURRENT_TIMESTAMP,
                    updated_at TEXT DEFAULT CURRENT_TIMESTAMP,
                    UNIQUE (start_date, end_date),
                    FOREIGN KEY (term_id) REFERENCES Terms(id) ON UPDATE CASCADE ON DELETE RESTRICT
                );

                CREATE TRIGGER IF NOT EXISTS update_school_year_terms_timestamp 
                AFTER UPDATE ON School_Year_Terms
                BEGIN
                    UPDATE School_Year_Terms SET updated_at = CURRENT_TIMESTAMP WHERE id = NEW.id;
                END;";
        }
    }
}
