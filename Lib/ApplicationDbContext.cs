using Lib.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class ApplicationDbContext : IdentityDbContext // IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> User { get; set; }
        public DbSet<Room> Room { get; set; }
        public ApplicationDbContext()
           : base("DefaultConnection")
        {
        }

       /*public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }*/
    }
}
