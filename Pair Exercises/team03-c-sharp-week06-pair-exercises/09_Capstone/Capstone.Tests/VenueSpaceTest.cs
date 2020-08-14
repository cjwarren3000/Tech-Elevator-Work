using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class VenueSpaceTest : ParentTest
    {
        [DataTestMethod]
        [DataRow("0", "All Year")]
        [DataRow("1", "Jan")]
        [DataRow("6", "Jun")]
        [DataRow("12", "Dec")]
        [DataRow("", "")]

        public void TestingToSeeIfMonthIsCorrect(string input, string expected)
        {
            //Arrange
            VenueSpace test = new VenueSpace();


            //Act
            string result = test.ConvertToMonth(input);

            //Assert
            Assert.AreEqual(expected, result);

        }
    }
}
