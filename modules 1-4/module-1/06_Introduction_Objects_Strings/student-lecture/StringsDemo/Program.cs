using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Ada Lovelace";

            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e

            Console.WriteLine("First and Last character.");
            char first = name[0];
            Console.WriteLine(first);
            Console.WriteLine(name[name.Length - 1]);

            // Console.WriteLine("First and Last Character. ");

            // 2. How do we write code that prints out the first three characters
            // Output: Ada

            Console.WriteLine("First 3 characters: " + name.Substring(0, 3));

            // Console.WriteLine("First 3 characters: ");

            // 3. Now print out the first three and the last three characters
            // Output: Adaace

            Console.WriteLine("First 3 characters: " + name.Substring(0, 3));
            Console.WriteLine("Last 3 characters: " + name.Substring(name.Length - 3, 3));

            // Console.WriteLine("Last 3 characters: ");

            // 4. What about the last word?
            // Output: Lovelace

            string[] result = name.Split(' ');
            string lastName = result[1];

            Console.WriteLine("Last word: " + lastName);


            // 5. Does the string contain inside of it "Love"?
            // Output: true

            bool contains = name.Contains("Love");

            Console.WriteLine("Contains \"Love\" " + contains);

            // 6. Where does the string "lace" show up in name?
            // Output: 8

            int position = name.IndexOf("lace");

            Console.WriteLine("Index of \"lace\": " + position);

            // 7. How many 'a's OR 'A's are in name?

            int howManyAs = 0;
            string testNameForAs = name.ToLower();
            for(int i = 0; i < name.Length; i++)
            {
                if (testNameForAs.Substring(i, 1) == "a")
                {
                    howManyAs++;
                }
            }
            Console.WriteLine("Number of 'a's: " + howManyAs);

            // Console.WriteLine("Number of \"a's\": ");

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"


            Console.WriteLine(name.Replace("Ada", "Ada, Countess of Lovelace"));


            // 9. Set name equal to null.

            name = null;

            // 10. If name is equal to null or "", print out "All Done".

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("All Done");
            }

            Console.ReadLine();
        }
    }
}