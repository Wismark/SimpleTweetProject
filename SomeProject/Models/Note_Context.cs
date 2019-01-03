using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SomeProject.Models
{
    public class Note_Context : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }


    public class UserDbInitializer : DropCreateDatabaseAlways<Note_Context>
    {
        protected override void Seed(Note_Context db)
        {
            db.Roles.Add(new Role { Id = 1, Name = "admin" });
            db.Roles.Add(new Role { Id = 2, Name = "user" });

            db.Users.Add(new User
            {
                Id = 1,
                Email = "somemail@gmail.com",
                Password = "1234",
                RoleId = 1,
                UserName = "admin",
                About = "The one and only 'super admin'."
            });
            base.Seed(db);
        }
    }
}