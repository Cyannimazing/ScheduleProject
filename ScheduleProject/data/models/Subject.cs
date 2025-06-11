using ScheduleProject.data.controllers;
using ScheduleProject.data.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.models
{
    public class Subject : Model
    {
        public static string TBL_NAME = "Subjects";
        public static string COL_CODE = "code";
        public static string COL_NAME = "name";
        public static string COL_UNIT = "unit";
        public static string COL_IS_GEN_ED = "is_gen_ed";

        public string Code { get; set; }
        public string Name { get; set; }
        public short Unit { get; set; } = 3;
        public bool IsGenEd { get; set; } = false;

        public List<ProgramSubject> ProgramSubjects { get; set; }
        public List<LecturerSubject> LecturerSubjects { get; set; }

        public static void SubjectSeeder()
        {
            List<Subject> subjectLists = new List<Subject>();
            subjectLists.Add(new Subject
            {
                Code = "BTEA 1101",
                Name = "Technical Communication",
                Unit = 0,
                IsGenEd = true,
            });
            subjectLists.Add(new Subject
            {
                Code = "BTEA 1102",
                Name = "Soft Skills I",
                Unit = 0,
                IsGenEd = true,
            });
            subjectLists.Add(new Subject
            {
                Code = "MATH 1610",
                Name = "Engineering Mathematics I",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 1001",
                Name = "Introduction to Automotive Technology",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "MECH 1404",
                Name = "Thermofluids",
                Unit = 0,
                IsGenEd = false,    
            });
            subjectLists.Add(new Subject
            {
                Code = "MECH 1206",
                Name = "Fundamental of Engineering Mechanics",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "MECH 1502",
                Name = "Engineering Drawing",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "MECH 1502",
                Name = "Engineering Drawing",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "BTEA 1202",
                Name = "Oman Islamic and Civilization",
                Unit = 0,
                IsGenEd = true,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 1201",
                Name = "Fundamental of Electrical & Electronics",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 1101",
                Name = "Fundamental of Internal Combustion Engine",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "MECH 1606",
                Name = "Materials & Processes",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "MECH 1802",
                Name = "Engineering Workshop",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "MECH 1808",
                Name = "Engineering Lab",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "BUSS 2320",
                Name = "Entrepreneurship for Engineers",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "BTEA 2101",
                Name = "Work Ethics",
                Unit = 0,
                IsGenEd = true,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 2301",
                Name = "Transmission Systems I",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO2401",
                Name = "Chassis Structure & Suspension System",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 2501",
                Name = "Petrol Engine Fuel System",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 2102",
                Name = "Internal Combustion Engine I",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 2202",
                Name = "Automotive Electrical Sys I",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 2602",
                Name = "Heating & AC Systems",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "BTEA 2201",
                Name = "Professional Communication",
                Unit = 0,
                IsGenEd = true,
            });
            subjectLists.Add(new Subject
            {
                Code = "BTEA 2202",
                Name = "German Lang. 1",
                Unit = 0,
                IsGenEd = true,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 2801",
                Name = "Automotive Workshop Technology",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 2203",
                Name = "Ignition System",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 2502",
                Name = "Diesel Engine Fuel Systems",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 2402",
                Name = "Braking & Tire System",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "MECH 2504",
                Name = "Engineering Drawing II",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "OJT 1",
                Name = "Industry Enhancement Program (Summer)",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "OJT 2",
                Name = "Industry Enhancement Program (Summer)",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 3901",
                Name = "Project I",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 3302",
                Name = "Transmission System II",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 3103",
                Name = "Internal Combustion Engine II",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 3204",
                Name = "Automotive Electrical Systems II",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 3405",
                Name = "Vehicle Dynamics",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "ENGR 3102",
                Name = "Product Design & Innovation",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "BTEA 3201",
                Name = "Entrepreneurship/Technopreneurship",
                Unit = 0,
                IsGenEd = true,
            });
            subjectLists.Add(new Subject
            {
                Code = "BTEA 3202",
                Name = "German Lang. 2",
                Unit = 0,
                IsGenEd = true,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 2404",
                Name = "Body Work and Repair",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 2601",
                Name = "Automotive Comfort & Safety System",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 2403",
                Name = "Steering & Wheel Alignment",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 3002",
                Name = "Vehicle Maintenance",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 3902",
                Name = "Project II",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 3701",
                Name = "Vehicle Performance & Diagnosis",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 3104",
                Name = "Advance Engine Technology",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 3003",
                Name = "Heavy Vehicles",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 3503",
                Name = "Advance Feul System",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "MECH 4701",
                Name = "Engineering Management, Safe & Economics",
                Unit = 0,
                IsGenEd = false,
            });
            subjectLists.Add(new Subject
            {
                Code = "AUTO 3802",
                Name = "Industrial Training",
                Unit = 4,
                IsGenEd = false,
            });

            foreach(var subject in subjectLists)
            {
                BaseService.Create(Controller.SUBJECT, subject);
            }
        }
    }
}
