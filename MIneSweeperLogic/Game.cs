using System;
using System.ComponentModel.Design;
using MineSweeperLogic.Interfaces;

namespace MineSweeperLogic
{
    /// <summary>
    /// A game consists of a board and a player. The game listens to events from the player.
    /// The GenerateGame static class is creating the dependencies, could use a IOC container but felt overkill for this.
    /// </summary>
    public class Game : IGame
    {
        public Game(IBoard board, IPlayer player)
        {
            Board = board;
            Player = player;
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
                GameOver = true;
                Console.WriteLine("Game Over because " + playerEvents.resultMessage);
                Console.WriteLine("Final Score " + playerEvents.numberOfMoves.ToString());
                Console.WriteLine("CurrentPosition " + playerEvents.resultPosition);
                Console.WriteLine("Number Of Lives " + playerEvents.numberOfLives.ToString());
            }
            else
            {
                GameOver = false;
                Console.WriteLine("Last Message " + playerEvents.resultMessage);
                Console.WriteLine("Moves " + playerEvents.numberOfMoves.ToString());
                Console.WriteLine("CurrentPosition " + playerEvents.resultPosition);
                Console.WriteLine("Number Of Lives " + playerEvents.numberOfLives.ToString());
            }
        }
    }
}
