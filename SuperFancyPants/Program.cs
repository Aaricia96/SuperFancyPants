using SuperFancyPants.Business;
using SuperFancyPants.Domain.Enum;
using SuperFancyPants.Domain.Interface;
using System;

namespace SuperFancyPants
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            var alive = true;
            var won = false;

            game.StartGame();

            while(alive)
            {
                if (game.ShouldEnd())
                {
                    won = true;
                    break;
                }
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
                                game.DescribeLocation();
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

                if (game.MonsterNeeded())
                {
                    IMonster monster = game.CreateMonster();
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{monster.PrintMessage()}");
                    Console.WriteLine("");
                    Console.WriteLine($"What should you do know to fight the {monster.Name}?");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;

                    game.PrintName();
                    var fightMethod = Console.ReadLine();
                    if(!fightMethod.ToLower().Equals(monster.Reaction))
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"This was not a proper response to the {monster.Name}.");
                        Console.ForegroundColor = ConsoleColor.White;
                        alive = false;
                    } else
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You can now fight this horrible creature.");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.White;

                        game.PrintName();
                        if(Console.ReadLine().Equals("fight"))
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"The {monster.Name} was beaten.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"You should've fought against the {monster.Name}");
                            Console.ForegroundColor = ConsoleColor.White;
                            alive = false;
                        }
                    }
                }

            }

            if (!won)
            {
                game.End();
            } else
            {
                game.Won();
            }
            

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
