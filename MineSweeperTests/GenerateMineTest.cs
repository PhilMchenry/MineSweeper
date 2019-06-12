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

            var testGenerateMine = new GenerateMines(1,1);

            Assert.Throws<ArgumentException>(() => testGenerateMine.GenerateMineLocation(2));
        }

        [Test]
        public void TwoMinesGeneratedOk()
        {

            var testGenerateMine = new GenerateMines(2, 2);

            var resultList = testGenerateMine.GenerateMineLocation(2);

            

            Assert.AreEqual(2, resultList.Count);

          
        }


    }
}