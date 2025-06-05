using System;
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
                    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                    PRIMARY KEY (prog_code, subj_code),
                    FOREIGN KEY (prog_code) REFERENCES Programs(code) ON UPDATE CASCADE ON DELETE CASCADE,
                    FOREIGN KEY (subj_code) REFERENCES Subjects(code) ON UPDATE CASCADE ON DELETE CASCADE
                );

                CREATE INDEX IF NOT EXISTS idx_program_subjects_prog ON Program_Subjects(prog_code);
                CREATE INDEX IF NOT EXISTS idx_program_subjects_subj ON Program_Subjects(subj_code);";
        }
    }
}
