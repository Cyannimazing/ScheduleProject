using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.models
{
    public class LecturerSchedule : Model
    {
        public static string TBL_NAME = "Lecturer_Schedules";
        public static string COL_LECTURER_ID = "lecturer_id";
        public static string COL_SUBJ_CODE = "subj_code";
        public static string COL_ROOM_CODE = "room_code";
        public static string COL_TIME_SLOT_ID = "time_slot_id";
        public static string COL_CLASS_ID = "class_id";
        public static string COL_SY_TERM_ID = "sy_term_id";

        public int Id { get; set; }
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
        public string SubjCode { get; set; }
        public Subject Subject { get; set; }
        public string RoomCode { get; set; }
        public Room Room { get; set; }
        public int ClassId { get; set; }
        public ClassGroup ClassGroup { get; set; }
        public int TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public int SchoolYearTermId { get; set; }
        public SchoolYearTerm SchoolYearTerm { get; set; }

        public static LecturerSchedule LecturerScheduleSeeder()
        {
            return new LecturerSchedule
            {
                LecturerId = 1,
                SubjCode = "CS101",
                RoomCode = "Room A101",
                ClassId = 1,
                TimeSlotId = 2,
                SchoolYearTermId = 1
            };
        }
    }

}
