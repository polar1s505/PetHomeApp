using System.Reflection.PortableExecutable;

namespace PetHomeApp
{
    public class App
    {
        public void Run()
        {
            List<PetBase> ourAnimals = new List<PetBase>();

            AddSomePets(ourAnimals);

            string? readResult;
            string menuSelection = "";

            do
            {
                DisplayMainMenu();

                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    menuSelection = readResult.ToLower();
                }

                switch (menuSelection)
                {
                    case "1":
                        // List all current pet information
                        foreach (var animal in ourAnimals)
                        {
                            animal.DisplayInfo();
                            Console.WriteLine();
                        }
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        break;

                    case "2":
                        // Add a new animal friend to the ourAnimals array
                        AddPet(ourAnimals);
                        break;

                    case "3":
                        // Ensure animal ages and physical descriptions are complete
                        bool correctAge;
                        bool coorectPhysicalDescr;
                        bool validEntry;

                        foreach (var animal in ourAnimals)
                        {
                            animal.CheckAgeAndPhyscalDescr(out correctAge, out coorectPhysicalDescr);

                            if (!correctAge)
                            {
                                int petAge;
                                validEntry = false;

                                do
                                {
                                    Console.WriteLine($"Enter an age for {animal.ID}");

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

                            if (!coorectPhysicalDescr)
                            {
                                do
                                {
                                    Console.WriteLine($"Enter a physical description for {animal.ID} (size, color, breed, gender, weight, housebroken)");

                                    validEntry = false;
                                    readResult = Console.ReadLine();
                                    if (readResult != null)
                                    {
                                        readResult = readResult.ToLower();
                                        if (!(string.IsNullOrEmpty(readResult)))
                                        {
                                            animal.PhysicalDescription = readResult;
                                            validEntry = true;
                                        }
                                    }
                                } while (validEntry == false);
                            }
                        }

                        Console.WriteLine("\nAge and physical description fields are complete for all of our friends.");
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    case "4":
                        // Ensure animal nicknames and personality descriptions are complete
                        bool correctNickname;
                        bool coorectPersonalityDescr;
                        validEntry = false;

                        foreach (var animal in ourAnimals)
                        {
                            animal.CheckNicknameAndPersinality(out correctNickname, out coorectPersonalityDescr);

                            if (!correctNickname)
                            {
                                do
                                {
                                    Console.WriteLine($"Enter a nickname for {animal.ID}");

                                    validEntry = false;
                                    readResult = Console.ReadLine();
                                    if (readResult != null)
                                    {
                                        readResult = readResult.ToLower();
                                        if (!(string.IsNullOrEmpty(readResult)))
                                        {
                                            animal.Nickname = readResult;
                                            validEntry = true;
                                        }
                                    }
                                } while (validEntry == false);
                            }

                            if (!coorectPersonalityDescr)
                            {
                                do
                                {
                                    Console.WriteLine($"Enter a personality description for {animal.ID} (likes or dislikes, tricks, energy level)");

                                    validEntry = false;
                                    readResult = Console.ReadLine();
                                    if (readResult != null)
                                    {
                                        readResult = readResult.ToLower();
                                        if (!(string.IsNullOrEmpty(readResult)))
                                        {
                                            animal.PersonalityDescription = readResult;
                                            validEntry = true;
                                        }
                                    }
                                } while (validEntry == false);
                            }
                        }

                        Console.WriteLine("\nNickname and personality description fields are complete for all of our friends.");
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    case "5":
                        // Edit an animal's age by nickname
                        validEntry = false;
                        
                        Console.WriteLine("List of available animals' nicknames:");
                        foreach (var animal in ourAnimals)
                        {
                            if (animal.Nickname != "" && animal.Nickname != "tbd")
                                Console.WriteLine($"> {animal.Nickname}");
                        }

                        do
                        {
                            Console.WriteLine("\nEnter a nickname of pet whose age you want to edit:");

                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                readResult = readResult.ToLower().Trim();

                                foreach (var animal in ourAnimals)
                                {
                                    if (animal.Nickname == "" || animal.Nickname == "tbd")
                                        continue;

                                    if (animal.Nickname.ToLower().Equals(readResult))
                                    {
                                        int petAge = 0;

                                        do
                                        {
                                            Console.WriteLine($"Enter the pet's new age for {animal.Nickname}:");
                                            readResult = Console.ReadLine();
                                            if (readResult != null)
                                            {
                                                validEntry = int.TryParse(readResult, out petAge);
                                            }
                                        } while (validEntry == false);

                                        animal.Age = petAge.ToString();
                                        break;
                                    }
                                }
                            }
                        } while (validEntry == false);

                        Console.WriteLine($"You successfully changed animal's age.");
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    case "6":
                        // Edit an animal's personality description by nickname
                        validEntry = false;

                        Console.WriteLine("List of available animals' nicknames:");
                        foreach (var animal in ourAnimals)
                        {
                            if (animal.Nickname != "" && animal.Nickname != "tbd")
                                Console.WriteLine($"> {animal.Nickname}");
                        }

                        do
                        {
                            Console.WriteLine("\nEnter a nickname of pet whose personality description you want to edit:");

                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                readResult = readResult.ToLower().Trim();

                                foreach (var animal in ourAnimals)
                                {
                                    if (animal.Nickname == "" || animal.Nickname == "tbd")
                                        continue;

                                    if (animal.Nickname.ToLower().Equals(readResult))
                                    {
                                        do
                                        {
                                            Console.WriteLine($"Enter the a new personality description for {animal.Nickname}");
                                            readResult = Console.ReadLine();
                                            if (!(String.IsNullOrEmpty(readResult)))
                                            {
                                                animal.PersonalityDescription = readResult;
                                                validEntry = true;
                                                break;
                                            }
                                        } while (validEntry == false);
                                    }
                                }
                            }
                        } while (validEntry == false);

                        Console.WriteLine($"You successfully changed animal's personality description.");
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    case "7":
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

                        // split entered characteristics (search) into string array
                        string[] petSearches = petCharacteristics.Split(',');

                        // trim every search from leading and trailing spaces
                        for (int i = 0; petSearches.Length < 0; i++)
                        {
                            petSearches[i] = petSearches[i].Trim();
                        }

                        Array.Sort(petSearches);

                        bool matchAnyPet = false;
                        string petDescription = "";

                        // loop through ourAnimals list
                        foreach (var animal in ourAnimals)
                        {
                            petDescription = $"Physical description: {animal.PhysicalDescription}\nPersonality: {animal.PersonalityDescription}";
                            bool matchCurrentPet = false;

                            foreach (var search in petSearches)
                            {
                                // search only if there is a valid input
                                if (search != null && search.Trim() != "")
                                {
                                    ProgressBar(animal, search);

                                    // check for specified characteristics
                                    if (petDescription.Contains(search.Trim()))
                                    {
                                        Console.WriteLine($"\r\nA pet '\u001b[4m{animal.Nickname}\u001b[24m' matches your search for: \u001B[4m{search.Trim()}\u001B[24m\n");

                                        matchAnyPet = true;
                                        matchCurrentPet = true;
                                    }
                                }
                            }

                            if (matchCurrentPet)
                            {
                                Console.WriteLine($"\r#ID: {animal.ID}\nSpecies: \x1b[1m\u001b[3m{animal.Species}\u001B[23m\x1b[0m\n{petDescription}");
                            }
                        }

                        if (!matchAnyPet)
                        {
                            Console.WriteLine("None of our pets are a match found for: " + petCharacteristics);
                        }

                        Console.WriteLine("\n\rPress the Enter key to continue");
                        readResult = Console.ReadLine();
                        break;

                    default:
                        break;
                }
            } while (menuSelection != "exit");
        }

        private void AddSomePets(List<PetBase> ourAnimals)
        {
            ourAnimals.Add(new Dog("d1", "5", "lola", "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.", "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses."));
            ourAnimals.Add(new Dog("d2", "12", "logan", "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.", "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs."));
            ourAnimals.Add(new Cat("c1", "15", "umi", "", ""));
            ourAnimals.Add(new Cat("c2", "?", "rosa", "small white female weighing about 8 pounds. litter box trained.", "friendly"));
        }

        private void AddPet(List<PetBase> ourAnimals)
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
                    animalID = animalSpecies.Substring(0, 1) + (ourAnimals.Count(item => item is Dog) + 1).ToString();
                else
                    animalID = animalSpecies.Substring(0, 1) + (ourAnimals.Count(item => item is Cat) + 1).ToString();

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
                    ourAnimals.Add(cat);
                }
                else
                {
                    Dog dog = new Dog(animalID, animalAge, animalNickname, animalPhysicalDescription, animalPersonalityDescription);
                    ourAnimals.Add(dog);
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

        private void ProgressBar(PetBase animal, string search)
        {
            string[] progressBar = { " |", " /", "--", " \\", " *" };

            for (int i = 2; i > -1; i--)
            {
                foreach (var icon in progressBar)
                {
                    Console.Write($"\rsearching our dog {animal.Nickname} for {search.Trim()} {icon} {i}");
                    Thread.Sleep(150);
                }

                Console.Write($"\r{new string(' ', Console.BufferWidth)}");
            }
        }

        private void DisplayMainMenu()
        {
            Console.Clear();

            Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
            Console.WriteLine(" 1. List all of our current pet information");
            Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
            Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
            Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
            Console.WriteLine(" 5. Edit an animal’s age");
            Console.WriteLine(" 6. Edit an animal’s personality description");
            Console.WriteLine(" 7. Search a pet by characteristics");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");
        }
    }
}