using GOQUAL.Models;
using GOQUAL.Views.Info;
using GOQUAL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOQUAL.Service;

namespace GOQUAL.Controllers
{
    public class InfoController : Controller
    {
        BlogService Blogsvc = new BlogService();
        NewsService Newssvc = new NewsService();

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

            //var blogs = Blogsvc.GetBlogs(1, 6);

            var viewModel = new IndexViewModel
            {
                Lang = lang != null ? lang.Value : 0,
                Blogs = new List<BlogDTO>()
            };

            return View(viewModel);
        }

        public ActionResult Mobile(int? lang)
        {
            var viewModel = new IndexViewModel
            {
                Lang = lang != null ? lang.Value : 0
            };

            return View(viewModel);
        }

        public ActionResult DetailBlog(int? lang, int id)
        {
            if (id == 0 || id < 0)
            {
                return RedirectToAction("Index");
            }

            var viewmodel = new DetailViewModel
            {
                Id = id,
                Lang = lang != null ? lang.Value : 0
            };

            return View(viewmodel);
        }

        public ActionResult BlogCreate()
        {
            return View();
        }

        public ActionResult DetailNews(int? lang, int id)
        {
            if (id == 0 || id < 0)
            {
                return RedirectToAction("Index");
            }

            var viewmodel = new DetailViewModel
            {
                Id = id,
                Lang = lang != null ? lang.Value : 0
            };

            return View(viewmodel);
        }

        public ActionResult Mo_DetailNews(int? lang, int id)
        {
            if (id == 0 || id < 0)
            {
                return RedirectToAction("Index");
            }

            var viewmodel = new DetailViewModel
            {
                Id = id,
                Lang = lang != null ? lang.Value : 0
            };

            return View(viewmodel);
        }
        public ActionResult Mo_DetailBlog(int? lang, int id)
        {
            if (id == 0 || id < 0)
            {
                return RedirectToAction("Index");
            }

            var viewmodel = new DetailViewModel
            {
                Id = id,
                Lang = lang != null ? lang.Value : 0
            };

            return View(viewmodel);
        }









        //// JsonResult

        //public JsonResult GetEachBlog(int id)
        //{
        //    var blog = Blogsvc.GetBlog(id);

        //    return Json(blog, JsonRequestBehavior.AllowGet);
        //}

        //[ValidateInput(false)]
        //public JsonResult SaveBlogImage(List<string> base64Str)
        //{
        //    var rtv = Blogsvc.SaveBlogImage(base64Str);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //[ValidateInput(false)]
        //public JsonResult EditBlog(int id, string title, string content, List<int> imageIds)
        //{
        //    var rtv = Blogsvc.EditBlog(id, title, content, imageIds);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //[ValidateInput(false)]
        //public JsonResult CreateBlog(string title, string content, List<Int32> imageIds)
        //{
        //    var rtv = Blogsvc.CreateBlog(title, content, imageIds);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 덧글 등록
        //public JsonResult RegistComment(string name, string comment, string password, int blogId, int? commentId)
        //{
        //    var rtv = Blogsvc.RegistComment(name, comment, password, blogId, commentId);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 댓글 수정
        //public JsonResult EditComment(string name, string comment, int id)
        //{
        //    var rtv = Blogsvc.EditComment(name, comment, id);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 댓글 가져오기
        //public JsonResult GetComments(int blogId, int page, int perPage)
        //{
        //    var rtv = Blogsvc.GetComments(blogId, page, perPage);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 댓글 삭제
        //public JsonResult DeleteComment(int id, string password)
        //{
        //    var rtv = Blogsvc.DeleteCommet(id, password);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 댓글 강제 삭제
        //public JsonResult DeleteCommentForced(int id)
        //{
        //    var rtv = Blogsvc.DeleteCommentForced(id);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 블로그 지우기
        //public JsonResult DeleteBlog(int id)
        //{
        //    var rtv = Blogsvc.DeleteBlog(id);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 블로그 글 들고오기
        //public JsonResult GetBlogs(int page, int perPage)
        //{
        //    //var blogs = Blogsvc.GetBlogs(page, perPage);

        //    //return Json(blogs, JsonRequestBehavior.AllowGet);
        //    return Json(null, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult GetTotalBlogCount()
        //{
        //    var rtv = Blogsvc.GetTotalBlogCount();

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //public FileResult GetBlogImage(int id)
        //{
        //    var image = Blogsvc.GetImage(id);

        //    if (image != null)
        //    {
        //        return File(image.content, "image/png");
        //    }
        //    else
        //    {
        //        return File(new byte[0], "image/png");
        //    }
        //}






        //#region news

        //public JsonResult GetNews(Dictionary<string, string> sorting, Dictionary<string, string> filter, int page = 1, int count = 10)
        //{
        //    return Json(new ItemsDTO<NewsDTO>
        //    {
        //        Items = new List<NewsDTO>(),
        //        PerPage = 10,
        //        RowCount = 0
        //    }, JsonRequestBehavior.AllowGet);
        //    //var perPage = count;

        //    //using (var db = new GoqualEntities())
        //    //{
        //    //    IQueryable<News> items = db.News;

        //    //    if (sorting != null)
        //    //    {
        //    //        var st = sorting.First();
        //    //        switch (st.Key)
        //    //        {
        //    //            case "Id":
        //    //                items = st.Value.Equals("asc") ? items.OrderBy(x => x.C_newsid) : items.OrderByDescending(x => x.C_newsid);
        //    //                break;
        //    //            case "Title":
        //    //                items = st.Value.Equals("asc") ? items.OrderBy(x => x.title) : items.OrderByDescending(x => x.title);
        //    //                break;
        //    //            case "Created":
        //    //                items = st.Value.Equals("asc") ? items.OrderBy(x => x.created) : items.OrderByDescending(x => x.created);
        //    //                break;
        //    //            case "Hit":
        //    //                items = st.Value.Equals("asc") ? items.OrderBy(x => x.hit) : items.OrderByDescending(x => x.hit);
        //    //                break;
        //    //            default:
        //    //                break;
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        items =
        //    //            from p in items
        //    //            orderby p.C_newsid descending
        //    //            select p;
        //    //    }

        //    //    IQueryable<NewsDTO> resultItems = (
        //    //        from a in items
        //    //        select new NewsDTO
        //    //        {
        //    //            Id = a.C_newsid,
        //    //            Title = a.title,
        //    //            Content = a.content,
        //    //            Created = a.created,
        //    //            Updated = a.updated,
        //    //            Hit = a.hit != null ? a.hit : 0,
        //    //        });

        //    //    if (perPage == -1)
        //    //    {
        //    //        var allItems = resultItems.ToList();
        //    //        return Json(new ItemsDTO<NewsDTO>
        //    //        {
        //    //            Items = allItems,
        //    //            PerPage = perPage,
        //    //            RowCount = allItems.Count
        //    //        }, JsonRequestBehavior.AllowGet);
        //    //    }
        //    //    else
        //    //    {
        //    //        return Json(new ItemsDTO<NewsDTO>
        //    //        {
        //    //            Items = resultItems.OrderBy(x => x.Id).Skip((page - 1) * perPage).Take(perPage).ToList<NewsDTO>(),
        //    //            PerPage = perPage,
        //    //            RowCount = resultItems.Count()
        //    //        }, JsonRequestBehavior.AllowGet);
        //    //    }
        //    //}
        //}

        //public JsonResult GetBlogs_ngtable(Dictionary<string, string> sorting, Dictionary<string, string> filter, int page = 1, int count = 10)
        //{
        //    var perPage = count;

        //    using (var db = new GoqualEntities())
        //    {
        //        IQueryable<Blog> items = db.Blogs;

        //        if (sorting != null)
        //        {
        //            var st = sorting.First();
        //            switch (st.Key)
        //            {
        //                case "Id":
        //                    items = st.Value.Equals("asc") ? items.OrderBy(x => x.C_blogid) : items.OrderByDescending(x => x.C_blogid);
        //                    break;
        //                case "Title":
        //                    items = st.Value.Equals("asc") ? items.OrderBy(x => x.title) : items.OrderByDescending(x => x.title);
        //                    break;
        //                case "Created":
        //                    items = st.Value.Equals("asc") ? items.OrderBy(x => x.created) : items.OrderByDescending(x => x.created);
        //                    break;
        //                case "Hit":
        //                    items = st.Value.Equals("asc") ? items.OrderBy(x => x.hit) : items.OrderByDescending(x => x.hit);
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            items =
        //                from p in items
        //                orderby p.C_blogid descending
        //                select p;
        //        }

        //        IQueryable<BlogDTO> resultItems = (
        //            from a in items
        //            select new BlogDTO
        //            {
        //                Id = a.C_blogid,
        //                Title = a.title,
        //                Content = a.content,
        //                Created = a.created,
        //                Updated = a.updated,
        //                Hit = a.hit != null ? a.hit : 0,
        //            });

        //        if (perPage == -1)
        //        {
        //            var allItems = resultItems.ToList();
        //            return Json(new ItemsDTO<BlogDTO>
        //            {
        //                Items = allItems,
        //                PerPage = perPage,
        //                RowCount = allItems.Count
        //            }, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(new ItemsDTO<BlogDTO>
        //            {
        //                Items = resultItems.OrderBy(x => x.Id).Skip((page - 1) * perPage).Take(perPage).ToList<BlogDTO>(),
        //                PerPage = perPage,
        //                RowCount = resultItems.Count()
        //            }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //}

        //public JsonResult CreateNews(string title, string content)
        //{
        //    using (var db = new GoqualEntities())
        //    {
        //        try
        //        {
        //            var news = new News
        //            {
        //                title = title,
        //                content = content,
        //                created = DateTime.Now,
        //                updated = DateTime.Now,
        //                password = "",
        //                hit = 0,
        //            };

        //            db.News.Add(news);
        //            db.SaveChanges();

        //            return Json(news.C_newsid, JsonRequestBehavior.AllowGet);
        //        }
        //        catch (Exception e)
        //        {
        //            return Json(-1, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //}

        //public JsonResult getEachNews(int id)
        //{
        //    using (var db = new GoqualEntities())
        //    {
        //        var dbNews = db.News.FirstOrDefault(x => x.C_newsid == id);

        //        if (dbNews != null)
        //        {
        //            dbNews.hit += 1;

        //            db.SaveChanges();

        //            var news = (from a in db.News
        //                        where a.C_newsid == id
        //                        select new NewsDTO
        //                        {
        //                            Id = a.C_newsid,
        //                            Title = a.title,
        //                            Content = a.content,
        //                            Created = a.created,
        //                            Updated = a.updated,
        //                            Hit = a.hit != null ? a.hit : 0,
        //                            NewsCommentsQuery = (from b in a.NewsComments
        //                                                 orderby b.C_newscommentid descending
        //                                                 select new NewsCommentDTO
        //                                                 {
        //                                                     Id = b.C_newscommentid,
        //                                                 })
        //                        }).FirstOrDefault();

        //            if (news != null)
        //            {
        //                return Json(news, JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                return Json(new NewsDTO(), JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        else
        //        {
        //            return Json(new NewsDTO(), JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //}

        //// News 수정
        //[HttpPost]
        //[ValidateInput(false)]
        //public JsonResult EditNews(int id, string title, string content)
        //{
        //    var result = Newssvc.EditNews(id, title, content);

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        //[ValidateInput(false)]
        //public JsonResult CreateBlog(string title, string content)
        //{
        //    var rtv = Newssvc.CreateAdvise(title, content);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 덧글 등록
        //public JsonResult RegistNewsComment(string name, string comment, string password, int newsid, int? commentId)
        //{
        //    var rtv = Newssvc.RegistComment(name, comment, password, newsid, commentId);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 댓글 수정
        //public JsonResult EditNewsComment(string name, string comment, int id)
        //{
        //    var rtv = Newssvc.EditComment(name, comment, id);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 댓글 가져오기
        //public JsonResult GetNewsComments(int newsid, int page, int perPage)
        //{
        //    var rtv = Newssvc.GetComments(newsid, page, perPage);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 댓글 삭제
        //public JsonResult DeleteNewsComment(int id, string password)
        //{
        //    var rtv = Newssvc.DeleteCommet(id, password);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 댓글 강제 삭제
        //public JsonResult DeleteNewsCommentForced(int id)
        //{
        //    var rtv = Newssvc.DeleteCommentForced(id);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// News 지우기
        //public JsonResult DeleteNews(int id)
        //{
        //    var rtv = Newssvc.DeleteNews(id);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// News 비밀번호 확인
        //public JsonResult ConfirmPassword(int id, string password)
        //{
        //    var result = Newssvc.ConfirmPassword(id, password);

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}


        //#endregion
    }
}
