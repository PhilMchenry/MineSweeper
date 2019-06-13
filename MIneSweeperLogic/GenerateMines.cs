using System;
using System.Collections.Generic;
using MineSweeperLogic.Interfaces;

namespace MineSweeperLogic
{
    /// <summary>
    /// Will create a random set of mine locations based on max horizontal/vertical and number of mines.
    /// </summary>
    public class GenerateMines
    {
        private readonly int maxHorizontal;
        private readonly int maxVertical;


        public GenerateMines(int maxHorizontal, int maxVertical)
        {
            this.maxHorizontal = maxHorizontal;
            this.maxVertical = maxVertical;
           
        }

        public List<IPosition> GenerateMineLocation(int noOfMines)
        {
            //check I have enough squares 

            var totalSquares = maxHorizontal * maxVertical;

            if (totalSquares <= noOfMines)
            {
                throw new ArgumentException("Mines equal or greater than available squares");
            }

            var returnMine = new List<IPosition>();

            var iterator = 0;

            while ( iterator < noOfMines)
            {
                Random rnd = new Random();

                //Generate a vertical position
                //Generate a horizontal position
                var horizontalMine = rnd.Next(0, maxHorizontal);
                var verticalMine = rnd.Next(0, maxVertical);

                //Check I am not already in there
                var doIexist = returnMine.Find(x => x.Horizontal == horizontalMine && x.Vertical == verticalMine);
                
                if (doIexist == null)
                {
                    returnMine.Add(new Position(horizontalMine, verticalMine));
                    iterator++;
                }

               
            }

            return returnMine;
        }
    }
}