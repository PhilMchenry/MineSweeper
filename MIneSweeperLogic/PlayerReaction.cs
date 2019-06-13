using System;
using System.Collections.Generic;
using System.Text;
using MineSweeperLogic.Interfaces;

namespace MineSweeperLogic
{
   public class PlayerReaction : IReact
    {
        public PlayerEvents PlayerReact(BoardResults boardResults, IPlayer player)
        {

            //Change Player state
            //Can I Move, if so increase number of moves
            if (boardResults.ValidMove)
            {
                player.AddMove();
            }
            else
            {
                //If not stay where i am
                player.ResetPosition();
            }
            //Did I hit a mine? If  so lose a life
            if (boardResults.HitAMine)
            {
                player.RemoveLive();
            }


            var currentState = new PlayerEvents
            {
                numberOfLives = player.NoOfLives,
                numberOfMoves = player.NoOfMoves,
                resultMessage = boardResults.Text
            };

            //Check to see if GameOver
            //Check if you still have lives or have reached the end
            if (
                player.NoOfLives == 0)
            {
                currentState.resultMessage = "Out of Lives Ouch";
                currentState.resultPosition += "Dead ";
                currentState.GameOver = true;
            }
            else if (boardResults.ReachedTheEnd)
            {
                currentState.resultMessage = "You have made it safely out";
                currentState.resultPosition += "Free ";
                currentState.GameOver = true;
            }
            else
            {
                if (boardResults.HitAMine)
                {
                    currentState.resultMessage += " You Hit A Mine! ";
                }
                currentState.resultPosition += "Position " +
                                               player.FriendlyPosition();
                currentState.GameOver = false;
            }

            return currentState;
        }
    }
}
