using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperLogic
{
    public class Game : IGame
    {
            public Game()
        {
            //Game is a 8X8 square
            board = new Board(GenerateHorizontalArray.HorizontalChessArray(8),8, numberOfMines);

            var startPosition = new Position(0, 1);

            player = new Player(this, new NormalMove(), startPosition, numberOfLives);

            //Attach event handler
            player.playerEvent += HandlePlayerEvent;

        }


        public IBoard board { get; }

        public IPlayer player { get;  }

        private const int numberOfLives = 3;
        private const int numberOfMines = 3;

        public void HandlePlayerEvent(object sender, EventArgs e)
        {
            PlayerEvents playerEvents = (PlayerEvents)e;

            
            Console.WriteLine(playerEvents.resultMessage);
            Console.WriteLine("Moves " + playerEvents.numberOfMoves.ToString());
            Console.WriteLine("CurrentPosition " + playerEvents.resultPosition);
            Console.WriteLine("Number Of Lives " + playerEvents.numberOfLives.ToString());

        }

    }
}
