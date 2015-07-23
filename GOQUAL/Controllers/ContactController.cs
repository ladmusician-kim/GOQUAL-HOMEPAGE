using GOQUAL.Models;
using GOQUAL.Models.DTO;
using GOQUAL.Service;
using GOQUAL.Views.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOQUAL.Controllers
{
    public class ContactController : Controller
    {
        ContactService Contactsvc = new ContactService();

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

            var viewModel = new IndexViewModel
            {
                Lang = lang != null ? lang.Value : 0,
            };

            return View(viewModel);
        }

        public ActionResult Mobile(int? lang)
        {
            var viewModel = new IndexViewModel
            {
                Lang = lang != null ? lang.Value : 0,
            };

            return View(viewModel);
        }

        public ActionResult Create(int? lang)
        {
            var viewModel = new IndexViewModel
            {
                Lang = lang != null ? lang.Value : 0,
            };

            return View(viewModel);
        }

        public ActionResult Mo_Create(int? lang)
        {
            var viewModel = new IndexViewModel
            {
                Lang = lang != null ? lang.Value : 0,
            };

            return View(viewModel);
        }

        public ActionResult Detail(int? lang, int id)
        {
            var viewmodel = new DetailViewModel
            {
                Id = id,
                Lang = lang != null ? lang.Value : 0
            };

            return View(viewmodel);
        }

        public ActionResult Mo_Detail(int? lang, int id)
        {
            var viewmodel = new DetailViewModel
            {
                Id = id,
                Lang = lang != null ? lang.Value : 0
            };

            return View(viewmodel);
        }


        // jsonResult

        public JsonResult SendMessage(string name, string email, string phone, string content)
        {
            try
            {
                var message = string.Format(
                "<html><b>{0}</b>고객님께서 문의해주신 내용<br/><br/>" +
                "<b>메일: </b>{1}<br/><br/>" +
                "<b>연락처: </b> {2}<br/><br/>" +
                "<b>내용: </b> {3}<br/><br/>" +
                "</html>",
                name, email, phone, content);

                MailService.SendAsync("ladmusician.kgj@gmail.com", name + "님께서 문의하신 내용입니다", message);

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        //public JsonResult GetAdvise(Dictionary<string, string> sorting, Dictionary<string, string> filter, int page = 1, int count = 10)
        //{
        //    return Json(new ItemsDTO<AdviseDTO>
        //    {
        //        Items = new List<AdviseDTO>(),
        //        PerPage = 10,
        //        RowCount = 0
        //    }, JsonRequestBehavior.AllowGet);
        //    //var perPage = count;

        //    //using (var db = new GoqualEntities())
        //    //{
        //    //    IQueryable<Advise> items = db.Advises;

        //    //    if (sorting != null)
        //    //    {
        //    //        var st = sorting.First();
        //    //        switch (st.Key)
        //    //        {
        //    //            case "Id":
        //    //                items = st.Value.Equals("asc") ? items.OrderBy(x => x.C_adviseid) : items.OrderByDescending(x => x.C_adviseid);
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
        //    //            orderby p.C_adviseid descending
        //    //            select p;
        //    //    }

        //    //    IQueryable<AdviseDTO> resultItems = (
        //    //        from a in items
        //    //        select new AdviseDTO
        //    //        {
        //    //            Id = a.C_adviseid,
        //    //            Title = a.title,
        //    //            Content = a.content,
        //    //            Created = a.created,
        //    //            Updated = a.updated,
        //    //            Hit = a.hit != null ? a.hit : 0,
        //    //        });

        //    //    if (perPage == -1)
        //    //    {
        //    //        var allItems = resultItems.ToList();
        //    //        return Json(new ItemsDTO<AdviseDTO>
        //    //        {
        //    //            Items = allItems,
        //    //            PerPage = perPage,
        //    //            RowCount = allItems.Count
        //    //        }, JsonRequestBehavior.AllowGet);
        //    //    }
        //    //    else
        //    //    {
        //    //        var allItems = resultItems.ToList();
        //    //        return Json(new ItemsDTO<AdviseDTO>
        //    //        {
        //    //            Items = resultItems.OrderBy(x => x.Id).Skip((page - 1) * perPage).Take(perPage).ToList<AdviseDTO>(),
        //    //            PerPage = perPage,
        //    //            RowCount = resultItems.Count()
        //    //        }, JsonRequestBehavior.AllowGet);
        //    //    }
        //    //}
        //}

        //public JsonResult CreateAdvise(string title, string content, string password)
        //{
        //    using (var db = new GoqualEntities())
        //    {
        //        try
        //        {
        //            var advise = new Advise
        //            {
        //                title = title,
        //                content = content,
        //                created = DateTime.Now,
        //                updated = DateTime.Now,
        //                password = password,
        //                hit = 0,
        //            };

        //            db.Advises.Add(advise);
        //            db.SaveChanges();

        //            return Json(advise.C_adviseid, JsonRequestBehavior.AllowGet);
        //        }
        //        catch (Exception e)
        //        {
        //            return Json(-1, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //}

        //public JsonResult GetEachAdvise(int id)
        //{
        //    using (var db = new GoqualEntities())
        //    {
        //        var dbAdvise = db.Advises.FirstOrDefault(x => x.C_adviseid == id);

        //        if (dbAdvise != null)
        //        {
        //            dbAdvise.hit += 1;

        //            db.SaveChanges();

        //            var advise = (from a in db.Advises
        //                        where a.C_adviseid == id
        //                        select new AdviseDTO
        //                        {
        //                            Id = a.C_adviseid,
        //                            Title = a.title,
        //                            Content = a.content,
        //                            Created = a.created,
        //                            Updated = a.updated,
        //                            Hit = a.hit != null ? a.hit : 0,
        //                            AdviseCommentsQuery = (from b in a.AdviseComments
        //                                                   orderby b.C_advisecommentid descending
        //                                                   select new AdviseCommentDTO
        //                                                   {
        //                                                       Id = b.C_advisecommentid,
        //                                                   })
        //                        }).FirstOrDefault();

        //            if (advise != null)
        //            {
        //                return Json(advise, JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                return Json(new AdviseDTO(), JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        else
        //        {
        //            return Json(new AdviseDTO(), JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //}

        //[HttpPost]
        //[ValidateInput(false)]
        //public JsonResult EditAdvise(int id, string title, string content)
        //{
        //    var rtv = Contactsvc.EditAdvise(id, title, content);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //[ValidateInput(false)]
        //public JsonResult CreateBlog(string title, string content)
        //{
        //    var rtv = Contactsvc.CreateAdvise(title, content);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 덧글 등록
        //public JsonResult RegistComment(string name, string comment, string password, int adviseId, int? commentId)
        //{
        //    var rtv = Contactsvc.RegistComment(name, comment, password, adviseId, commentId);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 댓글 수정
        //public JsonResult EditComment(string name, string comment, int id)
        //{
        //    var rtv = Contactsvc.EditComment(name, comment, id);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 댓글 가져오기
        //public JsonResult GetComments(int adviseId, int page, int perPage)
        //{
        //    var rtv = Contactsvc.GetComments(adviseId, page, perPage);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 댓글 삭제
        //public JsonResult DeleteComment(int id, string password)
        //{
        //    var rtv = Contactsvc.DeleteCommet(id, password);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// 댓글 강제 삭제
        //public JsonResult DeleteCommentForced(int id)
        //{
        //    var rtv = Contactsvc.DeleteCommentForced(id);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// advise 지우기
        //public JsonResult DeleteAdvise(int id)
        //{
        //    var rtv = Contactsvc.DeleteAdvise(id);

        //    return Json(rtv, JsonRequestBehavior.AllowGet);
        //}

        //// advise 비밀번호 확인
        //public JsonResult ConfirmPassword(int id, string password)
        //{
        //    var result = Contactsvc.ConfirmPassword(id, password);

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}
