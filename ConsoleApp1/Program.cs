using System;
using MineSweeperLogic;

namespace MineSweeperConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minesweeper");
            Console.WriteLine("Use the arrow keys only to navigate and esc to quit");
            //Create the Game
            var theGame = GenerateGame.GenerateAGame(8,8,50,3,0,1);
            Console.WriteLine("You are on " +theGame.Board.HorizontalArray.Length.ToString()+"x"+
                              theGame.Board.VerticalAxis.ToString() + " board starting from " +
                              theGame.Board.HorizontalArray[theGame.Player.CurrentPosition.Horizontal] +
                              theGame.Player.CurrentPosition.Vertical.ToString());

            Console.WriteLine("Good luck!");
            Console.WriteLine("Oh and there are " + theGame.Board.NumberOfMines.ToString() + " mines");


            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                var input = Console.ReadKey();


                //Check for Game Over
                if (theGame.GameOver)
                {
                    Console.WriteLine("Game Over");
                    break;}

                if (input.Key == ConsoleKey.UpArrow || input.Key == ConsoleKey.DownArrow || input.Key == ConsoleKey.LeftArrow || input.Key == ConsoleKey.RightArrow)
                {
                    theGame.Player.ProcessKeyStroke(input.Key.ToString());
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
