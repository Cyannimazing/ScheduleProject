using ScheduleProject.data.data;
using ScheduleProject.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.controller
{
    internal class RoomController : IController
    {
        public int Create(Model model)
        {
            var db = DatabaseService.getConnection();

            var m = model as models.Room;

            var query = db.CreateCommand();
            query.CommandText = @"INSERT INTO Rooms(name)
                              VALUES (@name);";

            query.Parameters.AddWithValue("@name", m.Name);

            try { return query.ExecuteNonQuery(); } catch { return -1; } finally { db.Close(); }
        }

        public List<Model> GetAll()
        {
            var db = DatabaseService.getConnection();
            var query = db.CreateCommand();
            query.CommandText = $@"SELECT * FROM {Room.TBL_NAME}";

            var list = new List<Model>();

            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Room
                    {
                        Id = Convert.ToInt32(reader[Room.COL_ID]),
                        Name = reader[Room.COL_NAME].ToString()
                    });
                }
            }
            db.Close();
            return list;
        }

    }
}
