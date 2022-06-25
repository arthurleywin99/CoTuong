using Lib.Data;
using Lib.Entities;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class ChessService
    {
        private IUnitOfWork unitOfWork;
        private RoomRespository roomRepository;
        public ChessService() {
            var dbContextFactory = new DbContextFactory();
            unitOfWork = new UnitOfWork(dbContextFactory);
            roomRepository = new RoomRespository(dbContextFactory);
        }
        public void Save() {
            unitOfWork.Commit();
        }
        public void createRoom(Room r) {
            roomRepository.createRoom(r);
            Save();
        }

        public bool checkRoom(Guid Id, string password)
        {
            return roomRepository.checkRoom(Id, password);
        }

        public bool isFull(Guid Id)
        {
            return roomRepository.isFull(Id);
        }

        public void increaseRoomMember(Guid Id)
        {
            roomRepository.increaseRoomMember(Id);
        }

        public List<Room> getAllRoom() {
            return roomRepository.GetAllRooms();
        }
    }
}
