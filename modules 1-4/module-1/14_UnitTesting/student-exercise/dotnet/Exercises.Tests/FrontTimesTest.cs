using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

        /*
        Given a string and a non-negative int n, we'll say that the front of the string 
        is the first 3 chars, or whatever is there if the string is less than length 3. 
        Return n copies of the front;
        frontTimes("Chocolate", 2) → "ChoCho"	
        frontTimes("Chocolate", 3) → "ChoChoCho"	
        frontTimes("Abc", 3) → "AbcAbcAbc"	
        */

namespace Exercises.Tests
{
    [TestClass]
    public class FrontTimesTest
    {
        [TestMethod]
        public void ShouldReturnRepeatedFullStringWith3CharacterInput()
        {
            //arrange
            FrontTimes frontLoaded = new FrontTimes();

            //act
            string rat = frontLoaded.GenerateString("rat", 3);

            //assert
            Assert.AreEqual("ratratrat", rat);
        }

        [TestMethod]
        public void ShouldReturnRepeatedFullStringWith1CharacterInput()
        {
            //arrange
            FrontTimes frontLoaded = new FrontTimes();

            //act
            string t6 = frontLoaded.GenerateString("t", 6);

            //assert
            Assert.AreEqual("tttttt", t6);
        }

        [TestMethod]
        public void ShouldReturnFirst3CharactersWithLongerThan3CharacterInput()
        {
            //arrange
            FrontTimes frontLoaded = new FrontTimes();

            //act
            string goblin = frontLoaded.GenerateString("goblin", 4);

            //assert
            Assert.AreEqual("gobgobgobgob", goblin);
        }
    }
}
