using System.Collections.Generic;

namespace MineSweeperLogic.Interfaces
{
    public interface IBoard
    {

        string[] HorizontalArray { get; }

        int VerticalAxis { get; }

        int NumberOfMines { get; }

        List<IPosition> MinePositions { get; }
        void RemoveMine(IPosition currentPosition);
    }
}
