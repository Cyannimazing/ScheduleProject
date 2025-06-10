using ScheduleProject.data.data;
using ScheduleProject.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.controller
{
    internal class TimeSlotController : IController
    {
        public int Create(Model model)
        {
            var db = DatabaseService.getConnection();

            var m = model as models.TimeSlot;

            var query = db.CreateCommand();
            query.CommandText = @"INSERT INTO Time_Slots(day, time)
                              VALUES (@day, @time);";

            query.Parameters.AddWithValue("@day", m.DayOfWeek);
            query.Parameters.AddWithValue("@time", m.Time);

            try { return query.ExecuteNonQuery(); } catch { return -1; }finally{ db.Close(); }
        }

        public List<Model> GetAll()
        {
            var db = DatabaseService.getConnection();
            var query = db.CreateCommand();
            query.CommandText = $@"SELECT * FROM {TimeSlot.TBL_NAME}";

            var list = new List<Model>();

            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new TimeSlot
                    {
                        Id = Convert.ToInt32(reader[TimeSlot.COL_ID]),
                        DayOfWeek = reader[TimeSlot.COL_DAY].ToString(),
                        Time = reader[TimeSlot.COL_TIME].ToString(),
                    });
                }
            }
            db.Close();
            return list;
        }
    }
}
