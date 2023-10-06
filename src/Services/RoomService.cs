using System.Collections.Generic;
using HogwartsHouses.DAL;
using HogwartsHouses.Models;

namespace HogwartsHouses.Services
{
    public class RoomService : IRoomService
    {
        private IRepository<Room> _repository { get; }

        public RoomService(IRepository<Room> repository)
        {
            _repository = repository;
        }
        public HashSet<Room> GetAllRooms() => _repository.GetAllRooms();
        public Room GetRoomById(int id) => _repository.GetRoomById(id);
        public void AddRoom(Room room) => _repository.AddRoom(room);
        public bool UpdateRoom(int id, Room newRoom) => _repository.UpdateRoom(id, newRoom);
        public int DeleteRoomById(int id) => _repository.DeleteRoomById(id);
        public HashSet<Room> GetAvailableRooms() => _repository.GetAvailableRooms();
        public HashSet<Room> GetSafeRooms() => _repository.GetSafeRooms();
    }
}
