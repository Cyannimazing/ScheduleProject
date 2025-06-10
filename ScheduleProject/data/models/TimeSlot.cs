using ScheduleProject.data.controller;
using ScheduleProject.data.controllers;
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
        public static string COL_TIME = "time";

        public int Id { get; set; }
        public string DayOfWeek { get; set; }
        public string Time { get; set; }

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
                var suffix = "am";
                for (int j = 8, t = 8; j <= 18; j++, t++)
                {
                    if (10 < j && j < 1)
                    {
                        suffix = "nn";
                    }if(14 > j && j > 12)
                    {
                        t = 1;
                        suffix = "pm";
                    }
                    TimeSlot timeSlot = new TimeSlot();
                    timeSlot.DayOfWeek = dayOfWeeks[i];
                    timeSlot.Time = t + ":00 " + suffix;
                    Trace.WriteLine(timeSlot.DayOfWeek + " " + timeSlot.Time + " " +  BaseService.Create(Controller.TIME_SLOT, timeSlot));
                    if(j != 18)
                    {
                        TimeSlot timeSlot2 = new TimeSlot();
                        timeSlot2.DayOfWeek = dayOfWeeks[i];
                        timeSlot2.Time = t + ":30 " + suffix;
                        Trace.WriteLine(timeSlot2.DayOfWeek + " " + timeSlot2.Time + " " +  BaseService.Create(Controller.TIME_SLOT, timeSlot2));
                    }
                }
            }
            Trace.WriteLine("Done");
        }
    }

}
