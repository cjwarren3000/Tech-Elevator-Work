using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Capstone.Tests
{
    [TestClass]
    public class VenueAccessTests : ParentTest
    {
        [TestMethod]
        public void VenueAccessTestToGetListOfVenues()
        {
            //Arrange
            VenueAccess test = new VenueAccess(connectionString);
            List<Venue> testList = new List<Venue>();

            //Act
            testList = test.VenueList();
            int count = testList.Count;

            //Assert
            Assert.AreNotEqual(0, count);
        }

        [TestMethod]
        public void VenueAccessTestToGetListOfSpaces()
        {
            //Arrange
            VenueAccess test = new VenueAccess(connectionString);
            List<VenueSpace> testList = new List<VenueSpace>();
            string description = "This venue has plenty of \"property\" to enjoy. Roll the dice and check out all of our spaces.";
            Venue tester = new Venue(1, "Hidden Owl Eatery", 1, description);

            //Act
            testList = test.DisplayVenueSpace(tester);
            int count = testList.Count;

            //Assert
            Assert.AreNotEqual(0, count);
        }
    }
}
