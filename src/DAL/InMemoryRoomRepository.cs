using System;
using System.Collections.Generic;
using System.Linq;
using HogwartsHouses.Models;
using HogwartsHouses.Models.Types;

namespace HogwartsHouses.DAL
{
    public class InMemoryRoomRepository : IRepository<Room>
    {
        private readonly HashSet<Room> _rooms = new();
        private List<Student> _pendingStudents = new() {
            new Student() {Name="Hermione Granger", PetType=PetType.Rat},
            new Student() {Name="Draco Malfoy", PetType=PetType.Owl},
        };

        public InMemoryRoomRepository()
        {
            SeedRooms();
            AssignRoomsToPendingStudents();
        }

        private void SeedRooms()
        {
            Array values = Enum.GetValues<HouseType>();
            
            for (int i = 1; i < 11; i++)
            {
                _rooms.Add(new Room(i, (HouseType)values.GetValue(new Random().Next(0, values.Length)), new List<Student>()));
            }
        }
        public void AssignRoomsToPendingStudents()
        {
            foreach (var pendingStudent in _pendingStudents)
            {
                foreach (var room in _rooms)
                {
                    if (room.Students.Count == 0) 
                    {
                        room.Students.Add(pendingStudent);
                        break;
                    }
                }
            }
        }
        public HashSet<Room> GetAllRooms() => _rooms;
        public Room GetRoomById(int id)
        {
            Room room = _rooms.FirstOrDefault(r => r.Id == id);
            return room;
        }
        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }
        public bool UpdateRoom(int id, Room newRoom)
        {
            foreach (var room in _rooms)
            {
                if (room.Id == id)
                {
                    room.HouseType = newRoom.HouseType;
                    room.Students.AddRange(newRoom.Students);
                    return true;
                }
            }
            return false;
        }
        public int DeleteRoomById(int id) => _rooms.RemoveWhere(r => r.Id == id);
        public HashSet<Room> GetAvailableRooms()
        {
            HashSet<Room> availableRooms = new();
            foreach (var room in _rooms)
            {
                if (room.Students.Count == 0) availableRooms.Add(room);
            }
            return availableRooms;
        }
        public HashSet<Room> GetSafeRooms()
        {
            HashSet<Room> safeRooms = new();
            foreach (var room in _rooms)
            {
                bool isSafe = true;
                foreach (var student in room.Students)
                {
                    if (student.PetType == PetType.Cat || student.PetType == PetType.Owl)
                    {
                        isSafe = false;
                        break;
                    }
                }
                if (isSafe) safeRooms.Add(room);
            }
            
            return safeRooms;
        }
    }
}
