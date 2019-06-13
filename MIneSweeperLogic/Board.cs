using System.Collections.Generic;
using MineSweeperLogic.Interfaces;

namespace MineSweeperLogic
{
    /// <summary>
    /// A board has a size, some mines and a Horizontal axis reference. Is also responsible for removing it's own mines.
    /// </summary>
    public class Board : IBoard
    {
        public Board(string[] xAxisArray, int yAxis, List<IPosition> mineLocation)
        {
           
            HorizontalArray = xAxisArray;
            VerticalAxis = yAxis;

            MinePositions = mineLocation;
        }
        public string[] HorizontalArray { get; }
        public int VerticalAxis { get; }

        public int NumberOfMines {
            get {

                if (MinePositions is null)
                {
                    return 0;
                }
                else
                {
                    return MinePositions.Count;
                }
            }
        }
        public List<IPosition> MinePositions { get; }
        public void RemoveMine(IPosition currentPosition)
        {
            MinePositions.Remove(currentPosition);
        }
    }
}
