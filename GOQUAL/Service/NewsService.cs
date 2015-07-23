using GOQUAL.Models;
using GOQUAL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Service
{
    public class NewsService
    {
        //public GoqualEntities db = new GoqualEntities();

        //// 댓글 삭제
        //public int DeleteCommet(int id, string password)
        //{
        //    try
        //    {
        //        var comment = db.NewsComments.FirstOrDefault(x => x.C_newscommentid == id);

        //        if (comment != null)
        //        {
        //            if (comment.password.Equals(password))
        //            {
        //                db.NewsComments.RemoveRange(comment.NewsComment1);

        //                db.SaveChanges();

        //                db.NewsComments.Remove(comment);

        //                db.SaveChanges();

        //                // 성공
        //                return 1;
        //            }
        //            else
        //            {
        //                // 비밀번호 다름
        //                return 2;
        //            }
        //        }
        //        else
        //        {
        //            // 실패
        //            return 3;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        // 실패
        //        return 3;
        //    }
        //}

        //public int DeleteCommentForced(int id)
        //{
        //    try
        //    {
        //        var comment = db.NewsComments.FirstOrDefault(x => x.C_newscommentid == id);

        //        if (comment != null)
        //        {
        //            if (comment.NewsComment1.Count() > 0)
        //            {
        //                db.NewsComments.RemoveRange(comment.NewsComment1);

        //                db.SaveChanges();
        //            }

        //            db.NewsComments.Remove(comment);

        //            db.SaveChanges();

        //            // 성공
        //            return 1;
        //        }
        //        else
        //        {
        //            // 실패
        //            return 3;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        // 실패
        //        return 3;
        //    }
        //}

        //// 덧글 등록
        //public NewsCommentDTO RegistComment(string name, string content, string password, int newsid, int? commentId)
        //{
        //    try
        //    {
        //        var comment = new NewsComment
        //        {
        //            name = name,
        //            comment = content,
        //            password = password,
        //            for_newsid = newsid,
        //            created = DateTime.Now,
        //            updated = DateTime.Now,
        //            for_newscommentid = commentId
        //        };

        //        db.NewsComments.Add(comment);
        //        db.SaveChanges();

        //        return new NewsCommentDTO
        //        {
        //            Id = comment.C_newscommentid,
        //            Name = comment.name,
        //            For_NewsId = comment.C_newscommentid,
        //            For_NewsCommentId = comment.for_newscommentid != null ? comment.for_newscommentid.Value : 0,
        //            Comment = comment.comment,
        //            Created = comment.created,
        //            Updated = comment.updated,
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        var exception = e;
        //        return new NewsCommentDTO();
        //    }
        //}

        //// 댓글 수정
        //public int EditComment(string name, string comment, int id)
        //{
        //    try
        //    {
        //        var dbItem = db.NewsComments.FirstOrDefault(x => x.C_newscommentid == id);

        //        if (comment != null)
        //        {
        //            dbItem.name = name;
        //            dbItem.comment = comment;

        //            db.SaveChanges();

        //            return dbItem.C_newscommentid;
        //        }
        //        else
        //        {
        //            return -1;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return -1;
        //    }
        //}

        //// 댓글 가져오기
        //public NewsCommentBodyDTO GetComments(int newsid, int page, int perPage)
        //{
        //    try
        //    {
        //        var comments = (from a in db.NewsComments
        //                        where a.for_newsid == newsid
        //                        orderby a.C_newscommentid descending
        //                        select new NewsCommentDTO
        //                        {
        //                            Id = a.C_newscommentid,
        //                            Name = a.name,
        //                            Comment = a.comment,
        //                            Created = a.created,
        //                            Password = a.password,
        //                            Updated = a.updated,
        //                            For_NewsId = a.for_newsid,
        //                            For_NewsCommentId = a.for_newscommentid != null ? a.for_newscommentid.Value : 0,
        //                        }).Skip(perPage * (page - 1)).Take(perPage).ToList();

        //        var repository = new List<NewsCommentDTO>();

        //        foreach (var each in comments)
        //        {
        //            if (each.For_NewsCommentId == 0)
        //            {
        //                var addItem = recursiveComment(each, comments);
        //                repository.Add(addItem);
        //            }
        //        }

        //        return new NewsCommentBodyDTO
        //        {
        //            Comments = repository,
        //            TotalCount = comments.Count
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        return new NewsCommentBodyDTO();
        //    }
        //}

        //// 댓글에 덧글 넣기
        //public NewsCommentDTO recursiveComment(NewsCommentDTO target, List<NewsCommentDTO> list)
        //{
        //    target.NewsComments = new List<NewsCommentDTO>();

        //    foreach (var each in list)
        //    {
        //        if (each.For_NewsCommentId == target.Id)
        //        {
        //            var addItem = recursiveComment(each, list);
        //            target.NewsComments.Add(addItem);
        //        }
        //    }

        //    return target;
        //}

        //public int CreateAdvise(string title, string content)
        //{
        //    try
        //    {
        //        // advise 저장
        //        var news = new News
        //        {
        //            title = title,
        //            content = content,
        //            created = DateTime.Now,
        //            updated = DateTime.Now,
        //            hit = 0
        //        };

        //        db.News.Add(news);
        //        db.SaveChanges();

        //        db.SaveChanges();

        //        return news.C_newsid;
        //    }
        //    catch (Exception e)
        //    {
        //        var exception = e;
        //        return -1;
        //    }
        //}

        //public int DeleteNews(int id)
        //{
        //    try
        //    {
        //        var advise = db.News.FirstOrDefault(x => x.C_newsid == id);

        //        if (advise != null)
        //        {
        //            db.NewsComments.RemoveRange(advise.NewsComments);
        //            db.News.Remove(advise);

        //            db.SaveChanges();

        //            return 1;
        //        }
        //        else
        //        {
        //            return -1;
        //        }
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //}

        //public int EditNews(int id, string title, string content)
        //{
        //    try
        //    {
        //        var news = db.News.FirstOrDefault(x => x.C_newsid == id);

        //        if (news != null)
        //        {
        //            news.title = title;
        //            news.content = content;
        //            news.updated = DateTime.Now;

        //            db.SaveChanges();

        //            return news.C_newsid;
        //        }
        //        else
        //        {
        //            return -1;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        var exception = e;
        //        return -1;
        //    }
        //}

        //// advise 비밀번호 확인
        //public int ConfirmPassword(int id, string password)
        //{
        //    var news = db.News.FirstOrDefault(x => x.C_newsid == id);

        //    if (news != null)
        //    {
        //        if (news.password.Equals(password))
        //        {
        //            return news.C_newsid;
        //        }
        //        else
        //        {
        //            return -1;
        //        }
        //    }
        //    else
        //    {
        //        return -1;
        //    }
        //}
    }
}