using MineSweeperLogic;
using NUnit.Framework;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using MineSweeperLogic.Interfaces;

namespace Tests
{
    public class PlayerTests
    {
        [SetUp]
        public void Setup()
        {
            
        }


        private IBoardRules CreateBoardRules()
        {
            return new BoardMineSweeperRules(new Board(GenerateHorizontalArray.HorizontalChessArray(8),8,null));
        }

        [Test]
        public void PlayerTestInvalidLeftDoesNotUpdatePositionOrMoves()
        {
            var initialPosition = new Position(0, 2);
            var playerToTest = new Player( new Move(), initialPosition, 3,CreateBoardRules(),new GameMineSweeperRules());

            playerToTest.PlayerEvent += HandlePlayerEvent;

            playerToTest.ProcessKeyStroke(ConsoleKey.LeftArrow.ToString());

            Assert.AreEqual(0, playerToTest.CurrentPosition.Horizontal);
            Assert.AreEqual(2, playerToTest.CurrentPosition.Vertical);
            Assert.AreEqual(0, playerToTest.NoOfMoves);
        }


        public void HandlePlayerEvent(object sender, EventArgs e)
        {
            PlayerEvents playerEvents = (PlayerEvents)e;
        }

        [Test]
        public void PlayerTestInvalidUpDoesNotUpdatePositionOrMoves()
        {
            var initialPosition = new Position(0, 8);
            var playerToTest = new Player(new Move(), initialPosition, 3, CreateBoardRules(),new GameMineSweeperRules());

            playerToTest.PlayerEvent += HandlePlayerEvent;

            playerToTest.ProcessKeyStroke(ConsoleKey.UpArrow.ToString());

            Assert.AreEqual(0, playerToTest.CurrentPosition.Horizontal);
            Assert.AreEqual(8, playerToTest.CurrentPosition.Vertical);
            Assert.AreEqual(0, playerToTest.NoOfMoves);
        }

        [Test]
        public void PlayerTestInvalidDownDoesNotUpdatePositionOrMoves()
        {
            var initialPosition = new Position(0, 1);
            var playerToTest = new Player(new Move(), initialPosition, 3, CreateBoardRules(),new GameMineSweeperRules());

            playerToTest.PlayerEvent += HandlePlayerEvent;

           playerToTest.ProcessKeyStroke(ConsoleKey.DownArrow.ToString());

            Assert.AreEqual(0, playerToTest.CurrentPosition.Horizontal);
            Assert.AreEqual(1, playerToTest.CurrentPosition.Vertical);
            Assert.AreEqual(0, playerToTest.NoOfMoves);
        }

        [Test]
        public void PlayerTestHaveMadeItOut()
        {
            var initialPosition = new Position(7, 1);
            var playerToTest = new Player( new Move(), initialPosition, 3, CreateBoardRules(),new GameMineSweeperRules());

            playerToTest.PlayerEvent += TestHandlePlayerEvent;

            playerToTest.ProcessKeyStroke(ConsoleKey.RightArrow.ToString());
        }


        public void TestHandlePlayerEvent(object sender, EventArgs e)
        {
            PlayerEvents playerEvents = (PlayerEvents)e;

            Assert.AreEqual("You have made it safely out", playerEvents.resultMessage);

        }


        private IBoardRules CreateBoardWithMinesRules()
        {
            //Generate Mines
           var minesEverywhere = GenerateMines.GenerateMineLocation(64, 8, 8);

            return new BoardMineSweeperRules(new Board(GenerateHorizontalArray.HorizontalChessArray(8), 8, minesEverywhere));
        }

        [Test]
        public void PlayerTestHitAMineAndLivesGoDown()
        {
            var initialPosition = new Position(0, 1);
            var playerToTest = new Player(new Move(), initialPosition, 3, CreateBoardWithMinesRules(), new GameMineSweeperRules());

            playerToTest.PlayerEvent += HandlePlayerEvent;

            playerToTest.ProcessKeyStroke(ConsoleKey.RightArrow.ToString());

            Assert.AreEqual(1, playerToTest.CurrentPosition.Horizontal);
            Assert.AreEqual(1, playerToTest.CurrentPosition.Vertical);
            Assert.AreEqual(1, playerToTest.NoOfMoves);
            Assert.AreEqual(2, playerToTest.NoOfLives);
        }


    }
}