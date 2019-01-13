using SomeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SomeProject.Controllers
{
    public class TweetController : Controller
    {
        private Tweet_Context db = new Tweet_Context();
        public ActionResult ListTweets()
        {
            if (User.Identity.IsAuthenticated)
            {
                string CurrentUser = ViewBag.UserName = User.Identity.Name;
                
                var tweets = db.Users.Where(u => u.UserName == CurrentUser).FirstOrDefault().Tweets.ToList();

                var Subs = db.Users.Where(u => u.UserName == CurrentUser).FirstOrDefault().ReadList;

                foreach (var item in Subs)
                {
                    tweets.AddRange(item.Tweets);
                }

                if (tweets != null)
                    return View(tweets.OrderByDescending(t => t.Publish_date));
                else return View(tweets);
            }
            return RedirectToAction("Login", "Account");
        }


        [Authorize]
        public ActionResult AddTweet(string content)
        {
            if(ModelState.IsValid && User.Identity.IsAuthenticated && content!=null)
            {
                Tweet tweet = new Tweet();
                tweet.Content = content;
                tweet.Publish_date = DateTime.Now;
                tweet.Author_id = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault().Id;
                db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault().Tweets.Add(tweet);
                db.Tweets.Add(tweet);
                db.SaveChanges();
                return PartialView(tweet);
            }           
            return new EmptyResult();
        }
    }
}