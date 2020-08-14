using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
   
    [TestClass]
    public class KataPrimeFactorsTests
    {
        [DataTestMethod]
        [DataRow(50, new int[] { 2, 5, 5 })]
        [DataRow(27, new int[] { 3, 3, 3 })]
        [DataRow(8, new int[] { 2, 2, 2 })]
        [DataRow(7, new int[] { 7 })]
        [DataRow(5944, new int[] { 2, 2, 2, 743 })]
        public void ShouldReturnListContainingPrimeFactorsOfInput(int input, int[] expectedResult)
        {
            //Arrange

            KataPrimeFactors newPrimeFactors = new KataPrimeFactors();
            //Act

            List<int> resultingList = newPrimeFactors.Factorize(input);
            //Assert

            CollectionAssert.AreEqual(expectedResult, resultingList);
        }
    }
}
