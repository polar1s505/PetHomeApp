using PetHomeApp.Classes.Models;

namespace PetHomeApp.Interfaces
{
    public interface ICommand
    {
        void Execute(List<PetBase> animals);
    }
}
