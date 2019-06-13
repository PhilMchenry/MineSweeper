using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperLogic
{
    public class GenerateGame
    {

        public static Game GenerateAGame(int xAxis, int yAxis, int noMines, int noLives, int startXAxis, int startYAxis)
        {

            //Create Dependencies
            //Generate Mines
            var generatedMines = GenerateMines.GenerateMineLocation(noMines, xAxis, yAxis);
            //Game is a 8X8 square and has a set of mines
            var board = new Board(GenerateHorizontalArray.HorizontalChessArray(xAxis), yAxis, generatedMines);
            //Start Position of Player
            var startPosition = new Position(startXAxis, 1);
            //Create player a way to move, startposition, numberoflives, boardrules and gamerules
            var player = new Player(new Move(), startPosition, noLives, new BoardMineSweeperRules(board), new GameMineSweeperRules());

            return new Game(board, player);
        }

    }
}
