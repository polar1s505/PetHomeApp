namespace PetHomeApp.Classes.Models
{
    public class Cat : PetBase
    {
        public Cat(string id, string age, string nickname, string physicalDescription, string personalityDescription)
            : base(id, "Cat", age, nickname, physicalDescription, personalityDescription)
        {
        }
    }
}