using System;
using System.Collections.Generic;
using System.IO;

namespace PetInfo
{
    public class FileAccess
    {
        private string directory = @"c:\petinfo";
        private string filename = @"petinfo.csv";

        public List<Pet> ReadPets()
        {
            List<Pet> pets = new List<Pet>();

            string fullPath = Path.Combine(directory, filename);
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string unsplit = sr.ReadLine();
                        string[] split = unsplit.Split('|');

                        Pet temp = new Pet();
                        temp.Number = int.Parse(split[0]);
                            temp.Name = split[1];
                        temp.FamilyName = split[2];
                        temp.PetType = split[3];

                        pets.Add(temp);
                    }
                }
            }
            catch
            {
                pets = new List<Pet>();
            }

            return  pets;
        }

        // replaces currenct contents of file with collection
        public bool WritePets(List<Pet> pets)
        {
            throw new NotImplementedException();
        }
    }
}
