using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_io_part1_exercises_pair
{
    public class Counting
    {



        public static void GetCount()
        {

            int wordCount = 0;
            List<string> wordList = new List<string>();

            string currentFile = "C:\\Users\\Student\\team00-c-sharp-week04-pair-exercises\\16_FileIO_Reading_In";
            string lookingFile = "alices_adventures_in_wonderland.txt";

            string fullPath = Path.Combine(currentFile, lookingFile);

            try
            {
               
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    
                    while (!sr.EndOfStream)
                    {
                        
                        string line = sr.ReadLine();

                        string[] words = line.Split(' ');
                        foreach (string newWords in words)
                        {
                            if(newWords == "")
                            {

                            }
                            else
                            {
                                wordList.Add(newWords);
                            }
                            
                        }

                        wordCount = wordList.Count;
                        
                    }


                }


            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }













            int sentenceCount = 0;
            List<string> sentenceList = new List<string>();

            try
            {

                using (StreamReader sr = new StreamReader(fullPath))
                {

                    while (!sr.EndOfStream)
                    {

                        string line = sr.ReadLine();
                        if(line.Contains(". ") || line.Contains("! ") || line.Contains("? "))
                        {
                            string[] sentences = line.Split('.', '!', '?');

                            foreach (string newSentences in sentences)
                            {
                               
                                    sentenceList.Add(newSentences);

                            }
                        }

                        sentenceCount = sentenceList.Count;

                    }


                }


            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine("Total word count is: " + wordCount);
            
            Console.WriteLine("Total Sentence count is: " + sentenceCount);
            Console.ReadLine();
        }


    }
}
