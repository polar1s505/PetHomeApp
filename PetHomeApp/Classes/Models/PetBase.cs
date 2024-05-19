namespace PetHomeApp.Classes.Models
{
    public abstract class PetBase
    {
        public string ID { get; set; }
        public string Species 
        { 
            get
            {
                return (AnimalType == 0) ? "dog" : "cat";
            }
        }
        public AnimalType AnimalType { get; set; }
        public string Age { get; set; }
        public string Nickname { get; set; }
        public string PhysicalDescription { get; set; }
        public string PersonalityDescription { get; set; }
        public string FullDescription
        {
            get
            {
                return $"Physical description: {PhysicalDescription}\nPersonality: {PersonalityDescription}";
            }
        }

        // Constructor
        public PetBase(string id, AnimalType animalType, string age, string nickname, string physicalDescription, string personalityDescription)
        {
            ID = id;
            AnimalType = animalType;
            Age = age;
            Nickname = nickname;
            PhysicalDescription = physicalDescription;
            PersonalityDescription = personalityDescription;
        }

        public override string ToString()
        {
            return $"ID #: {ID}\nSpecies: {Species}\nAge: {Age}\nNickname: {Nickname}\n" +
                $"Physical description: {PhysicalDescription}\nPersonality: {PersonalityDescription}\n";
        }

        public virtual bool HasAgeValue()
        {
            return Age.Contains(DefaultValues.AGE) ? false : true;
        }

        public virtual bool HasPhysicalDescription()
        {
            return PhysicalDescription == "" || PhysicalDescription == DefaultValues.PHYSICAL_DESCRIPTION ? false : true; ;
        }

        public virtual bool HasNickname()
        {
            return Nickname == "" || Nickname == DefaultValues.NICKNAME ? false : true;
        }

        public virtual bool HasPersonality()
        {
            return PersonalityDescription == "" || PersonalityDescription == DefaultValues.PERSONALITY ? false : true;
        }
    }
}