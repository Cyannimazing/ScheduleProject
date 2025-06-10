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
            query.CommandText = @"INSERT INTO Subjects(code, name, unit, is_gen_ed) 
                              VALUES (@code, @name, @unit, @is_gen_ed);";

            query.Parameters.AddWithValue("@code", m.Code);
            query.Parameters.AddWithValue("@name", m.Name);
            query.Parameters.AddWithValue("@unit", m.Unit);
            query.Parameters.AddWithValue("@is_gen_ed", m.IsGenEd);

            try { return query.ExecuteNonQuery(); } catch { return -1; } finally { db.Close(); }
        }
        public List<Model> GetAll()
        {
            var db = DatabaseService.getConnection();
            var query = db.CreateCommand();
            query.CommandText = $@"SELECT * FROM {Subject.TBL_NAME}";

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
