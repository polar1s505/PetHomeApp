using PetHomeApp.Interfaces;

namespace PetHomeApp.Classes
{
    public class EditAgeCommand : ICommand
    {
        public void Execute(List<PetBase> animals)
        {
            string? readResult;
            bool validEntry = false;

            Console.WriteLine("List of available animals' nicknames:");
            foreach (var animal in animals)
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

                    foreach (var animal in animals)
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
        }
    }
}
