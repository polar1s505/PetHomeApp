using PetHomeApp.Classes.Models;
using PetHomeApp.Classes.Utils;
using PetHomeApp.Interfaces;

namespace PetHomeApp.Classes.Commands
{
    public class AddPetCommand : ICommand
    {
        public void Execute(List<PetBase> animals)
        {
            UserInputReader userInputReader = new UserInputReader();
            IdGegerator idGegerator = new IdGegerator(animals);

            string? readResult;
            string? anotherPet = "y";
            string animalID;
            string animalAge;
            string animalPhysicalDescription;
            string animalPersonalityDescription;
            string animalNickname;
            AnimalType animalType;

            while (anotherPet == "y")
            {
                animalType = userInputReader.GetSpecies();
                animalID = idGegerator.GenerateID(animalType);
                animalAge = userInputReader.GetAge();
                animalPhysicalDescription = userInputReader.GetPhysicalDescription();
                animalPersonalityDescription = userInputReader.GetPersonality();
                animalNickname = userInputReader.GetNickname();

                if (animalType == AnimalType.Dog)
                {
                    Dog dog = new Dog(animalID, animalType, animalAge, animalNickname, animalPhysicalDescription, animalPersonalityDescription);
                    animals.Add(dog);
                }
                else
                {
                    Cat cat = new Cat(animalID, animalType, animalAge, animalNickname, animalPhysicalDescription, animalPersonalityDescription);
                    animals.Add(cat); 
                }

                Console.WriteLine("Pet was successfully added!");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();

                do
                {
                    Console.Write("\nDo you want to add more?(y/n): ");
                    anotherPet = Console.ReadLine()?.ToLower();

                } while (anotherPet != "y" && anotherPet != "n");
            }
        }
    }
}
