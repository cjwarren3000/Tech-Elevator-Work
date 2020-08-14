using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

        /*
       You and your date are trying to get a table at a restaurant. The parameter "you" is the stylishness
       of your clothes, in the range 0..10, and "date" is the stylishness of your date's clothes. The result
       getting the table is encoded as an int value with 0=no, 1=maybe, 2=yes. If either of you is very 
       stylish, 8 or more, then the result is 2 (yes). With the exception that if either of you has style of 
       2 or less, then the result is 0 (no). Otherwise the result is 1 (maybe).
       dateFashion(5, 10) → 2
       dateFashion(5, 2) → 0
       dateFashion(5, 5) → 1
       */


namespace Exercises.Tests
{
    [TestClass]
    public class DateFashionTest
    {
        [TestMethod]
        public void ShouldReturn2WithHighStyleMediumStyle()
        {
            //arrange
            DateFashion fashion = new DateFashion();

            //act
            int reservationResult = fashion.GetATable(4, 10);

            //assert
            Assert.AreEqual(2, reservationResult);
        }

        [TestMethod]
        public void ShouldReturn0WithHighStyleLowStyle()
        {
            //arrange
            DateFashion fashion = new DateFashion();

            //act
            int reservationResult = fashion.GetATable(10, 0);

            //assert
            Assert.AreEqual(0, reservationResult);
        }

        [TestMethod]
        public void ShouldReturn1WithMediumStyleMediumStyle()
        {
            //arrange
            DateFashion fashion = new DateFashion();

            //act
            int reservationResult = fashion.GetATable(5, 5);

            //assert
            Assert.AreEqual(1, reservationResult);
        }
    }
}
