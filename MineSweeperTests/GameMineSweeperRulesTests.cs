using MineSweeperLogic;
using NUnit.Framework;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using MineSweeperLogic.Interfaces;
using Moq;

namespace Tests
{
    public class GameMineSweeperRulesTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void GameMineSweeperRulesTestOutOfLives()
        {
            var mplayerMock = new Mock<IPlayer>();
            mplayerMock.SetupGet(x => x.NoOfLives).Returns(0);


            var mboardResults = new Mock<BoardResults>();
            

            var testResults = new GameMineSweeperRules().ApplyGameRules(mboardResults.Object, mplayerMock.Object);

            Assert.AreEqual(true, testResults.GameOver);
            Assert.AreEqual("Dead ", testResults.resultPosition);
            Assert.AreEqual("Out of Lives Ouch", testResults.resultMessage);
        }
        [Test]
        public void GameMineSweeperRulesTestMadeItOutSafely()
        {
            var mplayerMock = new Mock<IPlayer>();
            mplayerMock.SetupGet(x=>x.NoOfLives).Returns(3);

            var mboardResults = new Mock<BoardResults>();
            mboardResults.SetupGet(x => x.ReachedTheEnd).Returns(true);

            var testResults = new GameMineSweeperRules().ApplyGameRules(mboardResults.Object, mplayerMock.Object);


            Assert.AreEqual(true, testResults.GameOver);
            Assert.AreEqual("Free ", testResults.resultPosition);
            Assert.AreEqual("You have made it safely out", testResults.resultMessage);
        }

        [Test]
        public void GameMineSweeperRulesTestHitAMine()
        {
            var mplayerMock = new Mock<IPlayer>();
            mplayerMock.SetupGet(x => x.NoOfLives).Returns(3);
            mplayerMock.Setup(x => x.FriendlyPosition()).Returns("A4");

            var mboardResults = new Mock<BoardResults>();
            mboardResults.SetupGet(x => x.ReachedTheEnd).Returns(false);
            mboardResults.SetupGet(x => x.HitAMine).Returns(true);

            var testResults = new GameMineSweeperRules().ApplyGameRules(mboardResults.Object, mplayerMock.Object);

            mplayerMock.Verify(x=>x.RemoveLive());
            Assert.AreEqual(false, testResults.GameOver);
            Assert.AreEqual("Position A4", testResults.resultPosition);
            Assert.AreEqual(" You Hit A Mine! ", testResults.resultMessage);
        }

        [Test]
        public void GameMineSweeperRulesTestValidMove()
        {
            var mplayerMock = new Mock<IPlayer>();
            mplayerMock.SetupGet(x => x.NoOfLives).Returns(3);
            mplayerMock.Setup(x => x.FriendlyPosition()).Returns("A4");

            var mboardResults = new Mock<BoardResults>();
            mboardResults.SetupGet(x => x.ReachedTheEnd).Returns(false);
            mboardResults.SetupGet(x => x.ValidMove).Returns(true);

            var testResults = new GameMineSweeperRules().ApplyGameRules(mboardResults.Object, mplayerMock.Object);

            mplayerMock.Verify(x=>x.AddMove());
            Assert.AreEqual(false, testResults.GameOver);
            Assert.AreEqual("Position A4", testResults.resultPosition);
           
        }

        [Test]
        public void GameMineSweeperRulesTestInValidMoveResetPosition()
        {
            var mplayerMock = new Mock<IPlayer>();
            mplayerMock.SetupGet(x => x.NoOfLives).Returns(3);
            mplayerMock.Setup(x => x.FriendlyPosition()).Returns("A4");

            var mboardResults = new Mock<BoardResults>();
            mboardResults.SetupGet(x => x.ReachedTheEnd).Returns(false);
            mboardResults.SetupGet(x => x.ValidMove).Returns(false);

            var testResults = new GameMineSweeperRules().ApplyGameRules(mboardResults.Object, mplayerMock.Object);

            mplayerMock.Verify(x => x.ResetPosition());
            Assert.AreEqual(false, testResults.GameOver);
            Assert.AreEqual("Position A4", testResults.resultPosition);
            
        }
    }
}