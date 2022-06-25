using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Data;
using Lib.Entities;

namespace Lib.Repositories
{
    public interface IUserRespository : IRepository<User>
    {
        User Login(string username, string password);
    }
    public class UserRespository : RepositoryBase<User>, IUserRespository
    {
        public UserRespository(DbContextFactory factory) : base(factory)
        {
            
        }
        public User Login(string username, string password)
        {
            User user = dataContext.User.FirstOrDefault(p => p.Username == username && p.Password == password);
            return user;
        }
    }
}
