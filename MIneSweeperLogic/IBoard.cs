using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperLogic
{
    public interface IBoard
    {

        bool IsThisPositionAMine(IPosition position);

        string[] HorizontalArray { get; }

        int VerticalAxis { get; }

        BoardResults IsThisPositionValid(IPosition position);

        int NumberOfMines { get; }
    }
}
