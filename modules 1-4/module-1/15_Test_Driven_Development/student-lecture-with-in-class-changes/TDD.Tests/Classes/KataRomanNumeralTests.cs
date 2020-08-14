using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Classes;

namespace TDD.Tests.Classes
{
    [TestClass]
    public class KataRomanNumeralTests
    {
        KataRomanNumeral testObj;

        [TestInitialize]
        public void Init()
        {
            testObj = new KataRomanNumeral();

        }

        [DataTestMethod]
        [DataRow(1, "I")]
        [DataRow(2, "II")]
        [DataRow(3, "III")]
        [DataRow(4, "IV")]  
        public void ConvertRomanNumbersLessThanFive(int input, string expectedResult)
        {
            //Act
            string result = testObj.ConvertToRomanNumeral(input);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(5, "V")]
        [DataRow(6, "VI")]
        [DataRow(7, "VII")]
        [DataRow(9, "IX")] //replace this
        public void ConvertRomanNumbersLessThanTen(int input, string expectedResult)
        {
            //Act
            string result = testObj.ConvertToRomanNumeral(input);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(10, "X")]
        [DataRow(20, "XX")]
        [DataRow(21, "XXI")]
        [DataRow(49, "XLIX")] //replace this
        public void ConvertRomanNumbersLessThanFifty(int input, string expectedResult)
        {
            //Act
            string result = testObj.ConvertToRomanNumeral(input);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(50, "L")]
        [DataRow(70, "LXX")]
        [DataRow(90, "XC")]  
        [DataRow(99, "XCIX")] 
        public void ConvertRomanNumbersLessThanOneHundred(int input, string expectedResult)
        {
            //Act
            string result = testObj.ConvertToRomanNumeral(input);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(100, "C")]
        [DataRow(200, "CC")]
        [DataRow(330, "CCCXXX")]
        [DataRow(400, "CCCC")] //replace this
        public void ConvertRomanNumbersLessThanFiveHundred(int input, string expectedResult)
        {
            //Act
            string result = testObj.ConvertToRomanNumeral(input);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(500, "D")]
        [DataRow(600, "DC")]
        [DataRow(800, "DCCC")]
        [DataRow(900, "DCCCC")] //replace this
        public void ConvertRomanNumbersLessThanOneThousand(int input, string expectedResult)
        {
            //Act
            string result = testObj.ConvertToRomanNumeral(input);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(1000, "M")]
        [DataRow(2000, "MM")]
        [DataRow(2020, "MMXX")]
        public void ConvertRomanNumbersGreaterThanOneThousand(int input, string expectedResult)
        {
            //Act
            string result = testObj.ConvertToRomanNumeral(input);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }




    }
}
