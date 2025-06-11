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
                for (int j = 8, t = 8; j <= 18; j++, t++)
                {
                    var prefix = "";
                    if (10 > j )
                    {
                        prefix = "0";
                    }
                    TimeSlot timeSlot = new TimeSlot();
                    timeSlot.DayOfWeek = dayOfWeeks[i];
                    timeSlot.Time = prefix + t + ":00 ";
                    Trace.WriteLine(timeSlot.DayOfWeek + " " + timeSlot.Time + " " +  BaseService.Create(Controller.TIME_SLOT, timeSlot));
                    if(j != 18)
                    {
                        TimeSlot timeSlot2 = new TimeSlot();
                        timeSlot2.DayOfWeek = dayOfWeeks[i];
                        timeSlot2.Time = prefix + t + ":30 ";
                        Trace.WriteLine(timeSlot2.DayOfWeek + " " + timeSlot2.Time + " " +  BaseService.Create(Controller.TIME_SLOT, timeSlot2));
                    }
                }
            }
            Trace.WriteLine("Done");
        }
    }

}
