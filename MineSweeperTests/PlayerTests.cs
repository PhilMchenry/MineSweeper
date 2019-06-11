using MineSweeperLogic;
using NUnit.Framework;
using System;

namespace Tests
{
    public class PlayerTests
    {
        [SetUp]
        public void Setup()
        {
            
        }


        [Test]
        public void PlayerTestInvalidLeftDoesNotUpdatePositionOrMoves()
        {
            var initialPosition = new Position(0, 2);
            var PlayerToTest = new Player(new Game(), new NormalMove(), initialPosition, 3);

            PlayerToTest.playerEvent += HandlePlayerEvent;

            PlayerToTest.MovePositionLeft();

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
            var PlayerToTest = new Player(new Game(), new NormalMove(), initialPosition, 3);

            PlayerToTest.playerEvent += HandlePlayerEvent;

            PlayerToTest.MovePositionLeft();

            Assert.AreEqual(0, PlayerToTest.CurrentPosition.Horizontal);
            Assert.AreEqual(8, PlayerToTest.CurrentPosition.Vertical);
            Assert.AreEqual(0, PlayerToTest.NoOfMoves);
        }

        [Test]
        public void PlayerTestInvalidDownDoesNotUpdatePositionOrMoves()
        {
            var initialPosition = new Position(0, 1);
            var PlayerToTest = new Player(new Game(), new NormalMove(), initialPosition, 3);

            PlayerToTest.playerEvent += HandlePlayerEvent;

            PlayerToTest.MovePositionLeft();

            Assert.AreEqual(0, PlayerToTest.CurrentPosition.Horizontal);
            Assert.AreEqual(1, PlayerToTest.CurrentPosition.Vertical);
            Assert.AreEqual(0, PlayerToTest.NoOfMoves);
        }

        [Test]
        public void PlayerTestHaveMadeItOut()
        {
            var initialPosition = new Position(7, 1);
            var PlayerToTest = new Player(new Game(), new NormalMove(), initialPosition, 3);

            PlayerToTest.playerEvent += TestHandlePlayerEvent;

            PlayerToTest.MovePositionRight();

           
            
        }


        public void TestHandlePlayerEvent(object sender, EventArgs e)
        {
            PlayerEvents playerEvents = (PlayerEvents)e;

           Assert.AreEqual("You have made it safely out", playerEvents.resultPosition);
           

        }
    }
}