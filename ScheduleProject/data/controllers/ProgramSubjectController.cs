using ScheduleProject.data.data;
using ScheduleProject.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.controller
{
    internal class ProgramSubjectController : IController
    {
        public int Create(Model model)
        {
            var db = DatabaseService.getConnection();

            var m = model as models.ProgramSubject;

            var query = db.CreateCommand();
            query.CommandText = @"INSERT INTO Program_Subjects(prog_code, subj_code)
                              VALUES (@prog_code, @subj_code);";

            query.Parameters.AddWithValue("@prog_code", m.ProgCode);
            query.Parameters.AddWithValue("@subj_code", m.SubjCode);

            try { return query.ExecuteNonQuery(); } catch { return -1; } finally { db.Close(); }
        }

        public List<Model> GetAll()
        {
            var db = DatabaseService.getConnection();
            var query = db.CreateCommand();
            query.CommandText = $@"SELECT ps.prog_code, p.name as prog_name, ps.subj_code, s.name as subj_name
                                FROM Program_Subjects ps
                                INNER JOIN Programs p
                                ON p.code = ps.prog_code
                                INNER JOIN Subjects s 
                                ON s.code = ps.subj_code
                                ";

            var list = new List<Model>();

            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new ProgramSubject
                    {
                        ProgCode = reader[ProgramSubject.COL_PROG_CODE].ToString(),
                        Program = new Program { Name = reader[ProgramSubject.COL_PROG_NAME].ToString() },
                        SubjCode = reader[ProgramSubject.COL_SUBJ_CODE].ToString(),
                        Subject = new Subject { Name = reader[ProgramSubject.COL_SUBJ_NAME].ToString() } 
                    });
                }
            }
            db.Close();
            return list;
        }

    }
}
