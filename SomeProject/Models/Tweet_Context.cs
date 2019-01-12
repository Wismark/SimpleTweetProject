using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SomeProject.Models
{
    public class Tweet_Context : DbContext
    {
        public Tweet_Context():
            base("DefaultConnection")
        {
                
        }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        
    }


    public class UserDbInitializer : DropCreateDatabaseAlways<Tweet_Context>
    {
        protected override void Seed(Tweet_Context db)
        {
            db.Roles.Add(new Role { Id = 1, Name = "admin" });
            db.Roles.Add(new Role { Id = 2, Name = "user" });

            db.Users.Add(new User
            {
                Id = 1,
                UserName = "admin",
                Email = "somemail@gmail.com",
                Password = "1234",
                RoleId = 1,               
                About = "The one and only 'super admin'."
            });
            //db.Users.First().Tweets.Add(new Tweet { Content = "fafa", Id = 1, Publish_date = DateTime.Now });
            base.Seed(db);
        }
    }
}