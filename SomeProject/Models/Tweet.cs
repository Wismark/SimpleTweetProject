using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomeProject.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Publish_date { get; set; }

        public int? Author_id { get; set; }
        public User User { get; set; }
    }
}