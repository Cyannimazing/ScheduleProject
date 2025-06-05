using ScheduleProject.data.data;
using ScheduleProject.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.controller
{
    internal class LecturerSubjectController : IController
    {
        public int Create(Model model)
        {
            var db = DatabaseService.getConnection();

            var m = model as models.LecturerSubject;

            var query = db.CreateCommand();
            query.CommandText = @"INSERT INTO Lecturer_Subjects(lecturer_id, subj_code)
                              VALUES (@lecturer_id, @subj_code);";

            query.Parameters.AddWithValue("@lecturer_id", m.LecturerId);
            query.Parameters.AddWithValue("@subj_code", m.SubjCode);

            try { return query.ExecuteNonQuery(); } catch { return -1; } finally { db.Close(); }
        }

        public List<Model> GetAll()
        {
            var db = DatabaseService.getConnection();
            var query = db.CreateCommand();
            query.CommandText = $@"SELECT ls.{LecturerSubject.COL_LECTURER_ID}, 
                                l.fname as {LecturerSubject.COL_LECTURER_FNAME},
                                l.lname as {LecturerSubject.COL_LECTURER_LNAME},
                                ls.{LecturerSubject.COL_SUBJ_CODE},
                                s.name as {LecturerSubject.COL_SUBJ_NAME}
                                FROM {LecturerSubject.TBL_NAME} ls
                                INNER JOIN {Lecturer.TBL_NAME} l
                                ON l.id = ls.{LecturerSubject.COL_LECTURER_ID}
                                INNER JOIN {Subject.TBL_NAME} s 
                                ON s.code = ls.{LecturerSubject.COL_SUBJ_CODE}
                                ";

            var list = new List<Model>();

            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new LecturerSubject
                    {
                        LecturerId = Convert.ToInt32(reader[LecturerSubject.COL_LECTURER_ID]),
                        Lecturer = new Lecturer { FName = reader[LecturerSubject.COL_LECTURER_FNAME].ToString(),
                                                  LName = reader[LecturerSubject.COL_LECTURER_LNAME].ToString(),
                        },
                        SubjCode = reader[LecturerSubject.COL_SUBJ_CODE].ToString(),
                        Subject = new Subject { Name = reader[LecturerSubject.COL_SUBJ_NAME].ToString(), }
                    });
                }
            }
            db.Close();
            return list;
        }

    }
}
