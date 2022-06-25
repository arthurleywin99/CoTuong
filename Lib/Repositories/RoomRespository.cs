using Lib.Data;
using Lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        List<Room> GetAllRooms();
        void createRoom(Room room);
        bool checkRoom(Guid Id, string password);
        bool isFull(Guid Id);
        void increaseRoomMember(Guid Id);
    }
    public class RoomRespository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRespository(DbContextFactory factory)
            : base(factory)
        {
            
        }

        public void createRoom(Room room)
        {
            dataContext.Room.Add(room);
            dataContext.SaveChanges();
        }

        public List<Room> GetAllRooms()
        {
            var query = dataContext.Room.AsQueryable();
            return query.ToList();
        }

        public bool checkRoom(Guid Id, string password)
        {
            return dataContext.Room.Any(p => p.Id == Id && p.Password == password);
        }

        public void increaseRoomMember(Guid Id)
        {
            if (dataContext.Room.Any(p => p.Id == Id))
            {
                Room room = dataContext.Room.FirstOrDefault(p => p.Id == Id);
                room.JoinedCount++;
                dataContext.SaveChanges();
            }
        }

        public bool isFull(Guid Id)
        {
            return dataContext.Room.Any(p => p.Id == Id && p.JoinedCount >= 2);
        }
    }
}
