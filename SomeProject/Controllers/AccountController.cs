using SomeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SomeProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("ListTweets", "Tweet");
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (Tweet_Context db = new Tweet_Context())
                {
                    user = db.Users.Where(u => u.UserName == model.Name && u.Password == model.Password).FirstOrDefault();
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("ListTweets", "Tweet");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password incorrect.");
                }
            }
            return View(model);
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (Tweet_Context db = new Tweet_Context())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Email || u.UserName == model.Name);
                }
                if (user == null)
                {
                    using (Tweet_Context db = new Tweet_Context())
                    {
                        db.Users.Add(new Models.User { Email = model.Email, UserName = model.Name, Password = model.Password, RoleId = 2 });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.UserName == model.Name && u.Password == model.Password).FirstOrDefault();
                    }

                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("ListTweets", "Tweet");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User with the same name or email already exists.");
                }
            }
            return View(model);
        }
    }
}