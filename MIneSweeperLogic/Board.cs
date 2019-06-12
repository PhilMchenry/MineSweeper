using System.Collections.Generic;

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

    public class BoardResults
    {
   
        public BoardResults(string text, bool vHorizontal, bool vVertical, bool vMove)
        {
            Text = text;
            ValidHorizontal = vHorizontal;
            ValidVertical = vVertical;
            ValidMove = vMove;
        }


        public string Text { get; }
        public bool ValidHorizontal { get; } = false;
        public bool ValidVertical { get; } = false;
        public bool ReachedTheEnd { get; set; }
        public bool ValidMove { get; } = false;
        public bool HitAMine { get; set; }
    }
}
