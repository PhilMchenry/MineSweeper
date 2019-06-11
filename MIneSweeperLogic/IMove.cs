using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperLogic
{
    public interface IMove
    {

        IPosition MoveLeft(IPosition currentPosition);
        IPosition MoveRight(IPosition currentPosition);
        IPosition MoveUp(IPosition currentPosition);
        IPosition MoveDown(IPosition currentPosition);
    }
}
