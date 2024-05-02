namespace PetHomeApp
{
    public class Dog : PetBase
    {
        public Dog(string id, string age, string nickname, string physicalDescription, string personalityDescription)
            : base(id, "Dog", age, nickname, physicalDescription, personalityDescription)
        {
        }
    }
}