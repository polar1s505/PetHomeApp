using PetHomeApp.Classes.Models;

namespace PetHomeApp.Classes.Utils
{
    public class IdGegerator
    {
        private int _last_id_dogs;
        private int _last_id_cats;

        public IdGegerator(List<PetBase> animals)
        {
            _last_id_dogs = animals.Count(animal => animal is Dog);
            _last_id_cats = animals.Count(animal => animal is Cat);
        }
        public  string GenerateID(AnimalType type)
        {
            string id = "";
            
            if (type is AnimalType.Dog)
            {
                _last_id_dogs++;
                id = $"d{_last_id_dogs}"; 
            }
            else
            {
                _last_id_cats++;
                id = $"c{_last_id_cats}"; 
            }

            return id;
        }
    }
}
