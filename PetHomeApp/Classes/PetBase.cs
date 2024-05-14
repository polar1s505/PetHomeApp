namespace PetHomeApp.Classes
{
    public abstract class PetBase
    {
        public string ID { get; set; }
        public string Species { get; set; }
        public string Age { get; set; }
        public string Nickname { get; set; }
        public string PhysicalDescription { get; set; }
        public string PersonalityDescription { get; set; }

        // Constructor
        public PetBase(string id, string species, string age, string nickname, string physicalDescription, string personalityDescription)
        {
            ID = id;
            Species = species;
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

        public virtual void CheckAgeAndPhyscalDescr(out bool correctAge, out bool correctPhysycalDescr)
        {
            correctAge = Age.Contains("?") ? false : true;
            correctPhysycalDescr = PhysicalDescription == "" || PhysicalDescription == "tbd" ? false : true;
        }

        public virtual void CheckNicknameAndPersinality(out bool correctNickname, out bool correctPersonality)
        {
            correctNickname = Nickname == " " || Nickname == "tbd" ? false : true;
            correctPersonality = PersonalityDescription == "" || PersonalityDescription == "tbd" ? false : true;
        }
    }
}