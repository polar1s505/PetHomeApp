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
                Console.WriteLine(" 7. Display all cats with a specified characteristic");
                Console.WriteLine(" 8. Display all dogs with a specified characteristic");
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

                    default:
                        Console.WriteLine("TODO");
                        Console.ReadLine();
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
    }
}
