using GOQUAL.Views.Joinus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOQUAL.Controllers
{
    public class JoinusController : Controller
    {
        public ActionResult Index(int lang)
        {
            string strUserAgent = Request.UserAgent.ToString().ToLower();
            if (Request.Browser.IsMobileDevice == true || strUserAgent.Contains("iphone") ||
                strUserAgent.Contains("blackberry") || strUserAgent.Contains("mobile") ||
                strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                strUserAgent.Contains("palm"))
            {
                return RedirectToAction("Mobile", new { lang = lang });
            }

            var viewModel = new IndexViewModel
            {
                Lang = lang
            };

            return View(viewModel);
        }

        public ActionResult Mobile(int lang)
        {
            var viewModel = new IndexViewModel
            {
                Lang = lang
            };

            return View(viewModel);
        }
    }
}
