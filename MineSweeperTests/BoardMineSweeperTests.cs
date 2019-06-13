using System.Collections.Generic;
using MineSweeperLogic;
using MineSweeperLogic.Interfaces;
using NUnit.Framework;

namespace Tests
{
    public class BoardMineSweeperTests
    {
        [SetUp]
        public void Setup()
        {
            
        }


        [Test]
        public void BoardInstantiatedCorrectlyForXandY()
        {
            var boardToTest = new Board(GenerateHorizontalArray.HorizontalChessArray(4), 4, null);

            Assert.AreEqual(4, boardToTest.HorizontalArray.Length);
            Assert.AreEqual(4, boardToTest.VerticalAxis);
            Assert.AreEqual(0, boardToTest.NumberOfMines);
        }

        [Test]
        public void BoardBottomReached()
        {
            var boardToTest = new Board(GenerateHorizontalArray.HorizontalChessArray(4), 4, null);
            var boardRules = new BoardMineSweeperRules(boardToTest);
            var results = boardRules.ProcessRules(new Position(1, 0));

            Assert.AreEqual(false, results.ValidVertical);
            Assert.AreEqual(true, results.ValidHorizontal);
            Assert.AreEqual(false, results.ValidMove);
            Assert.AreEqual(false, results.ReachedTheEnd);

            Assert.AreEqual("Bottom Reached", results.Text);

        }

        [Test]
        public void BoardTopReached()
        {
            var boardToTest = new Board(GenerateHorizontalArray.HorizontalChessArray(4), 4, null);
            var boardRules = new BoardMineSweeperRules(boardToTest);
            var results = boardRules.ProcessRules(new Position(1, 5));

            Assert.AreEqual(false, results.ValidVertical);
            Assert.AreEqual(true, results.ValidHorizontal);
            Assert.AreEqual(false, results.ValidMove);
            Assert.AreEqual(false, results.ReachedTheEnd);

            Assert.AreEqual("Top Reached", results.Text);
        }

        [Test]
        public void BoardLeftReached()
        {
            var boardToTest = new Board(GenerateHorizontalArray.HorizontalChessArray(4), 4, null);
            var boardRules = new BoardMineSweeperRules(boardToTest);
            var results = boardRules.ProcessRules(new Position(-1, 2));

            Assert.AreEqual(true, results.ValidVertical);
            Assert.AreEqual(false, results.ValidHorizontal);
            Assert.AreEqual(false, results.ValidMove);
            Assert.AreEqual(false, results.ReachedTheEnd);

            Assert.AreEqual("Left Reached", results.Text);
        }

        [Test]
        public void BoardRightReachedAndYouReachedTheEnd()
        {
            var boardToTest = new Board(GenerateHorizontalArray.HorizontalChessArray(4), 4, null);
            var boardRules = new BoardMineSweeperRules(boardToTest);
            var results = boardRules.ProcessRules(new Position(4, 2));

            Assert.AreEqual(true, results.ValidVertical);
            Assert.AreEqual(false, results.ValidHorizontal);
            Assert.AreEqual(true, results.ValidMove);
            Assert.AreEqual(true, results.ReachedTheEnd);

            Assert.AreEqual("Reached The End", results.Text);
        }


        [Test]
        public void BoardRulesIHaveHitAMineOnTheWinningEdge()
        {

            //PositionToMoveto
            var positionToMoveTo = new Position(4, 2);
            //Create a MineLocation at the same postion
            var minePositions = new List<IPosition> {positionToMoveTo};

            var boardToTest = new Board(GenerateHorizontalArray.HorizontalChessArray(4), 4, minePositions);
            var boardRules = new BoardMineSweeperRules(boardToTest);
            var results = boardRules.ProcessRules(positionToMoveTo);

            Assert.AreEqual(true, results.ValidVertical);
            Assert.AreEqual(false, results.ValidHorizontal);
            Assert.AreEqual(true, results.ValidMove);
            Assert.AreEqual(true, results.ReachedTheEnd);
            Assert.AreEqual(true, results.HitAMine);

            Assert.AreEqual("Reached The End", results.Text);
        }


        [Test]
        public void BoardRulesCheckForMinesThereAreNoMines()
        {

            //PositionToMoveto
            var positionToMoveTo = new Position(2, 2);

            var boardToTest = new Board(GenerateHorizontalArray.HorizontalChessArray(4), 4, null);
            var boardRules = new BoardMineSweeperRules(boardToTest);

            Assert.IsFalse(boardRules.CheckForMines(positionToMoveTo));
        }


        [Test]
        public void BoardRulesCheckForMinesIHaveHitOneAndItGetsRemoved()
        {

            //PositionToMoveto
            var positionToMoveTo = new Position(4, 2);
            //Create a MineLocation at the same postion
            var minePositions = new List<IPosition> { positionToMoveTo };

            var boardToTest = new Board(GenerateHorizontalArray.HorizontalChessArray(4), 4, minePositions);
            var boardRules = new BoardMineSweeperRules(boardToTest);
            
            Assert.IsTrue(boardRules.CheckForMines(positionToMoveTo));
            Assert.AreEqual(0,boardToTest.NumberOfMines);

        }


        [Test]
        public void BoardRulesCheckForMinesIHaveNotHitOne()
        {

            //PositionToMoveto
            var positionToMoveTo = new Position(4, 2);
            var minePosition = new Position(1, 2);

            //Create a MineLocation at the same postion
            var minePositions = new List<IPosition> { minePosition };

            var boardToTest = new Board(GenerateHorizontalArray.HorizontalChessArray(4), 4, minePositions);
            var boardRules = new BoardMineSweeperRules(boardToTest);

            Assert.IsFalse(boardRules.CheckForMines(positionToMoveTo));

        }

    }
}