using System;
using MineSweeperLogic.Interfaces;

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
       
        private readonly IMove move;
        private IPosition currentPosition;
        private int numberOfMoves;
        private int numberOfLives;
        private readonly IBoardRules boardRules;
        private readonly IReact playerReaction;
        public Position ResetPosition { get; internal set; }

        //Player events so it can be subscribed to
        public delegate void PlayerEventHandler(object sender, PlayerEvents e);

        public event EventHandler PlayerEvent;
        public IGame MyGame { get; }

        public Player(IGame game, IMove move, IPosition startPosition,
            int lives, IBoardRules boardRules, IReact playerReaction)
        {
            this.MyGame = game;
            this.move = move;

            numberOfLives = lives;
            this.boardRules = boardRules;
            this.playerReaction = playerReaction;
            currentPosition = startPosition;
        }

        public int NoOfLives => numberOfLives;

        public int NoOfMoves => numberOfMoves;

        public IPosition CurrentPosition => currentPosition;

        public string FriendlyPosition()
        {
            return MyGame.Board.HorizontalArray[CurrentPosition.Horizontal] + currentPosition.Vertical.ToString();
        }

        public void AddMove()
        {
            numberOfMoves++;
        }

        public void RemoveLive()
        {
            numberOfLives--;
        }

        void IPlayer.ResetPosition()
        {
            currentPosition = ResetPosition;
        }

        public void ProcessKeyStroke(string keyPress)
        {
            //Copy current Position
            ResetPosition = new Position(currentPosition.Horizontal, currentPosition.Vertical);
            //Perform Move
            var proposedPosition = move.ProcessKeyStroke(keyPress,currentPosition);
            //What was board result
            var result = boardRules.ProcessRules(proposedPosition);
            //Calculate player reaction
            var playerEvents = playerReaction.PlayerReact(result, this);
            //Tell whoever is listening what my state is.
            if (PlayerEvent != null) PlayerEvent(this, playerEvents);
        }
    }
}
