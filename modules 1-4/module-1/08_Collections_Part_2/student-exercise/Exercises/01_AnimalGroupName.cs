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
         * Given the name of an animal, return the name of a group of that animal
         * (e.g. "Elephant" -> "Herd", "Rhino" - "Crash").
         *
         * The animal name should be case insensitive so "elephant", "Elephant", and
         * "ELEPHANT" should all return "herd".
         *
         * If the name of the animal is not found, null, or empty, return "unknown".
         *
         * Rhino -> Crash
         * Giraffe -> Tower
         * Elephant -> Herd
         * Lion -> Pride
         * Crow -> Murder
         * Pigeon -> Kit
         * Flamingo -> Pat
         * Deer -> Herd
         * Dog -> Pack
         * Crocodile -> Float
         *
         * AnimalGroupName("giraffe") → "Tower"
         * AnimalGroupName("") -> "unknown"
         * AnimalGroupName("walrus") -> "unknown"
         * AnimalGroupName("Rhino") -> "Crash"
         * AnimalGroupName("rhino") -> "Crash"
         * AnimalGroupName("elephants") -> "unknown"
         *
         */
        public string AnimalGroupName(string animalName)
        {
            Dictionary<string, string> groupNameDict = new Dictionary<string, string>();

            groupNameDict.Add("rhino", "Crash");
            groupNameDict.Add("giraffe", "Tower");
            groupNameDict.Add("elephant", "Herd");
            groupNameDict.Add("lion", "Pride");
            groupNameDict.Add("crow", "Murder");
            groupNameDict.Add("pigeon", "Kit");
            groupNameDict.Add("flamingo", "Pat");
            groupNameDict.Add("deer", "Herd");
            groupNameDict.Add("dog", "Pack");
            groupNameDict.Add("crocodile", "Float");

            string animalNameLower = animalName.ToLower();

            if (groupNameDict.ContainsKey(animalNameLower))
            {
                return groupNameDict[animalNameLower];
            }
            return "unknown";
        }
    }
}
