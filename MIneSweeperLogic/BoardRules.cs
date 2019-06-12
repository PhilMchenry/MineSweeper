using System;

namespace MineSweeperLogic
{
    public class BoardRules : IBoardRules
    {
        private readonly IBoard board;

        public BoardRules(IBoard board)
        {
            this.board = board;
        }
        public BoardResults ProcessRules(IPosition currentPosition)
        {
            var boardResultsValidPosition = IsThisPositionValid(currentPosition);

            boardResultsValidPosition.HitAMine = CheckForMines(currentPosition);

            return boardResultsValidPosition;
        }

        public bool CheckForMines(IPosition currentPosition)
        {
            //Check if I have mines
            if (board.NumberOfMines <= 0) return false;
            var mineResult = board.MinePositions.Find(x => x.Equals(currentPosition));

            if (mineResult != null) return true;
            {
                return false;
            }
        }


        public BoardResults IsThisPositionValid(IPosition position)
        {

            //Is position valid on the board
            if (position.Vertical > 0 && position.Vertical <= board.VerticalAxis
                                      && position.Horizontal >= 0 && position.Horizontal < board.HorizontalArray.Length)
            {

                return new BoardResults("Valid Move",
                    true,
                    true,
                    true);
            }

            if (position.Vertical <= 0 && position.Horizontal >= 0 && position.Horizontal < board.HorizontalArray.Length)
            {

                return new BoardResults("Bottom Reached",
                    true,
                    false,
                    false);

            }

            if (position.Vertical > board.VerticalAxis && position.Horizontal < board.HorizontalArray.Length && position.Horizontal >= 0)
            {

                return new BoardResults("Top Reached",
                    true,
                    false,
                    false);
            }
            if (position.Horizontal <= 0 && position.Vertical > 0 && position.Vertical <= board.VerticalAxis)
            {

                return new BoardResults("Left Reached",
                    false,
                    true,
                    false);
            }

            if (position.Horizontal == board.HorizontalArray.Length && position.Vertical > 0 && position.Vertical <= board.VerticalAxis)
            {

                var returnValue = new BoardResults("Reached The End",
                    false,
                    true,
                    true) {ReachedTheEnd = true};


                return returnValue;
            }


            throw new ArgumentException("Invalid Position passed that Board does not understand");
        }




    }
}
