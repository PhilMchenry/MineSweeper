using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperLogic
{
    public interface IPlayer
    {


        int NoOfLives { get; }
        int NoOfMoves { get; }

        IPosition CurrentPosition { get; }

        void MovePositionLeft();
        void MovePositionRight();
        void MovePositionUp();
        void MovePositionDown();

        event EventHandler playerEvent;

    }
}
