using MineSweeperLogic;
using NUnit.Framework;

namespace Tests
{
    public class MoveTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void MoveLeftSuccess()
        {
            var moveTest = new MineSweeperLogic.Move();
            var positionTest = new Position(3, 4);

            var positionResult = moveTest.MoveLeft(positionTest);

            Assert.AreEqual(2, positionResult.Horizontal);
            Assert.AreEqual(4, positionResult.Vertical);
        
        }

        [Test]
        public void MoveRightSuccess()
        {
            var moveTest = new MineSweeperLogic.Move();
            var positionTest = new Position(3, 4);

            var positionResult = moveTest.MoveRight(positionTest);

            Assert.AreEqual(4, positionResult.Horizontal);
            Assert.AreEqual(4, positionResult.Vertical);

        }

        [Test]
        public void MoveUpSuccess()
        {
            var moveTest = new MineSweeperLogic.Move();
            var positionTest = new Position(3, 4);

            var positionResult = moveTest.MoveUp(positionTest);

            Assert.AreEqual(3, positionResult.Horizontal);
            Assert.AreEqual(5, positionResult.Vertical);

        }
        [Test]
        public void MoveDownSuccess()
        {
            var moveTest = new MineSweeperLogic.Move();
            var positionTest = new Position(3, 4);

            var positionResult = moveTest.MoveDown(positionTest);

            Assert.AreEqual(3, positionResult.Horizontal);
            Assert.AreEqual(3, positionResult.Vertical);

        }



    }
}