using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

       /*
       * Given an array of strings, return a Dictionary<string, int> with a key for 
       * each different string, with the value the 
       * number of times that string appears in the array.
       * 
       * ** A CLASSIC **
       * 
       * GetCount(["ba", "ba", "black", "sheep"]) → {"ba" : 2, "black": 1, "sheep": 1 }
       * GetCount(["a", "b", "a", "c", "b"]) → {"b": 2, "c": 1, "a": 2}
       * GetCount([]) → {}
       * GetCount(["c", "b", "a"]) → {"b": 1, "c": 1, "a": 1}
       * 
       */

namespace Exercises.Tests
{
    [TestClass]
    public class WordCountTests
    {
        [TestMethod]
        public void ShouldReturnDictionaryWithThreeUniqueStrings()
        {
            //arrange
            WordCount newWordCount = new WordCount();
            string[] input = { "this", "this", "is", "fun" };
            Dictionary<string, int> correctDict = new Dictionary<string, int>();

            correctDict.Add("this", 2);
            correctDict.Add("is", 1);
            correctDict.Add("fun", 1);

            //act
            Dictionary<string, int> wordCountDict = newWordCount.GetCount(input);

            //assert
            Assert.ReferenceEquals(correctDict, wordCountDict);
        }

        [TestMethod]
        public void ShouldReturnEmptyDictionaryWhenNoInput()
        {
            //arrange
            WordCount newWordCount = new WordCount();
            string[] input = { };
            Dictionary<string, int> correctDict = new Dictionary<string, int>();
            

            //act
            Dictionary<string, int> wordCountDict = newWordCount.GetCount(input);

            //assert
            Assert.ReferenceEquals(correctDict, wordCountDict);
        }

        [TestMethod]
        public void ShouldReturnDictionaryWithThreeUniqueStringsNoRepeats()
        {
            //arrange
            WordCount newWordCount = new WordCount();
            string[] input = { "this", "is", "fun" };
            Dictionary<string, int> correctDict = new Dictionary<string, int>();

            correctDict.Add("this", 1);
            correctDict.Add("is", 1);
            correctDict.Add("fun", 1);

            //act
            Dictionary<string, int> wordCountDict = newWordCount.GetCount(input);

            //assert
            Assert.ReferenceEquals(correctDict, wordCountDict);
        }
    }
}
