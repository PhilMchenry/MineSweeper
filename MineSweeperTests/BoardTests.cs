using MineSweeperLogic;
using NUnit.Framework;

namespace Tests
{
    public class BoardTests
    {
        [SetUp]
        public void Setup()
        {
            
        }


        [Test]
        public void BoardInstatiatedCorrectlyForXandY()
        {
            var boardToTest = new Board(GenerateHorizontalArray.HorizontalChessArray(4), 4, 0);

            Assert.AreEqual(4, boardToTest.HorizontalArray.Length);
            Assert.AreEqual(4, boardToTest.VerticalAxis);
            Assert.AreEqual(0, boardToTest.NumberOfMines);
        }

        [Test]
        public void BoardBottomReached()
        {
            var boardToTest = new Board(GenerateHorizontalArray.HorizontalChessArray(4), 4, 0);

            var results = boardToTest.IsThisPositionValid(new Position(1, 0));

            Assert.AreEqual(false, results.ValidVertical);
            Assert.AreEqual(true, results.ValidHorizontal);
            Assert.AreEqual(false, results.ValidMove);
            Assert.AreEqual(false, results.YouHaveWon);

            Assert.AreEqual("Bottom Reached and Valid Horizontal", results.Text);

        }

        [Test]
        public void BoardTopReached()
        {
            var boardToTest = new Board(GenerateHorizontalArray.HorizontalChessArray(4), 4, 0);

            var results = boardToTest.IsThisPositionValid(new Position(1, 5));

            Assert.AreEqual(false, results.ValidVertical);
            Assert.AreEqual(true, results.ValidHorizontal);
            Assert.AreEqual(false, results.ValidMove);
            Assert.AreEqual(false, results.YouHaveWon);

            Assert.AreEqual("Top Reached and Valid Horizontal", results.Text);
        }

        [Test]
        public void BoardLeftReached()
        {
            var boardToTest = new Board(GenerateHorizontalArray.HorizontalChessArray(4), 4, 0);

            var results = boardToTest.IsThisPositionValid(new Position(-1, 2));

            Assert.AreEqual(true, results.ValidVertical);
            Assert.AreEqual(false, results.ValidHorizontal);
            Assert.AreEqual(false, results.ValidMove);
            Assert.AreEqual(false, results.YouHaveWon);

            Assert.AreEqual("Left Reached and Valid Vertical", results.Text);
        }

        [Test]
        public void BoardRightReachedAndYouWin()
        {
            var boardToTest = new Board(GenerateHorizontalArray.HorizontalChessArray(4), 4, 0);

            var results = boardToTest.IsThisPositionValid(new Position(4, 2));

            Assert.AreEqual(true, results.ValidVertical);
            Assert.AreEqual(false, results.ValidHorizontal);
            Assert.AreEqual(true, results.ValidMove);
            Assert.AreEqual(true, results.YouHaveWon);

            Assert.AreEqual("You have won", results.Text);
        }

    }
}