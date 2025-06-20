﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.models
{
    public class ProgramSubject : Model
    {
        public static string TBL_NAME = "Program_Subjects";
        public static string COL_PROG_CODE = "prog_code";
        public static string COL_SUBJ_CODE = "subj_code";
        public static string COL_PROG_NAME = "prog_name";
        public static string COL_SUBJ_NAME = "subj_name";
        public static string COL_YEAR_LEVEL = "year_level";
        public static string COL_TERM_ID = "term_id";

        public string ProgCode { get; set; }
        public Program Program { get; set; }

        public string SubjCode { get; set; }
        public Subject Subject { get; set; }
        public List<Subject> Subjects { get; set; }

        public string YearLevel {  get; set; }

        public int TermId { get; set; }
        public Term Term{ get; set; }

        public static ProgramSubject ProgramSubjectSeeder()
        {
            return new ProgramSubject
            {
                ProgCode = "BSCS",
                SubjCode = "CS101"
            };
        }
    }

}
