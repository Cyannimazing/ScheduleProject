using ScheduleProject.data.data;
using ScheduleProject.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.controller
{
    internal class ClassController : IController
    {
        public int Create(Model model)
        {
            var db = DatabaseService.getConnection();

            var m = model as models.ClassGroup;

            var query = db.CreateCommand();
            query.CommandText = @"INSERT INTO Classes(name, prog_code)
                              VALUES (@name, @prog_code);";

            query.Parameters.AddWithValue("@name", m.Name);
            query.Parameters.AddWithValue("@prog_code", m.ProgCode);

            try { return query.ExecuteNonQuery(); } catch { return -1; } finally { db.Close(); }
        }

        public List<Model> GetAll()
        {
            var db = DatabaseService.getConnection();
            var query = db.CreateCommand();
            query.CommandText = $@"SELECT * FROM {ClassGroup.TBL_NAME}";

            var classes = new List<Model>();

            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    classes.Add(new ClassGroup
                    {
                        Id = Convert.ToInt32(reader[ClassGroup.COL_ID]),
                        Name = reader[ClassGroup.COL_NAME].ToString(),
                        ProgCode = reader[ClassGroup.COL_PROGCODE].ToString(),
                        CreatedAt = (DateTime)reader[ClassGroup.COL_CREATED_AT],
                        UpdatedAt = (DateTime)reader[ClassGroup.COL_UPDATED_AT]
                    });
                }
            }
            db.Close();
            return classes;
        }
    }
}
