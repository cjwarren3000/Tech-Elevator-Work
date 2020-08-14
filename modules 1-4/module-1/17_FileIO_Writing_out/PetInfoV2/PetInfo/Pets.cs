using System;
using System.Collections.Generic;

namespace PetInfo
{
    public class Pets
    {
        private List<Pet> pets = new List<Pet>();

        public Pets()
        {
            pets = ReadPets();
        }

        public Pet[] PetList
        {
            get
            {
                return pets.ToArray();
            } 
        }

        // add to pet collection and write pet collection to file
        public bool AddPet(Pet pet)
        {
            throw new NotImplementedException();
        }

        // remove pet from collection and write to file
        public bool RemovePet(int petNumber)
        {
            throw new NotImplementedException();
        }

        //read pet from file
        private List<Pet> ReadPets()
        {
            FileAccess fa =new FileAccess();
            return fa.ReadPets();
        }

        // wrfite pets to file
        public bool WritePets(List<Pet> pets)
        {
            throw new NotImplementedException();
        }
    }
}
