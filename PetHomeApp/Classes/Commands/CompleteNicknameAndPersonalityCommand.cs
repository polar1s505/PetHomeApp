using PetHomeApp.Classes.Models;
using PetHomeApp.Interfaces;

namespace PetHomeApp.Classes.Commands
{
    public class CompleteNicknameAndPersonalityCommand : ICommand
    {
        public void Execute(List<PetBase> animals)
        {
            UserInputReader userInputReader = new UserInputReader();
            string? readResult;

            foreach (var animal in animals)
            {
                if (!animal.HasNickname())
                {
                    userInputReader.GetNickname(animal);
                }

                if (!animal.HasPersonality())
                {
                    userInputReader.GetPersonality(animal);
                }
            }

            Console.WriteLine("\nNickname and personality description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
        }
    }
}
