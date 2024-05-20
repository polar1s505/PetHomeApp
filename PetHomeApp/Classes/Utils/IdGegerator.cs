using PetHomeApp.Classes.Models;

namespace PetHomeApp.Classes.Utils
{
    public class IdGegerator
    {
        private int _lastIdDogs;
        private int _lastIdCats;

        public IdGegerator(List<PetBase> animals)
        {
            _lastIdDogs = animals.Count(animal => animal is Dog);
            _lastIdCats = animals.Count(animal => animal is Cat);
        }
        public  string GenerateID(AnimalType type)
        {
            string id = "";
            
            if (type is AnimalType.Dog)
            {
                _lastIdDogs++;
                id = $"d{_lastIdDogs}"; 
            }
            else
            {
                _lastIdCats++;
                id = $"c{_lastIdCats}"; 
            }

            return id;
        }
    }
}
