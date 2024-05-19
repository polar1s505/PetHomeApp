namespace PetHomeApp.Classes.Models
{
    public class Cat : PetBase
    {
        public Cat(string id, AnimalType animalType, string age, string nickname, string physicalDescription, string personalityDescription)
            : base(id, animalType, age, nickname, physicalDescription, personalityDescription)
        {
        }
    }
}