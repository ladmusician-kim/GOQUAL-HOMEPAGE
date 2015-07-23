using GOQUAL.Models;
using GOQUAL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Service
{
    public class ContactService
    {
        //public GoqualEntities db = new GoqualEntities();

        //// 댓글 삭제
        //public int DeleteCommet(int id, string password)
        //{
        //    try
        //    {
        //        var comment = db.AdviseComments.FirstOrDefault(x => x.C_advisecommentid == id);

        //        if (comment != null)
        //        {
        //            if (comment.password.Equals(password))
        //            {
        //                db.AdviseComments.RemoveRange(comment.AdviseComment1);

        //                db.SaveChanges();

        //                db.AdviseComments.Remove(comment);

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
        //        var comment = db.AdviseComments.FirstOrDefault(x => x.C_advisecommentid == id);

        //        if (comment != null)
        //        {
        //            if (comment.AdviseComment1.Count() > 0)
        //            {
        //                db.AdviseComments.RemoveRange(comment.AdviseComment1);

        //                db.SaveChanges();
        //            }

        //            db.AdviseComments.Remove(comment);

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
        //public AdviseCommentDTO RegistComment(string name, string content, string password, int adviseId, int? commentId)
        //{
        //    try
        //    {
        //        var comment = new AdviseComment
        //        {
        //            name = name,
        //            comment = content,
        //            password = password,
        //            for_adviseid = adviseId,
        //            created = DateTime.Now,
        //            updated = DateTime.Now,
        //            for_advisecommentid = commentId
        //        };

        //        db.AdviseComments.Add(comment);
        //        db.SaveChanges();

        //        return new AdviseCommentDTO
        //        {
        //            Id = comment.C_advisecommentid,
        //            Name = comment.name,
        //            For_AdviseId = comment.for_adviseid,
        //            For_CommentId = comment.C_advisecommentid != null ? comment.for_advisecommentid.Value : 0,
        //            Comment = comment.comment,
        //            Created = comment.created,
        //            Updated = comment.updated,
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        var exception = e;
        //        return new AdviseCommentDTO();
        //    }
        //}

        //// 댓글 수정
        //public int EditComment(string name, string comment, int id)
        //{
        //    try
        //    {
        //        var dbItem = db.AdviseComments.FirstOrDefault(x => x.C_advisecommentid == id);

        //        if (comment != null)
        //        {
        //            dbItem.name = name;
        //            dbItem.comment = comment;

        //            db.SaveChanges();

        //            return dbItem.C_advisecommentid;
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
        //public AdviseCommentBodyDTO GetComments(int adviseId, int page, int perPage)
        //{
        //    try
        //    {
        //        var comments = (from a in db.AdviseComments
        //                        where a.for_adviseid == adviseId
        //                        orderby a.C_advisecommentid descending
        //                        select new AdviseCommentDTO
        //                        {
        //                            Id = a.C_advisecommentid,
        //                            Name = a.name,
        //                            Comment = a.comment,
        //                            Created = a.created,
        //                            Password = a.password,
        //                            Updated = a.updated,
        //                            For_AdviseId = a.for_adviseid,
        //                            For_CommentId = a.for_advisecommentid != null ? a.for_advisecommentid.Value : 0,
        //                        }).Skip(perPage * (page - 1)).Take(perPage).ToList();

        //        var repository = new List<AdviseCommentDTO>();

        //        foreach (var each in comments)
        //        {
        //            if (each.For_CommentId == 0)
        //            {
        //                var addItem = recursiveComment(each, comments);
        //                repository.Add(addItem);
        //            }
        //        }

        //        return new AdviseCommentBodyDTO
        //        {
        //            Comments = repository,
        //            TotalCount = comments.Count
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        return new AdviseCommentBodyDTO();
        //    }
        //}

        //// 댓글에 덧글 넣기
        //public AdviseCommentDTO recursiveComment(AdviseCommentDTO target, List<AdviseCommentDTO> list)
        //{
        //    target.AdviseComments = new List<AdviseCommentDTO>();

        //    foreach (var each in list)
        //    {
        //        if (each.For_CommentId == target.Id)
        //        {
        //            var addItem = recursiveComment(each, list);
        //            target.AdviseComments.Add(addItem);
        //        }
        //    }

        //    return target;
        //}

        //public int CreateAdvise(string title, string content)
        //{
        //    try
        //    {
        //        // advise 저장
        //        var advise = new Advise
        //        {
        //            title = title,
        //            content = content,
        //            created = DateTime.Now,
        //            updated = DateTime.Now,
        //            hit = 0
        //        };

        //        db.Advises.Add(advise);
        //        db.SaveChanges();

        //        db.SaveChanges();

        //        return advise.C_adviseid;
        //    }
        //    catch (Exception e)
        //    {
        //        var exception = e;
        //        return -1;
        //    }
        //}

        //public bool DeleteAdvise(int id)
        //{
        //    try
        //    {
        //        var advise = db.Advises.FirstOrDefault(x => x.C_adviseid == id);

        //        if (advise != null)
        //        {
        //            db.AdviseComments.RemoveRange(advise.AdviseComments);
        //            db.Advises.Remove(advise);

        //            db.SaveChanges();

        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public int EditAdvise(int id, string title, string content)
        //{
        //    try
        //    {
        //        var advise = db.Advises.FirstOrDefault(x => x.C_adviseid == id);

        //        if (advise != null)
        //        {
        //            advise.title = title;
        //            advise.content = content;
        //            advise.updated = DateTime.Now;

        //            db.SaveChanges();

        //            return advise.C_adviseid;
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
        //    var advise = db.Advises.FirstOrDefault(x => x.C_adviseid == id);

        //    if (advise != null)
        //    {
        //        if (advise.password.Equals(password))
        //        {
        //            return advise.C_adviseid;
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