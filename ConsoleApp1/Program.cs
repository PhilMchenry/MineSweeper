using System;
using MineSweeperLogic;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minesweeper");
            Console.WriteLine("Use the arrow keys only to navigate and esc to quit");
            Console.WriteLine("You are on 8x8 board starting from bottom left corner");
            Console.WriteLine("Good luck!");



            //Create the Game
            var theGame = new Game();


            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                var input = Console.ReadKey();

                if (input.Key == ConsoleKey.UpArrow)
                {
                    theGame.player.MovePositionUp();
                }
                else if (input.Key == ConsoleKey.DownArrow)
                {
                    theGame.player.MovePositionDown();
                }
                else if (input.Key == ConsoleKey.LeftArrow)
                {
                    theGame.player.MovePositionLeft();
                }
                else if (input.Key == ConsoleKey.RightArrow)
                {
                    theGame.player.MovePositionRight();
                }
                else if (input.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid key");
                }
            }

        }




    }
}
