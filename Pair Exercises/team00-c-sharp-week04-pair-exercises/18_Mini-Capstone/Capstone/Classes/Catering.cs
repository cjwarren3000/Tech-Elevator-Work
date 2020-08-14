using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {


        // This class should contain all the "work" for catering


        public List<CateringItem> catering = new List<CateringItem>();
        FileAccess cIFileAccess = new FileAccess();

        public List<CateringItem> itemsPurchased = new List<CateringItem>();

        public Catering()
        {
            catering = cIFileAccess.GetAndReadProductFile();
        }

        public CateringItem[] cateringList
        {
            get
            {
                return catering.ToArray();
            }
        }

        public Dictionary<string, double> changeDict = new Dictionary<string, double>() {
            { "Twenties", 0 },
            { "Tens", 0 },
            { "Fives", 0 },
            { "Ones", 0 },
            { "Quarters", 0 },
            { "Dimes", 0 },
            { "Nickels", 0 },
            };

        public CateringItem GetCateringItem(string desiredID)
        {
            foreach (CateringItem item in catering)
            {
                if (item.Code == desiredID)
                {
                    return item;
                }
            }
            Console.WriteLine("Item Number does not exist");
            return null;

        }

        public double AddMoneyToBalance(double moneyAdded, double accountBalanceSum)
        {



            if (accountBalanceSum + moneyAdded <= 5000)
            {
                accountBalanceSum += moneyAdded;
            }
            else if (accountBalanceSum + moneyAdded > 5000)
            {
                Console.WriteLine("You cannot have more than $5,000");
            }
            return accountBalanceSum;
        }

        public double RemoveMoney(double accountBalanceSum, CateringItem singleItem, int desiredAmount, string desiredID)
        {
            CateringItem purchasedItem = new CateringItem();
            purchasedItem.Amount = desiredAmount;
            purchasedItem.Name = singleItem.Name;
            purchasedItem.Price = singleItem.Price;
            purchasedItem.Type = singleItem.Type;
            purchasedItem.Code = singleItem.Code;
            purchasedItem.TotalPrice = (desiredAmount * singleItem.Price).ToString();


            if (desiredAmount <= singleItem.Amount && singleItem.Price * desiredAmount <= accountBalanceSum)
            {
                itemsPurchased.Add(purchasedItem);

                singleItem.Amount -= desiredAmount;
                accountBalanceSum -= (singleItem.Price * desiredAmount);
                return accountBalanceSum;
            }


            return accountBalanceSum;
        }

        public Dictionary<string, double> ReturnChange(double accountBalanceSum)
        {

            if (accountBalanceSum.ToString().Contains('.'))
            {
                string[] splitChange = accountBalanceSum.ToString().Split('.');
                if (splitChange[1].Length == 1)
                {
                    splitChange[1] = splitChange[1] + "0";
                }

                int dollar = int.Parse(splitChange[0]);
                int change = int.Parse(splitChange[1]);
                int remainder = 0;

                changeDict["Twenties"] = dollar / 20;
                remainder = dollar % 20;
                changeDict["Tens"] = remainder / 10;
                remainder = remainder % 10;
                changeDict["Fives"] = remainder / 5;
                remainder = remainder % 5;
                changeDict["Ones"] = remainder;

                changeDict["Quarters"] = change / 25;
                remainder = change % 25;
                changeDict["Dimes"] = remainder / 10;
                remainder = remainder % 10;
                changeDict["Nickels"] = remainder / 5;




            }
            else
            {
                int remainder = 0;

                changeDict["Twenties"] = (int)accountBalanceSum / 20;
                remainder = (int)accountBalanceSum % 20;
                changeDict["Tens"] = remainder / 10;
                remainder = remainder % 10;
                changeDict["Fives"] = remainder / 5;
                remainder = remainder % 5;
                changeDict["Ones"] = remainder;
            }



            return changeDict;
        }

    }


}






