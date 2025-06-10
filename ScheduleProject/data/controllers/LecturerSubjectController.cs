using ScheduleProject.data.controllers;
using ScheduleProject.data.data;
using ScheduleProject.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ScheduleProject.data.controller
{
    internal class LecturerSubjectController : IController, IFetchSubjects
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
                                l.fname as {Lecturer.COL_FNAME},
                                l.lname as {Lecturer.COL_LNAME},
                                ls.{LecturerSubject.COL_SUBJ_CODE},
                                s.name as {Subject.COL_NAME}
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
                        Lecturer = new Lecturer { FName = reader[Lecturer.COL_FNAME].ToString(),
                                                  LName = reader[Lecturer.COL_LNAME].ToString(),
                        },
                        SubjCode = reader[LecturerSubject.COL_SUBJ_CODE].ToString(),
                        Subject = new Subject { Name = reader[Subject.COL_NAME].ToString(), }
                    });
                }
            }
            db.Close();
            return list;
        }

        public Model GetSubjectsById(int id)
        {
            var db = DatabaseService.getConnection();
            var query = DatabaseService.createQuery(
                $@"SELECT * FROM Lecturer_Subjects as ls
                INNER JOIN Lecturers as l 
                ON l.id = ls.lecturer_id 
                INNER JOIN Subjects as s 
                ON s.code = ls.subj_code
                WHERE ls.lecturer_id = '{id}';
                ", db);

            var lecturer_subject = new LecturerSubject();
            var list = new List<Subject>();

            using (var reader = query.ExecuteReader())
            {
                if (reader.Read())
                {
                    lecturer_subject.Lecturer = new Lecturer
                    {
                        Id = Convert.ToInt32(reader[LecturerSubject.COL_LECTURER_ID]),
                        Title = reader[Lecturer.COL_TITLE].ToString(),
                        FName = reader[Lecturer.COL_FNAME].ToString(),
                        LName = reader[Lecturer.COL_LNAME].ToString(),
                    };

                    list.Add(new Subject
                    {
                        Code = reader[LecturerSubject.COL_SUBJ_CODE].ToString(),
                        Name = reader[Subject.COL_NAME].ToString(),
                        Unit = Convert.ToInt16(reader[Subject.COL_UNIT]),
                        IsGenEd = Convert.ToBoolean(reader[Subject.COL_IS_GEN_ED]),
                        TermId = Convert.ToInt32(reader[Subject.COL_TERM_ID])
                    });

                    while (reader.Read())
                    {
                        list.Add(new Subject
                        {
                            Code = reader[LecturerSubject.COL_SUBJ_CODE].ToString(),
                            Name = reader[Subject.COL_NAME].ToString(),
                            Unit = Convert.ToInt16(reader[Subject.COL_UNIT]),
                            IsGenEd = Convert.ToBoolean(reader[Subject.COL_IS_GEN_ED]),
                            TermId = Convert.ToInt32(reader[Subject.COL_TERM_ID])
                        });
                    }

                    lecturer_subject.Subjects = list;

                    db.Close();
                    return lecturer_subject;
                }
            }
            throw new NullReferenceException();
        }
    }
}
