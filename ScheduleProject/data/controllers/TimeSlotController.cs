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
            query.CommandText = @"INSERT INTO Time_Slots(day, start_time, end_time)
                              VALUES (@day, @start_time, @end_time);";

            query.Parameters.AddWithValue("@day", m.DayOfWeek);
            query.Parameters.AddWithValue("@start_time", m.StartTime);
            query.Parameters.AddWithValue("@end_time", m.EndTime);

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
                        StartTime = reader[TimeSlot.COL_START_TIME].ToString(),
                        EndTime = reader[TimeSlot.COL_END_TIME].ToString()
                    });
                }
            }
            db.Close();
            return list;
        }

        
    }
}
