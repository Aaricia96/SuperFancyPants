using SuperFancyPants.Domain.Enum;
using System;
using System.Collections.Generic;

namespace SuperFancyPants.Domain
{
    public class Room
    {
        public IDictionary<EDirection, Room> ConnectedRooms = new Dictionary<EDirection, Room>();

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Finish { get; set; }

        public bool MonsterAppearing { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Currently in {Name}");
            Console.Write($"Possible directions are: ");

            foreach (var connectedRoomsKey in ConnectedRooms.Keys)
            {
                Console.Write($"{connectedRoomsKey:G} ");
            }
            Console.Write(Environment.NewLine);
        }
    }
}
