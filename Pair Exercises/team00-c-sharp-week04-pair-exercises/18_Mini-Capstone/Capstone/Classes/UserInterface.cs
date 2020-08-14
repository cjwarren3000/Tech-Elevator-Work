using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        public double accountBalanceSum = 0.00F;

        Catering catering = new Catering();
        FileAccess newFileAccssed = new FileAccess();


        public void RunInterface()
        {
            bool done = false;
            while (!done)
            {
                StartMenu();
                string userOption = Console.ReadLine();
                Console.WriteLine();

                switch (userOption)
                {
                    case "1":
                        DisplayCateringItems(catering);
                        Console.WriteLine();
                        break;
                    case "2":
                        DisplayOption2();
                        break;
                    case "3":
                        done = true;
                        break;

                }
            }

        }




        public void DisplayOption2()
        {




            bool done = false;
            while (!done)
            {

                Menu2();
                Console.WriteLine("Current Account Balance: $" + accountBalanceSum);
                Console.WriteLine();

                string userOption = Console.ReadLine();


                switch (userOption)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Enter amount to add: ");
                        double moneyAdded = double.Parse(Console.ReadLine());
                        accountBalanceSum = catering.AddMoneyToBalance(moneyAdded, accountBalanceSum);
                        Console.WriteLine();

                        newFileAccssed.WriteAuditLog1(moneyAdded, accountBalanceSum);

                        break;
                    case "2":
                        Console.WriteLine();
                        accountBalanceSum = Menu2Option2(catering, accountBalanceSum);
                        break;
                    case "3":
                        Console.WriteLine();
                        double totalSpent = 0;
                        catering.ReturnChange(accountBalanceSum);
                        Console.WriteLine("Receipt");
                        foreach (CateringItem item in catering.itemsPurchased)
                        {
                            Console.WriteLine($"{item.Amount} {item.Name} ${item.Price} per ${item.TotalPrice} total {item.Type}");
                            totalSpent += double.Parse(item.TotalPrice);
                        }
                        Console.WriteLine("Total Spent: " + "$" + totalSpent);
                        Console.WriteLine();
                        Console.WriteLine("Your change is: " + catering.changeDict["Twenties"] + " Twenties, " +
                            catering.changeDict["Tens"] + " Tens, " + catering.changeDict["Fives"] + " Fives, " +
                            catering.changeDict["Ones"] + " Ones and " + catering.changeDict["Quarters"] + " Quarters, " +
                            catering.changeDict["Dimes"] + " Dimes, " + catering.changeDict["Nickels"] + " Nickels.");

                        newFileAccssed.WriteAuditLog3(accountBalanceSum);

                        accountBalanceSum = 0;
                        catering.itemsPurchased.RemoveRange(0, catering.itemsPurchased.Count);
                        return;


                }
            }
        }
        private void StartMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine();
            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");
            Console.WriteLine();
        }
        private void Menu2()
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine();
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");

        }

        private void DisplayCateringItems(Catering catering)
        {
            CateringItem[] tempCateringArray = catering.cateringList;

            for (int i = 0; i < tempCateringArray.Length; i++)
            {
                Console.WriteLine(tempCateringArray[i].ToString());
            }
        }


        private double Menu2Option2(Catering catering, double accountBalanceSum)
        {
            Console.WriteLine("Enter the item ID you would like to purchase");
            string desiredID = Console.ReadLine();

            if (catering.GetCateringItem(desiredID) == null)
            {
                Console.WriteLine();
                return accountBalanceSum;
            }
            CateringItem singleItem = catering.GetCateringItem(desiredID);

            Console.WriteLine("Enter the number of items you would like to purchase");
            int desiredAmount = int.Parse(Console.ReadLine());
            Console.WriteLine();



            if (singleItem.Amount == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Product is Sold out");
                Console.WriteLine();
                return accountBalanceSum;
            }
            else if (desiredAmount > singleItem.Amount)
            {
                Console.WriteLine();
                Console.WriteLine("Insufficient Stock");
                Console.WriteLine();
                return accountBalanceSum;
            }
            else if (accountBalanceSum < singleItem.Price * desiredAmount)
            {
                Console.WriteLine();
                Console.WriteLine("Insufficient Funds");
                Console.WriteLine();
                return accountBalanceSum;
            }

            newFileAccssed.WriteAuditLog2(desiredAmount, desiredID, accountBalanceSum.ToString());

            return catering.RemoveMoney(accountBalanceSum, singleItem, desiredAmount, desiredID);


        }
        
        
    }
}

