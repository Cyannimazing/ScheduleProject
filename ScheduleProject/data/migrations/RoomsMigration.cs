using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.migration
{
    internal class RoomsMigration
    {
        public static string CreateTable()
        {
            return @"CREATE TABLE IF NOT EXISTS Rooms (
                    id INTEGER PRIMARY KEY,
                    name TEXT UNIQUE NOT NULL
                );";
        }
    }
}
