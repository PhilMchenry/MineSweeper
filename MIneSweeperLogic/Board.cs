using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperLogic
{
    public class Board : IBoard
    {
        public Board(string[] XAxisArray, int YAxis, int numberOfMines)
        {
            intHorizontalArray = XAxisArray;
            intVerticalAxis = YAxis;
           
           

        }
        public string[] HorizontalArray { get => intHorizontalArray; }

        private int intVerticalAxis;
        public int VerticalAxis { get => intVerticalAxis; }

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

        private string[] intHorizontalArray;
    
        public bool IsThisPositionAMine(IPosition position)
        {
            throw new NotImplementedException();
        }

        private List<IPosition> MinePositions;

        public BoardResults IsThisPositionValid(IPosition position)
        {

            //Is position valid on the board
            if (position.Vertical >0 && position.Vertical <= intVerticalAxis
                && position.Horizontal >= 0 && position.Horizontal < intHorizontalArray.Length)
            {
                
                return new BoardResults("Valid Vertical and Horizontal",
                    true,
                    true,
                    true);

            }
           
            if (position.Vertical <= 0 && position.Horizontal >= 0 && position.Horizontal < intHorizontalArray.Length)
            {

                return new BoardResults("Bottom Reached and Valid Horizontal",
                    true,
                    false,
                    false);
                           
            }

            if (position.Vertical > intVerticalAxis && position.Horizontal < intHorizontalArray.Length && position.Horizontal >= 0)
            {
         
                return new BoardResults("Top Reached and Valid Horizontal",
                   true,
                   false,
                   false);
            }
            if (position.Horizontal <= 0 && position.Vertical > 0 && position.Vertical <= intVerticalAxis)
            {

                return new BoardResults("Left Reached and Valid Vertical",
                  false,
                  true,
                  false);                      
            }

            if (position.Horizontal == HorizontalArray.Length && position.Vertical > 0 && position.Vertical <= intVerticalAxis)
            {

                var returnValue = new BoardResults("You have won",
                 false,
                 true,
                 true);

                returnValue.YouHaveWon = true;

                return returnValue;
            }


            throw new ArgumentException("Invalid Postion passed that Board does not understand");
        }


    }

    public class BoardResults
    {
   
        public BoardResults(string text, bool vHorizontal, bool vVertical, bool vMove)
        {
            Text = text;
            validHorizontal = vHorizontal;
            validVertical = vVertical;
            validMove = vMove;
        }


        private bool validHorizontal = false;
        private bool validVertical = false;
        private bool youHaveWon = false;
        private bool validMove = false;
        public string Text { get; }
        public bool ValidHorizontal { get => validHorizontal; }
        public bool ValidVertical { get => validVertical; }
        public bool YouHaveWon { get => youHaveWon; set => youHaveWon = value; }
        public bool ValidMove { get => validMove; }
    }
}
