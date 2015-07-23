using GOQUAL.Models;
using GOQUAL.Models.DB;
using GOQUAL.Views.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GOQUAL.Controllers
{
    public class ManagementController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public JsonResult GetCategories()
        {
            using(var db = new BlueSwitchEntities())
            {
                var categories = db.Categories.ToList();

                return Json(categories, JsonRequestBehavior.AllowGet);
            }
        }

        // news
        public ActionResult News()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [Authorize]
        public ActionResult CreateNews()
        {
            return View();
        }
        [Authorize]
        public ActionResult DetailNews(int id)
        {
            var viewmodel = new NewsDetailViewModel
            {
                Id = id
            };

            return View(viewmodel);
        }


        // advise
        public ActionResult Advise()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [Authorize]
        public ActionResult CreateAdvise()
        {
            return View();
        }
        [Authorize]
        public ActionResult DetailAdvise(int id)
        {
            var viewmodel = new NewsDetailViewModel
            {
                Id = id
            };

            return View(viewmodel);
        }


        // blog
        public ActionResult Blog()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [Authorize]
        // user
        public ActionResult GOQUAL_User()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // lunch
        public ActionResult Lunch()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
