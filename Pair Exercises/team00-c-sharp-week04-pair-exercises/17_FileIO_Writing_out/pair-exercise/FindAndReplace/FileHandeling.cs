using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAndReplace
{
    public class FileHandeling
    {
        public void ReadFile()
        {
            Console.WriteLine("Please input file path:");
            string filePath = Console.ReadLine();

            Console.WriteLine("Please input file name:");
            string fileName = Console.ReadLine();

            string outputFile = "output.txt";
            string fullPath = Path.Combine(filePath, fileName);
            string outputFullPath = Path.Combine(filePath, outputFile);

            Console.WriteLine("Please input the word you want replaced:");
            string wordToBeReplaced = Console.ReadLine();

            Console.WriteLine("Please input replacement word:");
            string replacementWord = Console.ReadLine();

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    using (StreamWriter sw = new StreamWriter(outputFullPath, true))
                    {
                        while (!sr.EndOfStream)
                        {

                            string line = sr.ReadLine();

                            string fixedLine = line.Replace(wordToBeReplaced, replacementWord);

                            sw.WriteLine(fixedLine);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
        }

    }
}

