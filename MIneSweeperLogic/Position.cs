using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperLogic
{
    public class Position : IPosition
    {
        public int Horizontal { get ; set; }
        public int Vertical {
            get;
            set; }
   

        
        public Position(int horizontal, int vertical)
        {
            this.Horizontal = horizontal;
            this.Vertical = vertical;
        }
    }




}
