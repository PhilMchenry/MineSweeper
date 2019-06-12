using System;

namespace MineSweeperLogic
{
    /// <summary>
    /// Will create a string array representing the first 8 letters of the Alphabet
    /// </summary>
    public  class GenerateHorizontalArray
    {

        private static readonly string[] constHorizontalArray = { "A", "B", "C", "D", "E", "F", "G", "H" };

       public static string[] HorizontalChessArray(int size)
        {
            if (size <= 0 || size > 8)
            {
                throw new ArgumentException("X-Axis parameter must be between 1 and 8");
            }
            else
            {

                var arrayToReturn = new string[size];
                int iterate = 0;
                while (iterate < size)
                {
                    arrayToReturn[iterate] = constHorizontalArray[iterate];
                    iterate++;
                }

                return arrayToReturn;
            }

        }

    }
}
