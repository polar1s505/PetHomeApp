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
                Console.Clear();

                Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
                Console.WriteLine(" 1. List all of our current pet information");
                Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
                Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
                Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
                Console.WriteLine(" 5. Edit an animal’s age");
                Console.WriteLine(" 6. Edit an animal’s personality description");
                Console.WriteLine();
                Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

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

                            if(!correctAge)
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
                                        if(!(string.IsNullOrEmpty(readResult)))
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
    }
}
