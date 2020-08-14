using Lecture.Farming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LectureTestsMsTest
{
    [TestClass]
    public class FarmTest
    {
        [TestMethod]
        public void FarmShouldIncludeTrogdor()
        {
            // Arrange
            Farm farm = new Farm();

            // Act
            Dragon dragon = farm.Trogdor;

            // Assert
            Assert.IsNotNull(dragon);
        }

        [TestMethod]
        public void FarmTrogdorShouldBeDifferentThanMyDragon()
        {
            // Arrange
            Farm farm = new Farm();
            Dragon myDragon = new Dragon();

            // Act
            Dragon trogdor = farm.Trogdor;

            // Assert
            Assert.AreNotSame(trogdor, myDragon);
        }

        [TestMethod]
        public void FarmProduceShouldContainCompilerErrors()
        {
            // Arrange
            Farm farm = new Farm();

            // Act
            List<string> produce = farm.Produce;

            // Assert
            CollectionAssert.Contains(produce, "Compiler Errors");
        }

        [TestMethod]
        public void FarmProduceShouldNotContainJava()
        {
            // Arrange
            Farm farm = new Farm();

            // Act
            List<string> produce = farm.Produce;

            // Assert
            CollectionAssert.DoesNotContain(produce, "Java");
        }

        [TestMethod]
        public void FarmShouldNotContainNullAnimals()
        {
            // Arrange
            Farm farm = new Farm();

            // Act
            List<ISingAbout> animals = farm.Animals;

            // Assert
            CollectionAssert.AllItemsAreNotNull(animals);
        }

        [TestMethod]
        public void FarmShouldNotContainDuplicateAnimals()
        {
            // Arrange
            Farm farm = new Farm();

            // Act
            List<ISingAbout> animals = farm.Animals;

            // Assert
            CollectionAssert.AllItemsAreUnique(animals);
        }

        [TestMethod]
        public void FarmProduceHasAnEquivalentList()
        {
            // Arrange
            Farm farm = new Farm();
            List<string> Produce = new List<string>();
            Produce.Add("Wheat");
            Produce.Add("Carrots");
            Produce.Add("C# Code");
            Produce.Add("Potatoes");
            Produce.Add("Oranges");
            // Produce.Add("Compiler Errors");

            // Act
            List<string> actual = farm.Produce;

            // Assert
            CollectionAssert.AreEquivalent(Produce, actual);
        }


        [TestMethod]
        public void FarmProduceHasAnEqualList()
        {
            // Arrange
            Farm farm = new Farm();
            List<string> Produce = new List<string>();
            Produce.Add("Carrots");
            Produce.Add("Potatoes");
            Produce.Add("Wheat");
            Produce.Add("Oranges");
            //Produce.Add("Java");
            Produce.Add("C# Code");
            // Produce.Add("Compiler Errors");

            // Act
            List<string> actual = farm.Produce;

            // Assert
            CollectionAssert.AreEqual(Produce, actual);
        }
    }
}
