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
        public void GameInstatiatesWithPlayerStartingAt01()
        {
            var gameToTest = new Game();

            Assert.AreEqual(0, gameToTest.player.CurrentPosition.Horizontal);
            Assert.AreEqual(1, gameToTest.player.CurrentPosition.Vertical);

          
        }

       

    }
}