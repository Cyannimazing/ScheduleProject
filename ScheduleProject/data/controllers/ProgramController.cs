using ScheduleProject.data.data;
using ScheduleProject.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.controller
{
    internal class ProgramController : IController
    {
        public int Create(Model model)
        {
            var db = DatabaseService.getConnection();

            var m = model as Program;

            var query = db.CreateCommand();
            query.CommandText = @"INSERT INTO Programs(code, name) VALUES (@code, @name);";

            query.Parameters.AddWithValue("@code", m.Code);
            query.Parameters.AddWithValue("@name", m.Name);

            try { return query.ExecuteNonQuery(); } catch { return -1; } finally { db.Close(); }
        }

        public List<Model> GetAll()
        {
            var db = DatabaseService.getConnection();
            var query = db.CreateCommand();
            query.CommandText = $@"SELECT * FROM {Program.TBL_NAME}";

            var list = new List<Model>();

            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Program
                    {
                        Id = Convert.ToInt32(reader[Program.COL_ID]),
                        Code = reader[Program.COL_CODE].ToString(),
                        Name = reader[Program.COL_NAME].ToString(),
                        CreatedAt = (DateTime)reader[Program.COL_CREATED_AT],
                        UpdatedAt = (DateTime)reader[Program.COL_UPDATED_AT]
                    });
                }
            }
            db.Close();
            return list;
        }

    }
}
