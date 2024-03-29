﻿using MineSweeperLogic.Interfaces;

namespace MineSweeperLogic
{
    /// <summary>
    /// Holds x and y axis plus allows comparison
    /// </summary>
    public class Position : IPosition
    {
        public int Horizontal { get ; set; }
        public int Vertical {
            get;
            set; }
        
        public Position(int horizontal, int vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }

        public bool Equals(IPosition other)
        {

            if (Horizontal == other.Horizontal && Vertical == other.Vertical)
            {
                return true;}

            return false;
            
        }

        
    }




}
