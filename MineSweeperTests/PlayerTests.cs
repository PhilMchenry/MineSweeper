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
            return new BoardRules(new Board(GenerateHorizontalArray.HorizontalChessArray(8),8,null));
        }

        [Test]
        public void PlayerTestInvalidLeftDoesNotUpdatePositionOrMoves()
        {
            var initialPosition = new Position(0, 2);
            var PlayerToTest = new Player(new Game(), new Move(), initialPosition, 3,CreateBoardRules(),new PlayerReaction());

            PlayerToTest.PlayerEvent += HandlePlayerEvent;

            PlayerToTest.ProcessKeyStroke(ConsoleKey.LeftArrow.ToString());

            Assert.AreEqual(0, PlayerToTest.CurrentPosition.Horizontal);
            Assert.AreEqual(2, PlayerToTest.CurrentPosition.Vertical);
            Assert.AreEqual(0, PlayerToTest.NoOfMoves);
        }


        public void HandlePlayerEvent(object sender, EventArgs e)
        {
            PlayerEvents playerEvents = (PlayerEvents)e;
        }

        [Test]
        public void PlayerTestInvalidUpDoesNotUpdatePositionOrMoves()
        {
            var initialPosition = new Position(0, 8);
            var PlayerToTest = new Player(new Game(), new Move(), initialPosition, 3, CreateBoardRules(),new PlayerReaction());

            PlayerToTest.PlayerEvent += HandlePlayerEvent;

            PlayerToTest.ProcessKeyStroke(ConsoleKey.UpArrow.ToString());

            Assert.AreEqual(0, PlayerToTest.CurrentPosition.Horizontal);
            Assert.AreEqual(8, PlayerToTest.CurrentPosition.Vertical);
            Assert.AreEqual(0, PlayerToTest.NoOfMoves);
        }

        [Test]
        public void PlayerTestInvalidDownDoesNotUpdatePositionOrMoves()
        {
            var initialPosition = new Position(0, 1);
            var PlayerToTest = new Player(new Game(), new Move(), initialPosition, 3, CreateBoardRules(),new PlayerReaction());

            PlayerToTest.PlayerEvent += HandlePlayerEvent;

           PlayerToTest.ProcessKeyStroke(ConsoleKey.DownArrow.ToString());

            Assert.AreEqual(0, PlayerToTest.CurrentPosition.Horizontal);
            Assert.AreEqual(1, PlayerToTest.CurrentPosition.Vertical);
            Assert.AreEqual(0, PlayerToTest.NoOfMoves);
        }

        [Test]
        public void PlayerTestHaveMadeItOut()
        {
            var initialPosition = new Position(7, 1);
            var PlayerToTest = new Player(new Game(), new Move(), initialPosition, 3, CreateBoardRules(),new PlayerReaction());

            PlayerToTest.PlayerEvent += TestHandlePlayerEvent;

            PlayerToTest.ProcessKeyStroke(ConsoleKey.RightArrow.ToString());

        }


        public void TestHandlePlayerEvent(object sender, EventArgs e)
        {
            PlayerEvents playerEvents = (PlayerEvents)e;

           Assert.AreEqual("You have made it safely out", playerEvents.resultMessage);
           

        }
    }
}