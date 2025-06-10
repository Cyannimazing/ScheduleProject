using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.migration
{
    internal class LecturerSubjectsMigration
    {
        public static string CreateTable()
        {
            return @"CREATE TABLE IF NOT EXISTS Lecturer_Subjects (
                    lecturer_id INTEGER NOT NULL,
                    subj_code TEXT NOT NULL,
                    sy_term_id INTEGER NOT NULL,
                    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                    PRIMARY KEY (lecturer_id, subj_code),
                    FOREIGN KEY (lecturer_id) REFERENCES Lecturers(id) ON UPDATE CASCADE ON DELETE CASCADE,
                    FOREIGN KEY (subj_code) REFERENCES Subjects(code) ON UPDATE CASCADE ON DELETE CASCADE
                    FOREIGN KEY (sy_term_id) REFERENCES SchoolYearTerms(id) ON UPDATE CASCADE ON DELETE CASCADE
                );

                CREATE INDEX IF NOT EXISTS idx_lecturer_subjects_lecturer ON Lecturer_Subjects(lecturer_id);
                CREATE INDEX IF NOT EXISTS idx_lecturer_subjects_subj ON Lecturer_Subjects(subj_code);
                CREATE INDEX IF NOT EXISTS idx_lecturer_subjects_sy_term ON Lecturer_Subjects(sy_term_id);
                CREATE TRIGGER IF NOT EXISTS update_lecturer_subjects_timestamp 
                AFTER UPDATE ON Lecturer_Subjects
                BEGIN
                    UPDATE Lecturer_Subjects SET updated_at = CURRENT_TIMESTAMP WHERE id = NEW.id;
                END;
";
        }
    }
}
