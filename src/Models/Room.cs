using System.Collections.Generic;
using HogwartsHouses.Models.Types;

namespace HogwartsHouses.Models
{
    [System.Serializable]
    public class Room
    {
        public int Id { get; set; }
        public HouseType HouseType { get; set; }
        public List<Student> Students { get; set; }
        public Room(int id, HouseType houseType, List<Student> students)
        {
            Id = id;
            HouseType = houseType;
            Students = students;
        }
    }
}
