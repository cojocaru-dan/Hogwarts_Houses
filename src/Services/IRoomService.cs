using System.Collections.Generic;
using HogwartsHouses.Models;

namespace HogwartsHouses.Services
{
    public interface IRoomService
    {
        HashSet<Room> GetAllRooms();
        Room GetRoomById(int id);
        void AddRoom(Room room);
        bool UpdateRoom(int id, Room newRoom);
        int DeleteRoomById(int id);
        HashSet<Room> GetAvailableRooms();
        HashSet<Room> GetSafeRooms();
    }
}
