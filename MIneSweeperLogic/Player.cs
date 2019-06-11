using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperLogic
{

    public class PlayerEvents : EventArgs
    {
        public int numberOfMoves;
        public string resultMessage;
        public string resultPosition;
        public int numberOfLives;
    }


    public class Player : IPlayer
    {
        private readonly IGame game;
        private readonly IMove move;
        private IPosition currentPosition;
        private int numberOfMoves;
        private int numberOfLives;


        public delegate void PlayerEventHandler(object sender, PlayerEvents e);

        public event EventHandler playerEvent;

        public Player(IGame game, IMove move, IPosition startPosition, int lives)
        {
            this.game = game;
            this.move = move;

            numberOfLives = lives;
            currentPosition = startPosition;
        }

        private string intMessage;
        public string Message { get => intMessage; }


        public int NoOfLives { get => numberOfLives; }

        public int NoOfMoves
        {
            get
            {
                return numberOfMoves;
            }
        }
       

        public IPosition CurrentPosition
        {
            get 
            {
                return currentPosition;
            }
        }


        void UpdateInternalMove(IPosition origPosition, IPosition proposedPosition)
        {
            var result = game.board.IsThisPositionValid(proposedPosition);

            if (result.ValidMove)
            {
                numberOfMoves++;

            }
            else
            {
                currentPosition = origPosition;
            }

            playerEvent(this, CreateMyCurrentState(result));
        }

        public void MovePositionDown()
        {
            var origPosition = new Position(currentPosition.Horizontal, currentPosition.Vertical);
          
            var proposedPosition = move.MoveDown(currentPosition);

            UpdateInternalMove(origPosition, proposedPosition);

        }

        PlayerEvents CreateMyCurrentState(BoardResults result)
        {

            var currentState = new PlayerEvents();
            currentState.numberOfLives = numberOfLives;
            currentState.numberOfMoves = numberOfMoves;
            currentState.resultMessage = result.Text;
            //Check if you have won
            if (result.YouHaveWon)
                {
                currentState.resultPosition = "You have made it safely out";
            }
            else
            {
                currentState.resultPosition = "Position " +
            game.board.HorizontalArray[CurrentPosition.Horizontal] + CurrentPosition.Vertical.ToString();

            }

            return currentState;
        }

        public void MovePositionLeft()
        {
            var origPosition = new Position(currentPosition.Horizontal, currentPosition.Vertical);

            var proposedPosition = move.MoveLeft(currentPosition);

            UpdateInternalMove(origPosition, proposedPosition);
        }

        public void MovePositionRight()
        {
            var origPosition = new Position(currentPosition.Horizontal, currentPosition.Vertical);

            var proposedPosition = move.MoveRight(currentPosition);

            UpdateInternalMove(origPosition, proposedPosition);
        }

        public void MovePositionUp()
        {
            var origPosition = new Position(currentPosition.Horizontal, currentPosition.Vertical);

            var proposedPosition = move.MoveUp(currentPosition);

            UpdateInternalMove(origPosition, proposedPosition);
        }
    }
}
