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
         * Given an array of strings, return a Dictionary<string, Boolean> where each different string is a key and 
         * value is true only if that string appears 2 or more times in the array.
         *
         * WordMultiple(["a", "b", "a", "c", "b"]) → {"b": true, "c": false, "a": true}
         * WordMultiple(["c", "b", "a"]) → {"b": false, "c": false, "a": false}
         * WordMultiple(["c", "c", "c", "c"]) → {"c": true}
         *
         */
        public Dictionary<string, bool> WordMultiple(string[] words)
        {
            Dictionary<string, bool> repeatDict = new Dictionary<string, bool>();
            string[] arrayCopy = words;

            foreach (string word in words)
            {
                if (repeatDict.ContainsKey(word) == false)
                {
                    int repeatedWord = 0;
                    foreach (string wordCopy in arrayCopy)
                    {
                        if (wordCopy == word)
                        {
                            repeatedWord++;
                        }

                    }
                    if (repeatedWord >= 2)
                    {
                        repeatDict.Add(word, true);
                    }
                    else if (repeatedWord <= 1)
                    {
                        repeatDict.Add(word, false);
                    }

                }
                else if (repeatDict.ContainsKey(word) == true)
                {

                }

            }
            return repeatDict;
        }
    }
}
