using MineSweeperLogic;
using NUnit.Framework;

namespace Tests
{
    public class GameTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

 

        [Test]
        public void GameInstantiatesWithPlayerStartingAt01()
        {
            var gameToTest = new Game();

            Assert.AreEqual(0, gameToTest.Player.CurrentPosition.Horizontal);
            Assert.AreEqual(1, gameToTest.Player.CurrentPosition.Vertical);

          
        }
        [Test]
        public void GameInstantiatesWith30Mines()
        {
            var gameToTest = new Game();

            Assert.AreEqual(30, gameToTest.Board.NumberOfMines);

        }
        [Test]
        public void GameInstantiatesWithAPlayer3Lives()
        {
            var gameToTest = new Game();

            Assert.AreEqual(3, gameToTest.Player.NoOfLives);

        }
        [Test]
        public void GameStopsOnGameOver()
        {
            var gameToTest = new Game();

            var dummyEvent = new PlayerEvents
            {
                GameOver = true
            };

            gameToTest.HandlePlayerEvent(this, dummyEvent);

            Assert.AreEqual(true, gameToTest.GameOver);

        }
    }

}
