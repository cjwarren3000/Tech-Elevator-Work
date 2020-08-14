using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given an array of strings, return a Dictionary<string, int> with 
         * a key for each different string, with the value the
         * number of times that string appears in the array.
         *
         * ** A CLASSIC **
         *
         * WordCount(["ba", "ba", "black", "sheep"]) → {"ba" : 2, "black": 1, "sheep": 1 }
         * WordCount(["a", "b", "a", "c", "b"]) → {"b": 2, "c": 1, "a": 2}
         * WordCount([]) → {}
         * WordCount(["c", "b", "a"]) → {"b": 1, "c": 1, "a": 1}
         *
         */
        public Dictionary<string, int> WordCount(string[] words)
        {
            Dictionary<string, int> wordCountDict = new Dictionary<string, int>();
            //this sets up my dictionary for future use

            string[] wordsTwo = words;
            //this adds a copy of the array to check against
            List<int> timesRepeated = new List<int>();
            //this will hold all the repeated values

            foreach (string word in words)
            {
                int repeated = 0;
                foreach (string words2 in wordsTwo)
                {
                    if (word == words2)
                    {
                        repeated++;
                    }

                }
                timesRepeated.Add(repeated);
            }
            //this checks how many times a word is repeated


            int listLocation = -1;
            //this provides a starting point for pulling the count from the list

            foreach (string word in words)
            {
                listLocation++;

                if (wordCountDict.ContainsKey(word))
                {

                }
                else
                {
                    wordCountDict.Add(word, timesRepeated[listLocation]);

                }
            }
            //this loop adds words and values to the dictionary

            return wordCountDict;
        }

    }
}


