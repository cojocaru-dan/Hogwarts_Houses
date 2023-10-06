using HogwartsHouses.Models.Types;

namespace HogwartsHouses.Models
{
    [System.Serializable]
    public class Student
    {
        public string Name { get; set; }
        public PetType PetType { get; set; }
    }
}
