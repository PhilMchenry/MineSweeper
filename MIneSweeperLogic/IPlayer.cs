using System;

namespace MineSweeperLogic
{
    public interface IPlayer
    {


        int NoOfLives { get; }
        int NoOfMoves { get; }

        IPosition CurrentPosition { get; }

        void ProcessKeyStroke(string keyPress);

        event EventHandler playerEvent;

    }
}
