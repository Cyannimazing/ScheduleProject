using ScheduleProject.data.data;
using ScheduleProject.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.controller
{
    internal class LecturerController : IController
    {
        public int Create(Model model)
        {
            var db = DatabaseService.getConnection();

            var m = model as models.Lecturer;

            var query = db.CreateCommand();
            query.CommandText = @"INSERT INTO Lecturers(title, fname, lname)
                              VALUES (@title, @fname, @lname);";

            query.Parameters.AddWithValue("@title", m.Title);
            query.Parameters.AddWithValue("@fname", m.FName);
            query.Parameters.AddWithValue("@lname", m.LName);

            try { return query.ExecuteNonQuery(); } catch { return -1; } finally { db.Close(); }
        }

        public List<Model> GetAll()
        {
            var db = DatabaseService.getConnection();
            var query = db.CreateCommand();
            query.CommandText = $@"SELECT * FROM {Lecturer.TBL_NAME}";

            var list = new List<Model>();

            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Lecturer
                    {
                        Id = Convert.ToInt32(reader[Lecturer.COL_ID]),
                        Title = reader[Lecturer.COL_TITLE].ToString(),
                        FName = reader[Lecturer.COL_FNAME].ToString(),
                        LName = reader[Lecturer.COL_LNAME].ToString(),
                        CreatedAt = reader[Lecturer.COL_CREATED_AT].ToString(),
                        UpdatedAt = reader[Lecturer.COL_UPDATED_AT].ToString()
                    });
                }
            }
            db.Close();
            return list;
        }

    }
}
