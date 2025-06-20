﻿using ScheduleProject.data.controllers;
using ScheduleProject.data.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.models
{
    public class SchoolYearTerm : Model
    {
        public static string TBL_NAME= "School_Year_Terms";
        public static string COL_TERM_ID_SYT = "term_id";
        public static string COL_SCHOOL_YEAR = "school_year";
        public static string COL_START_DATE = "start_date";
        public static string COL_END_DATE = "end_date";

        public int TermId { get; set; }
        public Term Term { get; set; }
        public string SchoolYear { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public static void SchoolYearTermSeeder()
        {

        }
    }


}
