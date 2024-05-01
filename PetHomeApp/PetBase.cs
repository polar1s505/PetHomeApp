namespace PetHomeApp
{
    public abstract class PetBase
    {
        private string _id;
        private string _species;
        private string _age;
        private string _nickname;
        private string _physicalDescription;
        private string _personalityDescription;
        public string ID 
        { 
            get { return _id; }
            set { _id = value; }
        }

        public string Species 
        { 
            get { return _species; }
            set { _species = value; }
        }

        public string Age 
        { 
            get { return _age; }
            set { _age = value; }
        }

        public string Nickname 
        { 
            get { return _nickname; }
            set { _nickname = value; }
        }

        public string PhysicalDescription 
        { 
            get { return _physicalDescription; }
            set { _physicalDescription = value; }
        }

        public string PersonalityDescription 
        { 
            get { return _personalityDescription; }
            set { _personalityDescription = value; }
        }

        // Constructor
        public PetBase(string iD, string species, string age, string nickname, string physicalDescription, string personalityDescription)
        {
            _id = iD;
            _species = species;
            _age = age;
            _nickname = nickname;
            _physicalDescription = physicalDescription;
            _personalityDescription = personalityDescription;
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

        public virtual void CheckAgeAndPhyscalDescr(out bool correctAge, out bool correctPhysycalDescr)
        {
            correctAge = (Age.Contains("?")) ? false : true;
            correctPhysycalDescr = (PhysicalDescription == "" || PhysicalDescription == "tbd") ? false : true;
        }

        public virtual void CheckNicknameAndPersinality(out bool correctNickname, out bool correctPersonality)
        {
            correctNickname = (Nickname == " " || Nickname == "tbd") ? false : true;
            correctPersonality = (PersonalityDescription == "" || PersonalityDescription == "tbd") ? false : true;
        }
    }
}