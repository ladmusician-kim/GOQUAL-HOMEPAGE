using GOQUAL.Models;
using GOQUAL.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GOQUAL.Controllers
{
    public class AccountController : Controller
    {
        BlueSwitchEntities db = new BlueSwitchEntities();

        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Management");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var user = db.GoqualUsers.FirstOrDefault(p => p.username.Equals(username));

                if (user != null)
                {
                    if (user.password.Equals(password))
                    {
                        var ticket = new FormsAuthenticationTicket(1, "userId", DateTime.Now, DateTime.Now.AddYears(1), true, user.C_id.ToString());
                        var encTicket = FormsAuthentication.Encrypt(ticket);
                        Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                        user.logined = DateTime.Now;
                        db.SaveChanges();
                    }

                    return RedirectToAction("Index", "Management");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
