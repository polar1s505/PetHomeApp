using PetHomeApp.Classes.Models;
using PetHomeApp.Interfaces;

namespace PetHomeApp.Classes.Commands
{
    public class CompleteAgeAndPhysicalDescrCommand : ICommand
    {
        public void Execute(List<PetBase> animals)
        {   
            UserInputReader userInputReader = new UserInputReader();
            string? readResult;

            foreach (var animal in animals)
            {
                if (!animal.HasAgeValue())
                {
                    userInputReader.GetAge(animal);
                }

                if (!animal.HasPhysicalDescription())
                {
                    userInputReader.GetPhysicalDescription(animal);
                }
            }

            Console.WriteLine("\nAge and physical description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
        }
    }
}
