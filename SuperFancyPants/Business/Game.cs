using SuperFancyPants.Domain;
using SuperFancyPants.Domain.Enum;
using System;

namespace SuperFancyPants.Business
{
    public class Game
    {
        private Room _currentRoom;

        public string Name { get; private set; }

        public void StartGame()
        {
            SetUp();

            Initialize();

            //Start();
        }

        private void SetUp()
        {
            var entrance = new Room { Description = "I hope there aren't any creepy things inside this house.", Name = "entrance" };
            var livingRoom = new Room { Description = "Come along, Pond.", Name = "living room" };
            var diner = new Room { Description = "Geronimo!", Name = "diner" };
            var kitchen = new Room { Description = "Let's have some fish with custard.", Name = "kitchen" };
            var hallway = new Room { Description = "We've moved up the stairs.", Name = "hallway" };
            var bedRoom = new Room { Description = "Bowties are cool.", Name = "bedroom" };

            entrance.ConnectedRooms.Add(EDirection.North, livingRoom);

            livingRoom.ConnectedRooms.Add(EDirection.South, entrance);
            livingRoom.ConnectedRooms.Add(EDirection.Up, hallway);
            livingRoom.ConnectedRooms.Add(EDirection.East, diner);         

            diner.ConnectedRooms.Add(EDirection.North, kitchen);
            diner.ConnectedRooms.Add(EDirection.West, livingRoom);

            kitchen.ConnectedRooms.Add(EDirection.South, diner);

            hallway.ConnectedRooms.Add(EDirection.Down, livingRoom);
            hallway.ConnectedRooms.Add(EDirection.East, bedRoom);

            bedRoom.ConnectedRooms.Add(EDirection.West, hallway);

            _currentRoom = entrance;
        }

        private void Initialize()
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("SUPER FANCY PANTS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("");

            SetName();
        }

        private void SetName()
        {
            while(string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Hello player, what is your name?");
                Name = Console.ReadLine();
            }

            DateTime date = DateTime.Now;

            Console.WriteLine("");
            Console.WriteLine($"Welcome {Name}! It is {date} and we are ready to start this epic game.");
        }

        public void PrintName()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{Name} ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DescribeLocation()
        {
            Console.WriteLine("");
            Console.WriteLine($"You are currently in {_currentRoom.Name}.");
            Console.WriteLine($"{_currentRoom.Description}");
            Console.WriteLine("");
        }

        public void Move(EDirection direction)
        {
            if (_currentRoom.ConnectedRooms.ContainsKey(direction))
            {
                _currentRoom = _currentRoom.ConnectedRooms[direction];
            }
            else
            {
                Console.WriteLine($"Cannot move to {direction}. Choose another direction.");
            }
        }
        public void LookAround()
        {
            _currentRoom.PrintInfo();
        }

        public void End()
        {
            Console.WriteLine("");
            Console.WriteLine("You died.");
        }

    }
}
