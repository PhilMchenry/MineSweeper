using System.Collections.Generic;
using MineSweeperLogic.Interfaces;

namespace MineSweeperLogic
{
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
    }
}
