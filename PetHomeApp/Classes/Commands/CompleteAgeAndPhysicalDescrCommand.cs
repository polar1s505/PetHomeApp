using PetHomeApp.Classes.Models;
using PetHomeApp.Interfaces;

namespace PetHomeApp.Classes.Commands
{
    public class CompleteAgeAndPhysicalDescrCommand : ICommand
    {
        public void Execute(List<PetBase> animals)
        {   
            bool validEntry;
            string? readResult;

            foreach (var animal in animals)
            {
                if (!animal.HasAgeValue())
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

                if (!animal.HasPhysicalDescription())
                {
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
            }

            Console.WriteLine("\nAge and physical description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
        }
    }
}
