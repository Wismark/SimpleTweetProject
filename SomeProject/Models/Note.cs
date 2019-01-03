using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomeProject.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Publish_date { get; set; }
        public DateTime Edit_date { get; set; }
    }
}