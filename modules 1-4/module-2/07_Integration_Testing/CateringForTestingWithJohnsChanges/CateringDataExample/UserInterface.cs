using CateringDataExample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CateringDataExample
{
    class UserInterface
    {

        public void Run()
        {
            bool done = false;
            string selection = Menu();

            while (!done)
            {
                switch (selection.ToUpper())
                {
                    case "1":
                        DisplayCateringData();
                        break;

                    case "2":
                        WriteLogData();
                        break;

                    case "E":
                        done = true;
                        continue;

                    default:
                        Console.WriteLine("Try again.");
                        Console.WriteLine();
                        break;
                }

                selection = Menu();
            }
        }

        private string Menu()
        {
            string result = "";

            Console.WriteLine("List of products - 1");
            Console.WriteLine("Enter log item = 2");
            Console.WriteLine("End - E");
            Console.WriteLine();

            result = Console.ReadLine();
            Console.WriteLine();

            return result;
        }

        private void DisplayCateringData()
        {
            List<CateringItem> items = new List<CateringItem>();

            // get data from the database using a Data Access Object
            DatabaseAccess access = new DatabaseAccess();
            items =  access.GetInventoryList();

            foreach (CateringItem item in items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        private void WriteLogData()
        {
            bool result = false;

            Console.WriteLine("Enter log message");
            string message = Console.ReadLine();

            Console.WriteLine("Enter starting balance");
            decimal startValue = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter ending balance");
            decimal endValue = decimal.Parse(Console.ReadLine());

            //send data to the database using a Data Access Object
            DatabaseAccess access = new DatabaseAccess();
            result = access.WriteLogData(message, startValue, endValue);

            if (result)
            {
                Console.WriteLine("Sucess");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Failure");
                Console.WriteLine();
            }

            return;
        }
    }
}
