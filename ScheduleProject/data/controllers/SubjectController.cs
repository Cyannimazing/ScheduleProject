using ScheduleProject.data.data;
using ScheduleProject.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.controller
{
    internal class SubjectController : IController
    {
        public int Create(Model model)
        {
            var db = DatabaseService.getConnection();

            var m = model as models.Subject;

            var query = db.CreateCommand();
            query.CommandText = @"INSERT INTO Subjects(code, name, unit, is_gen_ed, term_id) 
                              VALUES (@code, @name, @unit, @is_gen_ed, @term_id);";

            query.Parameters.AddWithValue("@code", m.Code);
            query.Parameters.AddWithValue("@name", m.Name);
            query.Parameters.AddWithValue("@unit", m.Unit);
            query.Parameters.AddWithValue("@is_gen_ed", m.IsGenEd);
            query.Parameters.AddWithValue("@term_id", m.TermId);

            try { return query.ExecuteNonQuery(); } catch { return -1; } finally { db.Close(); }
        }
        public List<Model> GetAll()
        {
            var db = DatabaseService.getConnection();
            var query = db.CreateCommand();
            query.CommandText = $@"SELECT s.*, t.name as term_name FROM Subjects s
                                   INNER JOIN Terms t 
                                   ON t.id = s.term_id;";

            var list = new List<Model>();

            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Subject
                    {
                        Id = Convert.ToInt32(reader[Subject.COL_ID]),
                        Code = reader[Subject.COL_CODE].ToString(),
                        Name = reader[Subject.COL_NAME].ToString(),
                        Unit = Convert.ToInt16(reader[Subject.COL_UNIT]),
                        IsGenEd = Convert.ToBoolean(reader[Subject.COL_IS_GEN_ED]),
                        Term = new Term
                        {
                            Id = Convert.ToInt32(reader[Subject.COL_TERM_ID]),
                            Name = reader["term_name"].ToString(),
                        },
                        CreatedAt = reader[Subject.COL_CREATED_AT].ToString(),
                        UpdatedAt = reader[Subject.COL_UPDATED_AT].ToString()
                    });
                }
            }
            db.Close();
            return list;
        }

    }
}
