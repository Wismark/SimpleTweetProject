using SomeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SomeProject.Controllers
{
    public class SubscriptionController : Controller
    {
        private Tweet_Context db = new Tweet_Context();
        // GET: Subscription
        public ActionResult Search(string SearchStr)
        {
            IEnumerable<User> users = db.Users.Where(u => u.UserName.Contains(SearchStr)).AsEnumerable()
                .Except(db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault().ReadList)
                .Except(db.Users.Where(u => u.UserName == User.Identity.Name));           
            return PartialView(users);
        }

        public JsonResult JsonSearch(string SearchString)
        {
            IEnumerable<User> users = db.Users.Where(u => u.UserName.Contains(SearchString));
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public string Subscribe(string s)
        {
            string CurrentUser = User.Identity.Name;
            if (s != CurrentUser)
            {
                User user = db.Users.Where(u => u.UserName == s).FirstOrDefault();
                if (user != null)
                {
                    db.Users.Where(u => u.UserName == CurrentUser).FirstOrDefault().ReadList
                        .Add(user);
                    db.SaveChanges();
                }
            }
            else
            {
                return "Nope";
            }
            return "Done!";
        }
    }
}