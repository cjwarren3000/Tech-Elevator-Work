using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class Lucky13Tests
    {
        [TestMethod]
        public void ShouldReturnFalseWhenInputIncludesOnlyOne()
        {
            //arrange
            Lucky13 oneOrThreeCheck = new Lucky13();
            int[] numbers = { 1, 8, 39, 9 };

            //act
            bool containsOneAndThree = oneOrThreeCheck.GetLucky(numbers);

            //assert   
            Assert.AreEqual(false, containsOneAndThree);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenInputIncludesOnlyThree()
        {
            //arrange
            Lucky13 oneOrThreeCheck = new Lucky13();
            int[] numbers = { 3, 12, 10, 803 };

            //act
            bool containsOneAndThree = oneOrThreeCheck.GetLucky(numbers);

            //assert   
            Assert.AreEqual(false, containsOneAndThree);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenInputIncludesOneAndThree()
        {
            //arrange
            Lucky13 oneOrThreeCheck = new Lucky13();
            int[] numbers = { 1, 2328, 3, 96 };

            //act
            bool containsOneAndThree = oneOrThreeCheck.GetLucky(numbers);

            //assert   
            Assert.AreEqual(false, containsOneAndThree);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenInputIncludesNoOneAndThree()
        {
            //arrange
            Lucky13 oneOrThreeCheck = new Lucky13();
            int[] numbers = { 13, 2328, 34, 96 };

            //act
            bool containsOneAndThree = oneOrThreeCheck.GetLucky(numbers);

            //assert   
            Assert.AreEqual(true, containsOneAndThree);
        }
    }
}
