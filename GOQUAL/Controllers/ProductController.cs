using GOQUAL.Views.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOQUAL.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index(int? lang)
        {
            string strUserAgent = Request.UserAgent.ToString().ToLower();
            if (Request.Browser.IsMobileDevice == true || strUserAgent.Contains("iphone") ||
                strUserAgent.Contains("blackberry") || strUserAgent.Contains("mobile") ||
                strUserAgent.Contains("windows ce") || strUserAgent.Contains("opera mini") ||
                strUserAgent.Contains("palm"))
            {
                return RedirectToAction("Mobile", new { lang = lang });
            }

            if (lang != null && lang == 0)
            {
                return RedirectToAction("Ko", new { lang = 0 });
            }
            else
            {
                return RedirectToAction("Eng", new { lang = 1 });
            }
        }

        public ActionResult Ko(int? lang)
        {
            if (lang != null && lang == 1)
            {
                return RedirectToAction("Eng", new { lang = 1 });
            }

            var viewModel = new IndexViewModel
            {
                Lang = lang != null ? lang.Value : 0
            };

            return View(viewModel);
        }

        public ActionResult Eng(int? lang)
        {
            if (lang != null && lang == 0)
            {
                return RedirectToAction("Ko", new { lang = 0 });
            }

            var viewModel = new IndexViewModel
            {
                Lang = lang != null ? lang.Value : 0
            };

            return View(viewModel);
        }



        // mobile 

        public ActionResult Mobile(int? lang)
        {
            var viewModel = new IndexViewModel
            {
                Lang = lang != null ? lang.Value : 0
            };

            return View(viewModel);
        }
    }
}
