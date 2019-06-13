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

    /// <summary>
    /// A player has a game, boardrules that apply to a board and a way to move and GameRules on how to react.
    ///A player is also responsible for implementing board rules and game rules that are started with its movement.
    ///The player will also know the number of lives and number of moves.
    /// </summary>
    public class Player : IPlayer
    {
       
        private readonly IMove move;
        private IPosition currentPosition;
        private int numberOfMoves;
        private int numberOfLives;
        private readonly IBoardRules boardRules;
        private readonly IGameRules playerReaction;
        public Position ResetPosition { get; internal set; }

        //Player events so it can be subscribed to
        public delegate void PlayerEventHandler(object sender, PlayerEvents e);

        public event EventHandler PlayerEvent;

        public Player( IMove move, IPosition startPosition,
            int lives, IBoardRules boardRules, IGameRules playerReaction)
        {
            
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
            return boardRules.BoardHorizontalConvertArray[CurrentPosition.Horizontal] + currentPosition.Vertical.ToString();
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
            //Apply Game Rules
            var playerEvents = playerReaction.ApplyGameRules(result, this);
            //Tell whoever is listening what my state is.
            if (PlayerEvent != null) PlayerEvent(this, playerEvents);
        }
    }
}
