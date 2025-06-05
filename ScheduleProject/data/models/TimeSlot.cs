using ScheduleProject.data.controller;
using ScheduleProject.data.service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.models
{
    public class TimeSlot : Model
    {
        public static string TBL_NAME = "Time_Slots";
        public static string COL_DAY = "day";
        public static string COL_START_TIME = "start_time";
        public static string COL_END_TIME = "end_time";

        public int Id { get; set; }
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public static void TimeSlotSeeder()
        {
            List<string> dayOfWeeks = new List<string>();
            dayOfWeeks.Add("SUNDAY");
            dayOfWeeks.Add("MONDAY");
            dayOfWeeks.Add("TUESDAY");
            dayOfWeeks.Add("WEDNESDAY");
            dayOfWeeks.Add("THURSDAY");
            for (int i = 0; i <dayOfWeeks.Count; i++)
            {
                for (int j = 8; j <= 16; j++)
                {
                    TimeSlot timeSlot = new TimeSlot();
                    timeSlot.DayOfWeek = dayOfWeeks[i];
                    timeSlot.StartTime = j + ":00";
                    timeSlot.EndTime = (j + 1) + ":00";
                    BaseService.Create(BaseService.TIME_SLOT, timeSlot);
                }
            }
            Trace.WriteLine("Done");
        }
    }

}
