using PetHomeApp.Classes;

namespace PetHomeApp.Interfaces
{
    public interface ICommand
    {
        void Execute(List<PetBase> animals);
    }
}
