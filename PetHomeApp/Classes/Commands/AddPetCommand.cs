using PetHomeApp.Classes.Models;
using PetHomeApp.Interfaces;

namespace PetHomeApp.Classes.Commands
{
    public class AddPetCommand : ICommand
    {
        public void Execute(List<PetBase> animals)
        {
            bool validEntry;
            string? readResult;
            string? anotherPet = "y";
            string animalID = "";
            string animalSpecies = "";
            string animalAge = "";
            string animalPhysicalDescription = "";
            string animalPersonalityDescription = "";
            string animalNickname = "";
            AnimalType type = 0;

            while (anotherPet == "y")
            {
                validEntry = false;

                // get species (cat or dog) - string animalSpecies is a required field
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower().Trim();
                        if (animalSpecies == "dog")
                        {
                            type = AnimalType.Dog;
                            animalSpecies = readResult;
                            validEntry = true;
                        }
                        else if (animalSpecies == "cat")
                        {
                            type = AnimalType.Cat;
                            animalSpecies = readResult;
                            validEntry = true;

                        }
                        else
                        {
                            Console.WriteLine($"You incorrect entered species: {animalSpecies}.\nTry again\n");
                            validEntry = false;
                        }
                    }
                } while (validEntry == false);



                // assign a ID:
                // for dog: d + 'count of a dog'
                // for cat: c+ 'count of a cat'
                // i.e: d3, c5
                if (type == AnimalType.Dog)
                    animalID = "d" + (animals.Count(item => item is Dog) + 1).ToString();
                else
                    animalID = "c" + (animals.Count(item => item is Cat) + 1).ToString();

                // get the pet's age. can be ? at initial entry
                do
                {
                    int petAge;

                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult.ToLower();
                        if (animalAge != DefaultValues.AGE)
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();

                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = DefaultValues.PHYSICAL_DESCRIPTION;
                        }
                    }
                } while (animalPhysicalDescription == "");

                // get a description of the pet's personality - animalPersonalityDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = DefaultValues.PERSONALITY;
                        }
                    }
                } while (animalPersonalityDescription == "");

                // get the pet's nickname. animalNickname can be blank.
                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = DefaultValues.NICKNAME;
                        }
                    }
                } while (animalNickname == "");

                if (type == AnimalType.Dog)
                {
                    Dog dog = new Dog(animalID, animalAge, animalNickname, animalPhysicalDescription, animalPersonalityDescription);
                    animals.Add(dog);
                }
                else
                {
                    Cat cat = new Cat(animalID, animalAge, animalNickname, animalPhysicalDescription, animalPersonalityDescription);
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
