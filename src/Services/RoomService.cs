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
    }
}