using ScheduleProject.data.data;
using ScheduleProject.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.controller
{
    internal class LecturerScheduleController : IController
    {
        public int Create(Model model)
        {
            var db = DatabaseService.getConnection();

            var m = model as models.LecturerSchedule;

            var query = db.CreateCommand();
            query.CommandText = @"INSERT INTO Lecturer_Schedules(lecturer_id, subj_code, room_code, time_slot_id, class_id, sy_term_id)
                              VALUES (@lecturer_id, @subj_code, @room_code, @time_slot_id, @class_id, @sy_term_id);";

            query.Parameters.AddWithValue("@lecturer_id", m.LecturerId);
            query.Parameters.AddWithValue("@subj_code", m.SubjCode);
            query.Parameters.AddWithValue("@room_code", m.RoomCode);
            query.Parameters.AddWithValue("@time_slot_id", m.TimeSlotId);
            query.Parameters.AddWithValue("@class_id", m.ClassId);
            query.Parameters.AddWithValue("@sy_term_id", m.SchoolYearTermId);

            try { return query.ExecuteNonQuery(); } catch { return -1; } finally { db.Close(); }
        }

        public List<Model> GetAll()
        {
            var db = DatabaseService.getConnection();
            var query = db.CreateCommand();
            query.CommandText = $@"SELECT * FROM {LecturerSchedule.TBL_NAME}";

            var list = new List<Model>();

            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new LecturerSchedule
                    {
                        Id = Convert.ToInt32(reader[LecturerSchedule.COL_ID]),
                        LecturerId = Convert.ToInt32(reader[LecturerSchedule.COL_LECTURER_ID]),
                        SubjCode = reader[LecturerSchedule.COL_SUBJ_CODE].ToString(),
                        RoomCode = reader[LecturerSchedule.COL_ROOM_CODE].ToString(),
                        TimeSlotId = Convert.ToInt32(reader[LecturerSchedule.COL_TIME_SLOT_ID]),
                        ClassId = Convert.ToInt32(reader[LecturerSchedule.COL_CLASS_ID]),
                        SchoolYearTermId = Convert.ToInt32(reader[LecturerSchedule.COL_SY_TERM_ID]),
                        CreatedAt = reader[LecturerSchedule.COL_CREATED_AT].ToString(),
                        UpdatedAt = reader[LecturerSchedule.COL_UPDATED_AT].ToString()
                    });
                }
            }
            db.Close();
            return list;
        }

    }

}
