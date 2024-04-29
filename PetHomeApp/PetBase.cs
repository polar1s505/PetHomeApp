namespace PetHomeApp
{
    public abstract class PetBase
    {
        public string ID { get; }

        public string Species { get; protected set; }

        public string Age { get; protected set; }

        public string Nickname { get; protected set; }

        public string PhysicalDescription { get; protected set; }

        public string PersonalityDescription { get; protected set; }

        // Constructor
        public PetBase(string iD, string species, string age, string nickname, string physicalDescription, string personalityDescription)
        {
            ID = iD;
            Species = species;
            Age = age;
            Nickname = nickname;
            PhysicalDescription = physicalDescription;
            PersonalityDescription = personalityDescription;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID #: {ID}");
            Console.WriteLine($"Species: {Species}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Nickname: {Nickname}");
            Console.WriteLine($"Physical description: {PhysicalDescription}");
            Console.WriteLine($"Personality: {PersonalityDescription}");
        }
    }
}