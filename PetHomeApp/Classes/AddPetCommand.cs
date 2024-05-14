using PetHomeApp.Interfaces;

namespace PetHomeApp.Classes
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
                        animalSpecies = readResult.ToLower();
                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            Console.WriteLine($"You incorrect entered species: {animalSpecies}.\nTry again\n");
                            validEntry = false;
                        }
                        else 
                        {
                            animalSpecies = readResult;
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                if (animalSpecies == "dog")
                    animalID = animalSpecies.Substring(0, 1) + (animals.Count(item => item is Dog) + 1).ToString();
                else
                    animalID = animalSpecies.Substring(0, 1) + (animals.Count(item => item is Cat) + 1).ToString();

                // get the pet's age. can be ? at initial entry
                do
                {
                    int petAge;

                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult.ToLower();
                        if (animalAge != "?")
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
                            animalPhysicalDescription = "tbd";
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
                            animalPersonalityDescription = "tbd";
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
                            animalNickname = "tbd";
                        }
                    }
                } while (animalNickname == "");

                if (animalSpecies == "cat")
                {
                    Cat cat = new Cat(animalID, animalAge, animalNickname, animalPhysicalDescription, animalPersonalityDescription);
                    animals.Add(cat);
                }
                else
                {
                    Dog dog = new Dog(animalID, animalAge, animalNickname, animalPhysicalDescription, animalPersonalityDescription);
                    animals.Add(dog);
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
