using SuperFancyPants.Business;
using SuperFancyPants.Domain.Enum;
using System;

namespace SuperFancyPants
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            var alive = true;

            game.StartGame();

            while(alive)
            {
                game.DescribeLocation();

                game.PrintName();
                var input = Console.ReadLine();
                string action = "";
                string arguments = "";
                if(input.Contains(" "))
                {
                    action = input.Split(" ")[0];
                    arguments = input.Split(" ")[1];
                } else
                {
                    action = input;
                }

                switch(action.ToLower())
                {
                    case "move":
                        {
                            EDirection direction;
                            if (Enum.TryParse<EDirection>(arguments, true, out direction))
                            {
                                game.Move(direction);
                            }
                            else
                            {
                                PrintFalseDirection();
                            }
                            break;
                        }
                }
            }
        }
        private static void PrintFalseDirection()
        {
            Console.WriteLine("Please insert a valid direction!");
        }

    }
}
