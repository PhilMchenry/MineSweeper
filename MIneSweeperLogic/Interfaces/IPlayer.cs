using System;

namespace MineSweeperLogic.Interfaces
{
    public interface IPlayer
    {
        int NoOfLives { get; }
        int NoOfMoves { get; }

        IPosition CurrentPosition { get; }

        void ProcessKeyStroke(string keyPress);

        event EventHandler PlayerEvent;

        IGame MyGame { get; }

        string FriendlyPosition();
        void AddMove();
        void RemoveLive();
        void ResetPosition();
    }
}
