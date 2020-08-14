using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 Given a string, return a new string made of every other char starting with the first, 
 so "Hello" yields "Hlo".
 GetBits("Hello") → "Hlo"	
 GetBits("Hi") → "H"	
 GetBits("Heeololeo") → "Hello"	
 */

namespace Exercises.Tests
{
    [TestClass]
    public class StringBitsTests
    {
        [TestMethod]
        public void ShouldReturnEveryOtherLetter()
        {
            //arrange
            StringBits newStringBits = new StringBits();

            //act
            string resultingString = newStringBits.GetBits("Godzilla");

            //assert

            Assert.AreEqual("Gdil", resultingString);
        }

        [TestMethod]
        public void ShouldReturnOnlyOneLetter()
        {
            //arrange
            StringBits newStringBits = new StringBits();

            //act
            string resultingString = newStringBits.GetBits("G");

            //assert

            Assert.AreEqual("G", resultingString);
        }

        [TestMethod]
        public void ShouldReturnEmptyString()
        {
            //arrange
            StringBits newStringBits = new StringBits();

            //act
            string resultingString = newStringBits.GetBits("");

            //assert

            Assert.AreEqual("", resultingString);
        }
    }
}
