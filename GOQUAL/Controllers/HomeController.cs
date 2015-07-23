using GOQUAL.Models.DTO;
using GOQUAL.Service;
using GOQUAL.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOQUAL.Controllers
{
    public class HomeController : Controller
    {
        BlogService Blogsvc = new BlogService();

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
            //var blogs = Blogsvc.GetBlogs(1, 3);

            var viewModel = new IndexViewModel
            {
                Lang = lang != null ? lang.Value : 0,
                Blogs = new List<BlogDTO>()
            };

            return View(viewModel);
        }

        public ActionResult Mobile(int? lang)
        {
            //var blogs = Blogsvc.GetBlogs(1, 3);

            var viewModel = new IndexViewModel
            {
                Lang = lang != null ? lang.Value : 0,
                Blogs = new List<BlogDTO>()
            };

            return View(viewModel);
        }
    }
}
