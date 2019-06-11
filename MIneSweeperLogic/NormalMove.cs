using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperLogic
{
    public class NormalMove : IMove
    {
       


        public IPosition MoveDown(IPosition currentPosition)
        {
            
            currentPosition.Vertical = currentPosition.Vertical - 1;

            return currentPosition;
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
