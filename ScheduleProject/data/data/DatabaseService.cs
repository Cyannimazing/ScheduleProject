using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using System.Data.SQLite;
using ScheduleProject.data.migration;
using ScheduleProject.data.models;

namespace ScheduleProject.data.data
{
    internal class DatabaseService
    {
        private static SQLiteConnection CONNECTION;
        private const string DB_NAME = "faculty_loading.db";
        private SQLiteConnection _connection;
        public DatabaseService() 
        { 
            CreateTable();
        }

        public static SQLiteConnection getConnection()
        {
            if(CONNECTION == null)
            {
                CONNECTION = new SQLiteConnection($"Data Source={DB_NAME}");
            }

            CONNECTION.Open();

            using (var pragma = CONNECTION.CreateCommand())
            {
                pragma.CommandText = "PRAGMA foreign_keys = ON;";
                pragma.ExecuteNonQuery();
            }

            return CONNECTION;
        }

        private void CreateTable()
        {
            _connection = getConnection();

            var query = _connection.CreateCommand();

            query.CommandText = @"" +
                ProgramsMigration.CreateTable()
                + TermsMigration.CreateTable()
                + ProgramSubjectsMigration.CreateTable()
                + LecturersMigration.CreateTable()
                + ClassesMigration.CreateTable()
                + RoomsMigration.CreateTable()
                + TimeSlotsMigration.CreateTable()
                + SubjectsMigration.CreateTable()
                + LecturerSubjectsMigration.CreateTable()
                + SchoolYearTermsMigration.CreateTable()
                + LecturerSchedulesMigration.CreateTable()
                ;

            query.ExecuteNonQuery();
            _connection.Close();
        }

        public static SQLiteCommand createQuery(string sqlQuery, SQLiteConnection db)
        {
            var query = db.CreateCommand();
            query.CommandText = sqlQuery;
            return query;
        }
    }
}
