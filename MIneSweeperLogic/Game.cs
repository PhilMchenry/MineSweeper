using System;
using System.ComponentModel.Design;
using MineSweeperLogic.Interfaces;

namespace MineSweeperLogic
{
    public class Game : IGame
    {


        //Game Constants
        private const int numberOfLives = 3;
        private const int numberOfMines = 30;
        private const int xAxisSize = 8;
        private const int yAxisSixe = 8;

        public Game()
        {
            //Create Dependencies
            //Generate Mines
            var generateMines = new GenerateMines(xAxisSize,yAxisSixe);
            //Game is a 8X8 square and has a set of mines
            Board = new Board(GenerateHorizontalArray.HorizontalChessArray(xAxisSize), yAxisSixe, generateMines.GenerateMineLocation(numberOfMines));
            //Start Position of Player
            var startPosition = new Position(0, 1);
            //Create player with the game, a way to move, startposition, numberoflives, board, boardrules and a reaction
            Player = new Player(this, new Move(), startPosition, numberOfLives, new BoardRules(Board),new PlayerReaction());

            //Attach event handler
            Player.PlayerEvent += HandlePlayerEvent;

        }


        public IBoard Board { get; }

        public IPlayer Player { get;  }
        public bool GameOver { get; internal set; }

        public void HandlePlayerEvent(object sender, EventArgs e)
        {
            PlayerEvents playerEvents = (PlayerEvents)e;

            if (playerEvents.GameOver)
            {
                //Check for GameOver
                GameOver = playerEvents.GameOver;
                Console.WriteLine("Game Over because " + playerEvents.resultMessage);
                Console.WriteLine("Final Score " + playerEvents.numberOfMoves.ToString());
                Console.WriteLine("CurrentPosition " + playerEvents.resultPosition);
                Console.WriteLine("Number Of Lives " + playerEvents.numberOfLives.ToString());
            }
            else
            {
                Console.WriteLine("Last Message " + playerEvents.resultMessage);
                Console.WriteLine("Moves " + playerEvents.numberOfMoves.ToString());
                Console.WriteLine("CurrentPosition " + playerEvents.resultPosition);
                Console.WriteLine("Number Of Lives " + playerEvents.numberOfLives.ToString());
            }
        }
    }
}
