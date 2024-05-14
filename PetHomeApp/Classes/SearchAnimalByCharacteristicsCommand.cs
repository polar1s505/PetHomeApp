using PetHomeApp.Interfaces;

namespace PetHomeApp.Classes
{
    public class SearchAnimalByCharacteristicsCommand : ICommand
    {
        public void Execute(List<PetBase> animals)
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
            foreach (var animal in animals)
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
        }

        private static void ProgressBar(PetBase animal, string search)
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
    }
}
