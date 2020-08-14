using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 Given an array of ints, return true if the array is length 1 or more, and the first
 element and the last element are equal.
 IsItTheSame([1, 2, 3]) → false
 IsItTheSame([1, 2, 3, 1]) → true
 IsItTheSame([1, 2, 1]) → true
 */

namespace Exercises.Tests
{
    [TestClass]
    public class SameFirstLastTests
    {
        [TestMethod]
        public void ShouldReturnTrueWithLengthOverOneAndBothEqual()
        {
            //arrange
            SameFirstLast newSameFirstLast = new SameFirstLast();
            int[] numbers = { 3, 6, 0, 3 };

            //act
            bool oneOrMoreAndTheSame = newSameFirstLast.IsItTheSame(numbers);

            //assert
            Assert.AreEqual(true, oneOrMoreAndTheSame);

        }

        [TestMethod]
        public void ShouldReturnFalseWithLengthOverOneAndNotEqual()
        {
            //arrange
            SameFirstLast newSameFirstLast = new SameFirstLast();
            int[] numbers = { 3, 6, 0, 8 };

            //act
            bool oneOrMoreAndTheSame = newSameFirstLast.IsItTheSame(numbers);

            //assert
            Assert.AreEqual(false, oneOrMoreAndTheSame);

        }

        [TestMethod]
        public void ShouldReturnFalseWithLengthUnderOne()
        {
            //arrange
            SameFirstLast newSameFirstLast = new SameFirstLast();
            int[] numbers = { };

            //act
            bool oneOrMoreAndTheSame = newSameFirstLast.IsItTheSame(numbers);

            //assert
            Assert.AreEqual(false, oneOrMoreAndTheSame);

        }

        [TestMethod]
        public void ShouldReturnTrueWithLengthOfOne()
        {
            //arrange
            SameFirstLast newSameFirstLast = new SameFirstLast();
            int[] numbers = { 13 };

            //act
            bool oneOrMoreAndTheSame = newSameFirstLast.IsItTheSame(numbers);

            //assert
            Assert.AreEqual(true, oneOrMoreAndTheSame);

        }
    }
}
