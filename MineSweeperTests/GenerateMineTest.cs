using System;
using System.Collections.Generic;
using System.Text;
using MineSweeperLogic;
using NUnit.Framework;
using NUnit;

namespace Tests
{
    public class GenerateMineTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NumberOfMinesExceedsAvailableSquares()
        {
            Assert.Throws<ArgumentException>(() => GenerateMines.GenerateMineLocation(2,1,1));
        }

        [Test]
        public void TwoMinesGeneratedOk()
        {
            var resultList = GenerateMines.GenerateMineLocation(2,2,2);

            Assert.AreEqual(2, resultList.Count);

        }


    }
}