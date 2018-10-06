using MyNewsPaper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyNewsPaper.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserDetails user, string returnurl)
        {
            if (IsValid(user))
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return Redirect(returnurl);
            }
            else
            {
                return View(user);
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/Home/Index");
        }

        private bool IsValid(UserDetails user)
        {
            return (user.UserName == "Mizan" && user.Password == "1234");
        }
    }
}