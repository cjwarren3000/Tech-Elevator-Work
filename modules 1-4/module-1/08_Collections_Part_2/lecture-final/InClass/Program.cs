using System;
using System.Collections.Generic;
using System.Linq;

namespace InClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Dictionary<int, string> myDict = new Dictionary<int, string>();

            myDict.Add(17, "Smith");
            myDict.Add(18, "Jones");
            myDict.Add(19, "Fulton");
            myDict.Add(22, "Eland");

            foreach(KeyValuePair<int,string> item in myDict)
            {
                Console.WriteLine(item.Value);
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~");

            myDict[19] = "Cole";

            foreach (KeyValuePair<int, string> item in myDict)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~");

            // myDict.Add(19, "Larson");
            myDict[19] = "Larson";

            foreach (KeyValuePair<int, string> item in myDict)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
           


            KeyValuePair<int, string>[] result = myDict.ToArray();

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i].Value);
            }


            if (myDict.ContainsKey(17))
            {
                Console.WriteLine("has 17");
            }

            if (myDict.ContainsValue("Fulton"))
            {
                Console.WriteLine("has Fulton");
            }

            foreach (KeyValuePair<int, string> item in myDict)
            {
                if (item.Value == "Jones")
                {
                    Console.WriteLine("found jones at key "+ item.Key);
                }
            }

            Console.WriteLine("~~~~~~~~~~~~~~~~");

            HashSet<int> numbers = new HashSet<int>();

            numbers.Add(3);
            numbers.Add(3);
            numbers.Add(1);
            numbers.Add(4);
            numbers.Add(4);
            numbers.Add(5);
            numbers.Add(5);
            numbers.Add(3);

            foreach(int item in numbers)
            {
                Console.WriteLine(item);
            }

            List<int> hashList =  numbers.ToList();

            Console.ReadLine();
        }
    }
}
