using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo
{
    public class Pet
    {
        public Pet(int number, string name,
            string familyName, string petType)
        {
            Number = number;
            Name = name;
            FamilyName = familyName;
            PetType = petType;
        }

        public Pet()
        {

        }

        public int Number { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string PetType { get; set; }

        public override string ToString()
        {
            return Number.ToString().PadRight(5) + 
                Name.PadRight(10) + FamilyName.PadRight(10) + PetType.PadRight(10);
        }
    }
}
