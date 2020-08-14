using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

        /*
         Given an array of ints length 3, figure out which is larger between the first
         and last elements in the array, and set all the other elements to be that 
         value. Return the changed array.
         MakeArray([1, 2, 3]) → [3, 3, 3]
         MakeArray([11, 5, 9]) → [11, 11, 11]
         MakeArray([2, 11, 3]) → [3, 3, 3]
         */

namespace Exercises.Tests
{
    [TestClass]
    public class MaxEnd3Tests
    {
        [TestMethod]
        public void ShouldSetAllValuesEqualToFirstValue()
        {
            //arrange
            MaxEnd3 allSet = new MaxEnd3();
            int[] numbers = { 190, 5, 17 };
            int[] correctNumbers = { 190, 190, 190 };

            //act
            int[] newNumbers = allSet.MakeArray(numbers);

            //assert
            Assert.ReferenceEquals(correctNumbers, newNumbers);
        }

        [TestMethod]
        public void ShouldSetAllValuesEqualToLastValue()
        {
            //arrange
            MaxEnd3 allSet = new MaxEnd3();
            int[] numbers = { 19, 5, 1738 };
            int[] correctNumbers = { 1738, 1738, 1738 };

            //act
            int[] newNumbers = allSet.MakeArray(numbers);

            //assert
            Assert.ReferenceEquals(correctNumbers, newNumbers);
        }
    }
}
