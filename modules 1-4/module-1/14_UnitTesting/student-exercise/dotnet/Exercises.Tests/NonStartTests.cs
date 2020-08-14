using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

        /*
         Given 2 strings, return their concatenation, except omit the first char of 
         each. The strings will be at least length 1.
         GetPartialString("Hello", "There") → "ellohere"
         GetPartialString("java", "code") → "avaode"	
         GetPartialString("shotl", "java") → "hotlava"	
         */

namespace Exercises.Tests
{
    [TestClass]
    public class NonStartTests
    {
        [TestMethod]
        public void ShouldReturnConcatenationWithoutFirstCharacterBothOverLengthOne()
        {
            //assert
            NonStart newClass = new NonStart();

            //act
            string resultingString = newClass.GetPartialString("TThis", "Wworks");

            //assert
            Assert.AreEqual("Thisworks", resultingString);
        }

        [TestMethod]
        public void ShouldReturnEmptyStringWithBothLenthOne()
        {
            //assert
            NonStart newClass = new NonStart();

            //act
            string resultingString = newClass.GetPartialString("T", "W");

            //assert
            Assert.AreEqual("", resultingString);
        }

        [TestMethod]
        public void ShouldReturnOneStringMinusFirstCharacterWithOnlyOneStringOverLengthOne()
        {
            //assert
            NonStart newClass = new NonStart();

            //act
            string resultingString = newClass.GetPartialString("Hhelp me", "y");

            //assert
            Assert.AreEqual("help me", resultingString);
        }
    }
}
