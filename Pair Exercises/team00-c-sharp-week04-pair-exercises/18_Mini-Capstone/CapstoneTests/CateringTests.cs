using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CapstoneTests
{
    [TestClass]
    public class CateringTests
  
    {

        [DataTestMethod]
        [DataRow(700, 0, 700)]
        [DataRow(5000, 0, 5000)]
        [DataRow(700, 578, 1278)]
        [DataRow(0, 0, 0)]
        public void ShouldBeAbleToAddMoneyUnder5000Total(double input, double accountBalance, double expectedResult)
        {
            //arrange
            Catering newCatering = new Catering();
            //act
           double balance = newCatering.AddMoneyToBalance(input, accountBalance);
            //assert
            Assert.AreEqual(expectedResult, balance);
        }

        [DataTestMethod]
        [DataRow(5000, 1, 1)]
        [DataRow(909094, 0, 0)]
        [DataRow(2, 4999, 4999)]
        public void ShouldNotBeABleToAddMoneyOver5000(double input, double accountBalance, double expectedResult)
        {
            //arrange
            Catering newCatering = new Catering();
            //act
            double balance = newCatering.AddMoneyToBalance(input, accountBalance);
            //assert
            Assert.AreEqual(expectedResult, balance);
        }


       [TestMethod]
       public void ShouldReduceAccountBalanceWhenPurchasingItems()
        {
            //arrange
            Catering newCatering = new Catering();
            //act
            double result = newCatering.RemoveMoney(500, newCatering.cateringList[0], 5, "B1");
            double expectedResult = 492.5;
            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldNotBeAbleToPurchaseMoreItemsThanAreInStock()
        {
            //arrange
            Catering newCatering = new Catering();
            //act
            double result = newCatering.RemoveMoney(500, newCatering.cateringList[0], 51, "B1");
            double expectedResult = 500;
            //assert
            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public void ShouldNotBeAbleToPurchaseWithoutEnoughMoney()
        {
            //arrange
            Catering newCatering = new Catering();
            //act
            double result = newCatering.RemoveMoney(5, newCatering.cateringList[0], 30, "B1");
            double expectedResult = 5;
            //assert
            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public void ShouldNotBeAbleToPurchaseSoldOutItems()
        {
            //arrange
            Catering newCatering = new Catering();
            //act
            CateringItem soldOut = newCatering.cateringList[0];
            soldOut.Amount -= 50;
            double result = newCatering.RemoveMoney(500, soldOut, 2, "B1");
            double expectedResult = 500;
            //assert
            Assert.AreEqual(expectedResult, result);

        }
    }
}
