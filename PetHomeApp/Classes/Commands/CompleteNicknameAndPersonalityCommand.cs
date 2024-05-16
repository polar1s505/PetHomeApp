using PetHomeApp.Classes.Models;
using PetHomeApp.Interfaces;

namespace PetHomeApp.Classes.Commands
{
    public class CompleteNicknameAndPersonalityCommand : ICommand
    {
        public void Execute(List<PetBase> animals)
        {
            bool validEntry = false;
            string? readResult;

            foreach (var animal in animals)
            {
                if (!animal.CheckNickname())
                {
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

                if (!animal.CheckPersonality())
                {
                    do
                    {
                        Console.WriteLine($"Enter a personality description for {animal.ID} (likes or dislikes, tricks, energy level)");

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
            }

            Console.WriteLine("\nNickname and personality description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
        }
    }
}
