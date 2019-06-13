using System;
using MineSweeperLogic.Interfaces;

namespace MineSweeperLogic
{
    public class Move : IMove
    {
        
        public IPosition MoveDown(IPosition currentPosition)
        {
            
            currentPosition.Vertical = currentPosition.Vertical - 1;

            return currentPosition;
        }

        public IPosition ProcessKeyStroke(string keyStroke, IPosition currentPosition)
        {
            if (keyStroke == ConsoleKey.UpArrow.ToString())
            {
                return MoveUp(currentPosition);
            }
            else if (keyStroke == ConsoleKey.DownArrow.ToString())
            {
               return MoveDown(currentPosition);
            }
            else if (keyStroke == ConsoleKey.LeftArrow.ToString())
            {
                return MoveLeft(currentPosition);
            }
            else if (keyStroke == ConsoleKey.RightArrow.ToString())
            {
                return MoveRight(currentPosition);
            }

            throw new ArgumentException("Invalid KeyStroke");
        }

        public IPosition MoveLeft(IPosition currentPosition)
        {
            
            currentPosition.Horizontal = currentPosition.Horizontal -1 ;

            return currentPosition;
        }

        public IPosition MoveRight(IPosition currentPosition)
        {
            currentPosition.Horizontal = currentPosition.Horizontal + 1;

        
            return currentPosition;
        }

        public IPosition MoveUp(IPosition currentPosition)
        {
            currentPosition.Vertical = currentPosition.Vertical + 1;

            return currentPosition;
        }
    }
}
