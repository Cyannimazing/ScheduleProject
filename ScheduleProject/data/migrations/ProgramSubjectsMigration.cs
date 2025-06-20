﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.migration
{
    internal class ProgramSubjectsMigration
    {
        public static string CreateTable()
        {
            return @"CREATE TABLE IF NOT EXISTS Program_Subjects (
                    prog_code TEXT NOT NULL,
                    subj_code TEXT NOT NULL,
                    year_level TEXT NOT NULL,
                    term_id INTEGER NOT NULL,
                    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                    PRIMARY KEY (prog_code, subj_code, term_id),
                    FOREIGN KEY (prog_code) REFERENCES Programs(code) ON UPDATE CASCADE ON DELETE CASCADE,
                    FOREIGN KEY (subj_code) REFERENCES Subjects(code) ON UPDATE CASCADE ON DELETE CASCADE
                    FOREIGN KEY (term_id) REFERENCES Terms(id) ON UPDATE CASCADE ON DELETE RESTRICT
                
);
                CREATE INDEX IF NOT EXISTS idx_program_subjects_term ON Program_Subjects(term_id);
                CREATE INDEX IF NOT EXISTS idx_program_subjects_prog ON Program_Subjects(prog_code);
                CREATE INDEX IF NOT EXISTS idx_program_subjects_subj ON Program_Subjects(subj_code);
                CREATE TRIGGER IF NOT EXISTS update_program_subjects_timestamp 
                AFTER UPDATE ON Program_Subjects
                BEGIN
                    UPDATE Program_Subjects SET updated_at = CURRENT_TIMESTAMP WHERE id = NEW.id;
                END;";
        }
    }
}
