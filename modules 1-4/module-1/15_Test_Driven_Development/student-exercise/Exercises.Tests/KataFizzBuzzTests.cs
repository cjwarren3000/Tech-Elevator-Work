using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass()]
    public class KataFizzBuzzTests
    {
        [DataTestMethod]
        [DataRow(6, "Fizz.")]
        [DataRow(37, "Fizz.")]
        public void ShouldReturnFizzIfDivisibleBy3OrIncludes3(int input, string expectedResult)
        {
            //arrange
            KataFizzBuzz newFizzBuzz = new KataFizzBuzz();
            //act
            string actualresult = newFizzBuzz.FizzBuzz(input);

            //assert
            Assert.AreEqual(expectedResult, actualresult);

        }

        [DataTestMethod]
        [DataRow(10, "Buzz.")]
        [DataRow(54, "Buzz.")]
        [DataRow(53, "FizzBuzz.")]
        public void ShouldReturnBuzzIfDivisibleBy5OrContains5AndOverridesRuleAbout3(int input, string expectedResult)
        {
            //arrange
            KataFizzBuzz newFizzBuzz = new KataFizzBuzz();
            //act
            string actualResult = newFizzBuzz.FizzBuzz(input);

            //assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [DataTestMethod]
        [DataRow(15, "FizzBuzz.")]
        [DataRow(30, "FizzBuzz.")]
        [DataRow(53, "FizzBuzz.")]
        [DataRow(35, "FizzBuzz.")]
        public void ShouldReturnFizzBuzzIfDivisibleBy3And5OrIfContains3And5AndOverridesRuleAbout3And5(int input, string expectedResult)
        {
            //arrange
            KataFizzBuzz newFizzBuzz = new KataFizzBuzz();
            //act
            string actualResult = newFizzBuzz.FizzBuzz(input);

            //assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [DataTestMethod]
        [DataRow(1, "1")]
        [DataRow(7, "7")]
        [DataRow(53, "FizzBuzz.")]
        [DataRow(17, "17")]
        [DataRow(98, "98")]
        [DataRow(77, "77")]
        public void ShouldReturnNumberStringIfWithin1And100AndNotDivisibleAndNotFollowingOtherRules(int input, string expectedResult)
        {
            //arrange
            KataFizzBuzz newFizzBuzz = new KataFizzBuzz();
            //act
            string result = newFizzBuzz.FizzBuzz(input);

            //assert
            Assert.AreEqual(expectedResult, result);

        }

        [DataTestMethod]
        [DataRow(0, "")]
        [DataRow(9001, "")]
        [DataRow(-356, "")]
        [DataRow(160, "")]
        [DataRow(1893, "")]
        [DataRow(7364, "")]
        public void ShouldReturnEmptyStringIfInputIsOver100OrUnder1(int input, string expectedResult)
        {
            //arrange
            KataFizzBuzz newFizzBuzz = new KataFizzBuzz();
            //act
            string result = newFizzBuzz.FizzBuzz(input);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

    }
}
