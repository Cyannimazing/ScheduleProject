using ScheduleProject.data.data;
using ScheduleProject.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.controller
{
    internal class SchoolYearTermController : IController
    {
        public int Create(Model model)
        {
            var db = DatabaseService.getConnection();

            var m = model as models.SchoolYearTerm;

            var query = db.CreateCommand();
            query.CommandText = @"INSERT INTO School_Year_Terms(term_id, school_year, start_date, end_date)
                              VALUES (@term_id, @school_year, @start_date, @end_date);";

            query.Parameters.AddWithValue("@term_id", m.TermId);
            query.Parameters.AddWithValue("@school_year", m.SchoolYear);
            query.Parameters.AddWithValue("@start_date", m.StartDate);
            query.Parameters.AddWithValue("@end_date", m.EndDate);

            try { return query.ExecuteNonQuery(); } catch { return -1; } finally { db.Close(); }
        }

        public List<Model> GetAll()
        {
            var db = DatabaseService.getConnection();
            var query = db.CreateCommand();
            query.CommandText = $@"SELECT * FROM School_Year_Terms syt
                                   INNER JOIN Terms t
                                   ON t.id = syt.term_id;";

            var list = new List<Model>();

            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new SchoolYearTerm
                    {
                        Id = Convert.ToInt32(reader[SchoolYearTerm.COL_ID]),
                        TermId = Convert.ToInt32(reader[SchoolYearTerm.COL_ID]),
                        Term = new Term {
                            Id = Convert.ToInt32(reader[SchoolYearTerm.COL_ID]),
                            Name = reader[Term.COL_NAME].ToString() },
                        SchoolYear = reader[SchoolYearTerm.COL_SCHOOL_YEAR].ToString(),
                        StartDate = reader[SchoolYearTerm.COL_START_DATE].ToString(),
                        EndDate = reader[SchoolYearTerm.COL_END_DATE].ToString(),
                        CreatedAt = reader[SchoolYearTerm.COL_CREATED_AT].ToString(),
                        UpdatedAt = reader[SchoolYearTerm.COL_UPDATED_AT].ToString()
                    });
                }
            }
            db.Close();

            return list;
        }

    }
}
