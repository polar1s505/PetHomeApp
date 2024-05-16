using PetHomeApp.Classes.Models;
using PetHomeApp.Interfaces;

namespace PetHomeApp.Classes.Commands
{
    public class DisplayInfoCommand : ICommand
    {
        public void Execute(List<PetBase> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
}
