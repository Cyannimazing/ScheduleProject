using ScheduleProject.data.data;
using ScheduleProject.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.controller
{
    internal class TermController : IController
    {
        public int Create(Model model)
        {
            var db = DatabaseService.getConnection();

            var m = model as models.Term;

            var query = db.CreateCommand();
            query.CommandText = @"INSERT INTO Terms(name)
                              VALUES (@name);";

            query.Parameters.AddWithValue("@name", m.Name);

            try { return query.ExecuteNonQuery(); } catch { return -1; } finally { db.Close(); }
        }

        public List<Model> GetAll()
        {
            var db = DatabaseService.getConnection();
            var query = db.CreateCommand();
            query.CommandText = $@"SELECT * FROM {Term.TBL_NAME}";

            var list = new List<Model>();

            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Term
                    {
                        Id = Convert.ToInt32(reader[Term.COL_ID]),
                        Name = reader[Term.COL_NAME].ToString(),
                        CreatedAt = (DateTime)reader[Term.COL_CREATED_AT],
                        UpdatedAt = (DateTime)reader[Term.COL_UPDATED_AT]
                    });
                }
            }
            db.Close();

            return list;
        }

    }
}
