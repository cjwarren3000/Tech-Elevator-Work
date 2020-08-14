using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

        /*
         Return true if the given non-negative number is 1 or 2 less than a multiple 
         of 20. So for example 38 and 39 return true, but 40 returns false. 
         (Hint: Think "mod".)
         less20(18) → true
         less20(19) → true
         less20(20) → false
         */

namespace Exercises.Tests
{
    [TestClass]
    public class Less20Tests
    {
        [TestMethod]
        public void ShouldReturnTrueWithInputWithinTwoOfMultiple()
        {
            //arrange
            Less20 multiples = new Less20();

            //act
            bool multipleCheck = multiples.IsLessThanMultipleOf20(78);

            //assert
            Assert.AreEqual(true, multipleCheck);
        }

        [TestMethod]
        public void ShouldReturnFalseWithInputOutsideTwoOfMultiple()
        {
            //arrange
            Less20 multiples = new Less20();

            //act
            bool multipleCheck = multiples.IsLessThanMultipleOf20(97);

            //assert
            Assert.AreEqual(false, multipleCheck);
        }

        [TestMethod]
        public void ShouldReturnFalseWithInputEqualToMultiple()
        {
            //arrange
            Less20 multiples = new Less20();

            //act
            bool multipleCheck = multiples.IsLessThanMultipleOf20(100);

            //assert
            Assert.AreEqual(false, multipleCheck);
        }
    }
}
