using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Data;
using Lib.Entities;
using Lib.Repositories;

namespace Lib.Services
{
    public class UserService
    {
        private IUnitOfWork unitOfWork;
        private UserRespository userRepository;

        public UserService()
        {
            var dbContextFactory = new DbContextFactory();
            unitOfWork = new UnitOfWork(dbContextFactory);
            userRepository = new UserRespository(dbContextFactory);
        }
        public void Save()
        {
            unitOfWork.Commit();
        }

        public User Login(string username, string password)
        {
            return userRepository.Login(username, password);
        }
    }
}
