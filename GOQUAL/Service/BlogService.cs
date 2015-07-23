using GOQUAL.Models;
using GOQUAL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Service
{
    public class BlogService
    {
        //GoqualEntities db = new GoqualEntities();

        //public BlogDTO GetBlog(int id)
        //{
        //    var dbBlog = db.Blogs.FirstOrDefault(x => x.C_blogid == id);

        //    if (dbBlog != null)
        //    {
        //        dbBlog.hit += 1;

        //        db.SaveChanges();

        //        var blog = (from a in db.Blogs
        //                    where a.C_blogid == id
        //                    select new BlogDTO
        //                    {
        //                        Id = a.C_blogid,
        //                        Title = a.title,
        //                        Content = a.content,
        //                        Created = a.created,
        //                        Updated = a.updated,
        //                        Hit = a.hit != null ? a.hit : 0,
        //                        For_BlogtypeId = a.for_blogtypeid,
        //                        CommentsQuery = (from b in a.Comments
        //                                         orderby b.C_commentid descending
        //                                         select new CommentDTO
        //                                         {
        //                                             Id = b.C_commentid,
        //                                             Name = b.name,
        //                                             Comment = b.comment1,
        //                                             Created = b.created,
        //                                             Updated = b.updated,
        //                                             For_BlogId = b.for_blogid,
        //                                             For_CommentId = b.for_commentid != null ? b.for_commentid.Value : 0
        //                                         })
        //                    }).FirstOrDefault();

        //        var beforeBlog = db.Blogs.Where(x => x.C_blogid < id).OrderByDescending(x => x.C_blogid).FirstOrDefault();
        //        if (beforeBlog != null)
        //        {
        //            blog.BeforBlogId = beforeBlog.C_blogid;
        //        }

        //        var afterBlog = db.Blogs.Where(x => x.C_blogid > id).OrderBy(x => x.C_blogid).FirstOrDefault();
        //        if (afterBlog != null)
        //        {
        //            blog.AfterBlogId = afterBlog.C_blogid;
        //        }

        //        if (blog != null)
        //        {
        //            return blog;
        //        }
        //        else
        //        {
        //            return new BlogDTO();
        //        }
        //    }
        //    else
        //    {
        //        return new BlogDTO();
        //    }
        //}

        //public List<BlogDTO> GetBlogs(int page, int perPage)
        //{
        //    var blogs = (from a in db.Blogs
        //                 orderby a.C_blogid descending
        //                 select new BlogDTO
        //                 {
        //                     Id = a.C_blogid,
        //                     Title = a.title,
        //                     Content = a.content,
        //                     Created = a.created,
        //                     Updated = a.updated,
        //                     Hit = a.hit != null ? a.hit : 0,
        //                     For_BlogtypeId = a.for_blogtypeid,
        //                     FirstBlogImage = (from b in a.BlogImages
        //                                       orderby b.C_blogimageid
        //                                       select new BlogImageDTO
        //                                       {
        //                                           Id = b.C_blogimageid
        //                                       }).FirstOrDefault(),
        //                     CommentsQuery = (from b in a.Comments
        //                                      orderby b.C_commentid descending
        //                                      select new CommentDTO
        //                                      {
        //                                          Id = b.C_commentid,
        //                                          Name = b.name,
        //                                          Comment = b.comment1,
        //                                          Created = b.created,
        //                                          Updated = b.updated,
        //                                          For_BlogId = b.for_blogid,
        //                                          For_CommentId = b.for_commentid != null ? b.for_commentid.Value : 0
        //                                      })
        //                 }).Skip(perPage * (page - 1)).Take(perPage).ToList();

        //    return blogs;
        //}

        //public int GetTotalBlogCount()
        //{
        //    var count = db.Blogs.Count();

        //    return count;
        //}

        //public List<int> SaveBlogImage(List<string> base64StringArray)
        //{
        //    try
        //    {
        //        var blogImgs = new List<BlogImage>();

        //        foreach (var str in base64StringArray)
        //        {
        //            byte[] imageBytes = Convert.FromBase64String(str);

        //            var blogImg = new BlogImage
        //            {
        //                content = imageBytes
        //            };

        //            blogImgs.Add(blogImg);
        //            db.BlogImages.Add(blogImg);
        //        }

        //        db.SaveChanges();

        //        return blogImgs.Select(x => x.C_blogimageid).ToList();

        //    }
        //    catch (Exception e)
        //    {
        //        var exception = e;
        //        return new List<int>();
        //    }
        //}

        //public bool DeleteBlog(int id)
        //{
        //    try
        //    {
        //        var blog = db.Blogs.FirstOrDefault(x => x.C_blogid == id);

        //        if (blog != null)
        //        {
        //            db.BlogImages.RemoveRange(blog.BlogImages);
        //            db.Comments.RemoveRange(blog.Comments);
        //            db.Blogs.Remove(blog);

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

        //public CommentBodyDTO GetComments(int blogId, int page, int perPage)
        //{
        //    try
        //    {
        //        var comments = (from a in db.Comments
        //                        where a.for_blogid == blogId
        //                        orderby a.C_commentid descending
        //                        select new CommentDTO
        //                        {
        //                            Id = a.C_commentid,
        //                            Name = a.name,
        //                            Comment = a.comment1,
        //                            Created = a.created,
        //                            Password = a.password,
        //                            Updated = a.updated,
        //                            For_BlogId = a.for_blogid,
        //                            For_CommentId = a.for_commentid != null ? a.for_commentid.Value : 0,
        //                        }).Skip(perPage * (page - 1)).Take(perPage).ToList();

        //        var repository = new List<CommentDTO>();

        //        foreach (var each in comments)
        //        {
        //            if (each.For_CommentId == 0)
        //            {
        //                var addItem = recursiveComment(each, comments);
        //                repository.Add(addItem);
        //            }
        //        }

        //        return new CommentBodyDTO
        //        {
        //            Comments = repository,
        //            TotalCount = comments.Count
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        return new CommentBodyDTO();
        //    }
        //}

        //public CommentDTO recursiveComment(CommentDTO target, List<CommentDTO> list)
        //{
        //    target.Comments = new List<CommentDTO>();

        //    foreach (var each in list)
        //    {
        //        if (each.For_CommentId == target.Id)
        //        {
        //            var addItem = recursiveComment(each, list);
        //            target.Comments.Add(addItem);
        //        }
        //    }

        //    return target;
        //}

        //public int DeleteCommet(int id, string password)
        //{
        //    try
        //    {
        //        var comment = db.Comments.FirstOrDefault(x => x.C_commentid == id);

        //        if (comment != null)
        //        {
        //            if (comment.password.Equals(password))
        //            {
        //                db.Comments.RemoveRange(comment.Comment11);

        //                db.SaveChanges();

        //                db.Comments.Remove(comment);

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
        //        var comment = db.Comments.FirstOrDefault(x => x.C_commentid == id);

        //        if (comment != null)
        //        {
        //            if (comment.for_commentid == null)
        //            {
        //                db.Comments.RemoveRange(comment.Comment11);

        //                db.SaveChanges();
        //            }

        //            db.Comments.Remove(comment);

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

        //public CommentDTO RegistComment(string name, string content, string password, int blogId, int? commentId)
        //{
        //    try
        //    {
        //        var comment = new Comment
        //        {
        //            name = name,
        //            comment1 = content,
        //            password = password,
        //            for_blogid = blogId,
        //            created = DateTime.Now,
        //            updated = DateTime.Now,
        //            for_commentid = commentId
        //        };

        //        db.Comments.Add(comment);
        //        db.SaveChanges();

        //        return new CommentDTO
        //        {
        //            Id = comment.C_commentid,
        //            Name = comment.name,
        //            For_BlogId = comment.for_blogid,
        //            For_CommentId = comment.for_commentid != null ? comment.for_commentid.Value : 0,
        //            Comment = comment.comment1,
        //            Created = comment.created,
        //            Updated = comment.updated,
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        var exception = e;
        //        return new CommentDTO();
        //    }
        //}

        //public int EditComment(string name, string comment, int id)
        //{
        //    try
        //    {
        //        var dbItem = db.Comments.FirstOrDefault(x => x.C_commentid == id);

        //        if (comment != null)
        //        {
        //            dbItem.name = name;
        //            dbItem.comment1 = comment;

        //            db.SaveChanges();

        //            return dbItem.C_commentid;
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

        //public int CreateBlog(string title, string content, List<int> imageIds)
        //{
        //    try
        //    {
        //        // blog 저장
        //        var blog = new Blog
        //        {
        //            for_blogtypeid = 1,
        //            title = title,
        //            content = content,
        //            created = DateTime.Now,
        //            updated = DateTime.Now,
        //            hit = 0
        //        };

        //        db.Blogs.Add(blog);
        //        db.SaveChanges();

        //        // blogtoblogimage 저장

        //        foreach (var id in imageIds)
        //        {
        //            var blogimage = db.BlogImages.First(x => x.C_blogimageid == id);

        //            if (blogimage != null)
        //            {
        //                blog.BlogImages.Add(blogimage);
        //            }
        //        }

        //        db.SaveChanges();

        //        return blog.C_blogid;
        //    }
        //    catch (Exception e)
        //    {
        //        var exception = e;
        //        return -1;
        //    }
        //}

        //public int EditBlog(int id, string title, string content, List<int> imageIds)
        //{
        //    try
        //    {
        //        var blog = db.Blogs.FirstOrDefault(x => x.C_blogid == id);

        //        if (blog != null)
        //        {
        //            blog.title = title;
        //            blog.content = content;
        //            blog.updated = DateTime.Now;

        //            db.BlogImages.RemoveRange(blog.BlogImages);

        //            // blogtoblogimage 저장

        //            foreach (var each in imageIds)
        //            {
        //                var blogimage = db.BlogImages.First(x => x.C_blogimageid == each);

        //                if (blogimage != null)
        //                {
        //                    blog.BlogImages.Add(blogimage);
        //                }
        //            }

        //            db.SaveChanges();

        //            return blog.C_blogid;
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

        //public BlogImage GetImage(int id)
        //{
        //    try
        //    {
        //        var image = db.BlogImages.FirstOrDefault(x => x.C_blogimageid == id);

        //        if (image != null)
        //        {
        //            return image;
        //        }
        //        else
        //        {
        //            return new BlogImage { content = new byte[1] };
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return new BlogImage { content = new byte[1] };
        //    }
        //}
    }
}