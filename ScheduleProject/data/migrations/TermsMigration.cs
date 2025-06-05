using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.migration
{
    internal class TermsMigration
    {
        public static string CreateTable()
        {
            return @"CREATE TABLE IF NOT EXISTS Terms (
                    id INTEGER PRIMARY KEY,
                    name TEXT UNIQUE NOT NULL,
                    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP
                );

                CREATE TRIGGER IF NOT EXISTS update_terms_timestamp 
                AFTER UPDATE ON Terms
                BEGIN
                    UPDATE Terms SET updated_at = CURRENT_TIMESTAMP WHERE id = NEW.id;
                END;";
        }
    }
}
