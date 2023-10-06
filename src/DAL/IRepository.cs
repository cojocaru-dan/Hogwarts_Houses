using System.Collections.Generic;
using HogwartsHouses.Models;

namespace HogwartsHouses.DAL
{
    public interface IRepository<T>
    {
        HashSet<T> GetAllRooms();
        T GetRoomById(int id);
        void AddRoom(T t);
        bool UpdateRoom(int id, T newt);
        int DeleteRoomById(int id);
        HashSet<Room> GetAvailableRooms();
        HashSet<Room> GetSafeRooms();
    }
}
