using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleProject.data.models
{
    public class Room : Model
    {
        public static string TBL_NAME = "Rooms";
        public static string COL_NAME = "name";

        public int Id { get; set; }
        public string Name { get; set; }

        public static Room RoomSeeder()
        {
            return new Room
            {
                Name = "Room A101"
            };
        }
    }


}
