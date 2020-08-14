using System;
using System.Collections.Generic;
using System.Text;

namespace PetInfo
{
    public class UserInterface
    {
        public void Run()
        {
            Pets pets = new Pets();

            string userInput = "";

            Menu();

            userInput = Console.ReadLine().ToLower();

            while (userInput != "e")
            {

                switch (userInput)
                {
                    case "1":
                        DisplayPets(pets);
                        break;

                    case "2":
                        AddPet(pets);
                        break;

                    case "3":
                        RemovePet(pets);
                        break;

                    case "e":
                        continue;

                    default:
                        Console.WriteLine("Please make a valid selection");
                        break;
                }

                Menu();

                userInput = Console.ReadLine().ToLower();

            }

            Console.WriteLine("Program ending. Press ENTER.");
            Console.ReadLine();
        }

        private void Menu()
        {
            Console.WriteLine("Please make a selection");
            Console.WriteLine("1 - List");
            Console.WriteLine("2 - Add");
            Console.WriteLine("3 - Remove");
            Console.WriteLine("E - Exit");
        }

        private void AddPet(Pets pets)
        {
            Pet pet = new Pet();

            Console.WriteLine("Pet number");
            pet.Number = int.Parse(Console.ReadLine());

            Console.WriteLine("Pet name");
            pet.Name = Console.ReadLine();

            Console.WriteLine("Family name");
            pet.FamilyName = Console.ReadLine();

            Console.WriteLine("Pet type");
            pet.PetType = Console.ReadLine();

            bool result = pets.AddPet(pet);

            if (result == true)
            {
                Console.WriteLine("Pet added.");
            }
            else
            {
                Console.WriteLine("Pet not added.");
            }
        }

        private void RemovePet(Pets pets)
        {
            DisplayPets(pets);

            Console.WriteLine("Pet number to delete");
            int petNumber = int.Parse(Console.ReadLine());
            pets.RemovePet(petNumber);

            Console.WriteLine("Pet removed.");
        }

        private void DisplayPets(Pets pets)
        {

            Pet[] tempPet = pets.PetList;

            for (int i = 0; i < tempPet.Length; i++)
            {
                Console.WriteLine(tempPet[i].ToString());
            }
        }
    }
}
