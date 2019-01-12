﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomeProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public virtual ICollection<User> ReadList { get; set; }
        public virtual ICollection<Tweet> Tweets { get; set; } 
        public User()
        {
            Tweets = new List<Tweet>();
            ReadList = new HashSet<User>();
        }
        

    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //public class SubItem
    //{
    //    public int Id { get; set; }
    //}
}