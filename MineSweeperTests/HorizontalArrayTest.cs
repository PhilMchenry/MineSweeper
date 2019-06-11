using System;
using System.Collections.Generic;
using System.Text;
using MineSweeperLogic;
using NUnit.Framework;
using NUnit;

namespace Tests
{
    public class HorizontalArrayTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HorizontalArrayGeneratedCorrectlyFor2()
        {
            var HorizontalArray = GenerateHorizontalArray.HorizontalChessArray(2);
            
            Assert.AreEqual("A",HorizontalArray[0]);
            
            Assert.AreEqual("B", HorizontalArray[1]);

            Assert.AreEqual(2, HorizontalArray.Length);
        }

      

        [Test]
        public void HorizontalArrayGeneratedFailsForLessThan1()
        {
            Assert.Throws<ArgumentException>(() => GenerateHorizontalArray.HorizontalChessArray(0));
        }
        [Test]
        public void HorizontalArrayGeneratedFailsForGreaterThan8()
        {
            Assert.Throws<ArgumentException>(() => GenerateHorizontalArray.HorizontalChessArray(9));
        }
    }
}