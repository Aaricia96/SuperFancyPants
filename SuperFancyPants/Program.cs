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
                    case "look":
                        {
                            game.LookAround();
                            break;
                        }
                    case "stop":
                        {
                            alive = false;
                            break;
                        }
                    case "help":
                        {
                            PrintHelp();
                            break;
                        }
                    default:
                        {
                            PrintFalseCommand();
                            PrintHelp();
                            break;
                        }
                }


            }

            game.End();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }

        private static void PrintFalseCommand()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("Please insert a valid command.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintHelp()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("Available command are: look, move, help and stop.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintFalseDirection()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("Please insert a valid direction!");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
