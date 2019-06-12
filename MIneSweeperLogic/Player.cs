using System;

namespace MineSweeperLogic
{

    public class PlayerEvents : EventArgs
    {
        public int numberOfMoves;
        public string resultMessage;
        public string resultPosition;
        public int numberOfLives;
        public bool GameOver;
    }


    public class Player : IPlayer
    {
        private readonly IGame game;
        private readonly IMove move;
        private IPosition currentPosition;
        private int numberOfMoves;
        private int numberOfLives;
        private readonly IBoardRules boardRules;

        //Player events so it can be subscribed to
        public delegate void PlayerEventHandler(object sender, PlayerEvents e);

        public event EventHandler playerEvent;

        public Player(IGame game, IMove move, IPosition startPosition, int lives, IBoardRules boardRules)
        {
            this.game = game;
            this.move = move;

            numberOfLives = lives;
            this.boardRules = boardRules;
            currentPosition = startPosition;
        }

        public int NoOfLives => numberOfLives;

        public int NoOfMoves => numberOfMoves;

        public IPosition CurrentPosition => currentPosition;

        //Player Behaviour - Check board rules and applies to it's own state.
        void PlayerMove(IPosition origPosition, IPosition proposedPosition)
        {
            var result = boardRules.ProcessRules(proposedPosition);
            //Can I Move, if so increase number of moves
            if (result.ValidMove)
            {
                numberOfMoves++;
                //Did I hit a mine? If  so lose a life
                if (result.HitAMine)
                {
                    numberOfLives--;
                }
            }
            else
            {//Stay where I am.
                currentPosition = origPosition;
            }
            //Tell whoever is listening what my state is.
            if (playerEvent != null) playerEvent(this, CreateMyCurrentState(result));
        }

       

        PlayerEvents CreateMyCurrentState(BoardResults result)
        {

            var currentState = new PlayerEvents
            {
                numberOfLives = numberOfLives, numberOfMoves = numberOfMoves, resultMessage = result.Text
            };
            //Check if you still have lives or have reached the end
            if (
                numberOfLives == 0)
            {
                currentState.resultPosition = "Out of Lives Ouch";
                currentState.GameOver = true;
            }
            else if (result.ReachedTheEnd)
                {
                currentState.resultPosition = "You have made it safely out";
                currentState.GameOver = true;
            }
            else
            {
                if (result.HitAMine)
                {
                    currentState.resultPosition += "You Hit A Mine! ";
                }
                currentState.resultPosition += "Position " +
            game.Board.HorizontalArray[CurrentPosition.Horizontal] + CurrentPosition.Vertical.ToString();
                currentState.GameOver = false;
            }

            return currentState;
        }

     

      


        public void ProcessKeyStroke(string keyPress)
        {

            var origPosition = new Position(currentPosition.Horizontal, currentPosition.Vertical);

            var proposedPosition = move.ProcessKeyStroke(keyPress,currentPosition);

            PlayerMove(origPosition, proposedPosition);

        }
    }
}
