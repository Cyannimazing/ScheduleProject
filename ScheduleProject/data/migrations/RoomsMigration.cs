﻿using System;
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
                    name TEXT UNIQUE NOT NULL,
                    created_at TEXT DEFAULT CURRENT_TIMESTAMP,
                    updated_at TEXT DEFAULT CURRENT_TIMESTAMP);

                CREATE TRIGGER IF NOT EXISTS update_room
                AFTER UPDATE ON Rooms
                BEGIN
                    UPDATE Rooms SET updated_at = CURRENT_TIMESTAMP WHERE id = NEW.id;
                END;
";
        }
    }
}
