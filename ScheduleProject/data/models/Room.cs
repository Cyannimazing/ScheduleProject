using ScheduleProject.data.controllers;
using ScheduleProject.data.service;
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

        public string Name { get; set; }

        public static void RoomSeeder()
        {
            string[] rooms =
            {
                "GMC", "JAGUAR", "BMW", "SUZUKI", "Volvo", "Mitsubishi", "Volkswagen", "Nissan"
            };
            for (int i = 0; i < rooms.Length; i++)
            {
                BaseService.Create(Controller.ROOM, new Room
                {
                    Name = rooms[i],
                });
            }
        }
    }


}
