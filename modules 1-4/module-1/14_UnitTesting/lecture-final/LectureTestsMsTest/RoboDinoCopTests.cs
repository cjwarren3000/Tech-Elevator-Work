using Lecture.Farming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LectureTestsMsTest
{
    [TestClass]
    public class RoboDinoCopTests
    {
        [TestMethod]
        public void RoboDinoCopNameShouldBeRoboCoptor()
        {
            // Arrange - setting up code to test
            RobotDinosaurPoliceOfficer cop = new RobotDinosaurPoliceOfficer();

            // Act - acting on the thing we're testing
            string name = cop.Name;

            // Assert - verifying correct behavior after act
            Assert.AreEqual("RoboCoptor", name, "Dude, your dino cop had a bad name");
        }

        [TestMethod]
        public void RoboDinoCopShouldSnoreWhenAsleep()
        {
            // Arrange
            RobotDinosaurPoliceOfficer cop = new RobotDinosaurPoliceOfficer();
            cop.IsAsleep = true;

            // Act
            string sound = cop.MakeSoundOnce();

            // Assert
            Assert.AreEqual("Zzzzzzzzzz", sound);
        }


        [TestMethod]
        public void RoboDinoCopShouldBuzzWhenCaffenated()
        {
            // Arrange
            RobotDinosaurPoliceOfficer cop = new RobotDinosaurPoliceOfficer();
            cop.IsAsleep = false;
            cop.IsCaffenated = true;

            // Act
            string sound = cop.MakeSoundOnce();
            cop.MakeSoundTwice();

            // Assert
            Assert.AreEqual("RED BULL???", sound);
        }

        [TestMethod]
        public void RoboDinoCopShouldStartAsleep()
        {
            // Arrange
            RobotDinosaurPoliceOfficer cop = new RobotDinosaurPoliceOfficer();

            // Act - no action is needed

            // Assert
            Assert.IsFalse(!cop.IsAsleep, "Cop didn't start asleep");

            if (!cop.IsAsleep)
            {
                Assert.Fail("Dude, the cop should start asleep! It's awake!");
            }
        }

        [TestMethod]
        public void RoboDinoCopShouldBeBatman()
        {
            Assert.Inconclusive("Matt, please implement this test!");
        }
    }
}
