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
            var gameToTest = GenerateGame.GenerateAGame(8,8,5,5,0,1);

            Assert.AreEqual(0, gameToTest.Player.CurrentPosition.Horizontal);
            Assert.AreEqual(1, gameToTest.Player.CurrentPosition.Vertical);

          
        }
        [Test]
        public void GameInstantiatesWith30Mines()
        {
            var gameToTest = GenerateGame.GenerateAGame(8, 8, 30, 5, 0, 1);

            Assert.AreEqual(30, gameToTest.Board.NumberOfMines);

        }
        [Test]
        public void GameInstantiatesWithAPlayer3Lives()
        {
            var gameToTest = GenerateGame.GenerateAGame(8, 8, 5, 3, 0, 1);

            Assert.AreEqual(3, gameToTest.Player.NoOfLives);

        }
        [Test]
        public void GameStopsOnGameOver()
        {
            var gameToTest = GenerateGame.GenerateAGame(8, 8, 5, 3, 0, 1);
            var dummyEvent = new PlayerEvents
            {
                GameOver = true
            };

            gameToTest.HandlePlayerEvent(this, dummyEvent);

            Assert.AreEqual(true, gameToTest.GameOver);

        }

        [Test]
        public void GameContinues()
        {
            var gameToTest = GenerateGame.GenerateAGame(8, 8, 5, 3, 0, 1);
            var dummyEvent = new PlayerEvents
            {
                GameOver = false
            };

            gameToTest.HandlePlayerEvent(this, dummyEvent);

            Assert.AreEqual(false, gameToTest.GameOver);

        }

    }

}
