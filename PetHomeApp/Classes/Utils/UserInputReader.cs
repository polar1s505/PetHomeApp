using PetHomeApp.Classes.Models;

namespace PetHomeApp.Classes.Utils
{
    public class UserInputReader
    {
        public AnimalType GetSpecies()
        {
            bool validEntry = false;
            string? readResult;
            AnimalType animalType = 0; ;

            // get species (cat or dog)
            do
            {
                Console.WriteLine("\n\rEnter '0 - for a dog' or '1 - for a cat' to begin a new entry");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    readResult = readResult.ToLower().Trim();

                    if (Enum.TryParse(readResult, out animalType))
                    {
                        if (animalType == AnimalType.Dog || animalType == AnimalType.Cat)
                        {
                            validEntry = true;
                        }
                    }
                }
            } while (validEntry == false);

            return animalType;
        }

        public string GetAge()
        {
            bool validEntry = false;
            string? readResult;
            string animalAge = "";

            // get the pet's age. can be ? at initial entry
            do
            {
                int petAge;

                Console.WriteLine("Enter the pet's age or enter ? if unknown");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalAge = readResult.ToLower().Trim();
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

            return animalAge;
        }

        public void GetAge(PetBase animal)
        {
            int petAge;
            bool validEntry = false;
            string? readResult;

            do
            {
                Console.WriteLine($"Enter an age for {animal.Nickname}");

                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    if (validEntry = int.TryParse(readResult, out petAge))
                    {
                        animal.Age = petAge.ToString();
                    }
                }
            } while (validEntry == false);
        }

        // get a description of the pet's physical appearance/condition
        public string GetPhysicalDescription()
        {
            string? readResult;
            string animalPhysicalDescription = "";

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

            return animalPhysicalDescription;
        }

        public void GetPhysicalDescription(PetBase animal)
        {
            string? readResult;
            bool validEntry = false;

            do
            {
                Console.WriteLine($"Enter a physical description for {animal.ID} (size, color, breed, gender, weight, housebroken)");

                validEntry = false;
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    readResult = readResult.ToLower();
                    if (!string.IsNullOrEmpty(readResult))
                    {
                        animal.PhysicalDescription = readResult;
                        validEntry = true;
                    }
                }
            } while (validEntry == false);
        }

        public string GetPersonality()
        {
            string? readResult;
            string animalPersonalityDescription = "";

            // get a description of the pet's personality
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

            return animalPersonalityDescription;
        }

        public void GetPersonality(PetBase animal)
        {
            string? readResult;
            bool validEntry = false;

            do
            {
                Console.WriteLine($"Enter a personality description for {animal.Nickname} (likes or dislikes, tricks, energy level)");

                validEntry = false;
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    readResult = readResult.ToLower();
                    if (!string.IsNullOrEmpty(readResult))
                    {
                        animal.PersonalityDescription = readResult;
                        validEntry = true;
                    }
                }
            } while (validEntry == false);
        }

        public string GetNickname()
        {
            string? readResult;
            string animalNickname = "";

            // get the pet's nickname
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

            return animalNickname;
        }

        public void GetNickname(PetBase animal)
        {
            string? readResult;
            bool validEntry = false;

            do
            {
                Console.WriteLine($"Enter a nickname for {animal.ID}");

                validEntry = false;
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    readResult = readResult.ToLower();
                    if (!string.IsNullOrEmpty(readResult))
                    {
                        animal.Nickname = readResult;
                        validEntry = true;
                    }
                }
            } while (validEntry == false);
        }

        public string GetPetCharacteristics()
        {
            string? readResult;
            string petCharacteristics = "";

            // prompt user for pet characteristics
            while (petCharacteristics == "")
            {
                Console.WriteLine($"Please, enter pet characteristics to search for (seperated by commas):");

                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    petCharacteristics = readResult.ToLower();
                }
            }

            return petCharacteristics;
        }
    }
}
