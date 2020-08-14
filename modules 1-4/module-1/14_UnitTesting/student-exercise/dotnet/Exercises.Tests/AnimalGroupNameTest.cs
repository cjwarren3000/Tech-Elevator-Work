using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests
{
    [TestClass]
    public class AnimalGroupNameTest
    {
        [TestMethod]
        public void ShouldReturnAnimalGroupName()
        {
            //arrange
            AnimalGroupName animals = new AnimalGroupName();

            //act
            string elephantHerdNormal = animals.GetHerd("Elephant");
            

            //assert
            Assert.AreEqual("Herd", elephantHerdNormal);
        }

        [TestMethod]
        public void IsAnimalGroupNameCaseIndependant()
        {
            //arrange
            AnimalGroupName animals = new AnimalGroupName();

            //act
            string elephantHerdCapital = animals.GetHerd("ELEPHANT");
            string elephantHerdLower = animals.GetHerd("elephant");

            //assert
            Assert.AreEqual("Herd", elephantHerdCapital);
            Assert.AreEqual("Herd", elephantHerdLower);
        }

        [TestMethod]
        public void ShouldReturnUknownWithAnAnimalNotInDictionary()
        {
            //arrange
            AnimalGroupName animals = new AnimalGroupName();

            //act
            string platipusGroup = animals.GetHerd("Platipus");

            //assert
            Assert.AreEqual("unknown", platipusGroup);
        }

        [TestMethod]
        public void ShouldReturnUnknownIfNullInput()
        {
            //arrange
            AnimalGroupName animals = new AnimalGroupName();

            //act
            string nullString = animals.GetHerd(null);

            //assert
            Assert.AreEqual("unknown", nullString);
        }
    }
}
