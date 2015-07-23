using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Models.DTO
{
    public class BlogDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool IsDeprecated { get; set; }
        public int? Hit { get; set; }

        public int For_BlogtypeId { get; set; }
        public BlogtypeDTO Blogtype { get; set; }

        public BlogImageDTO FirstBlogImage { get; set; }

        private List<BlogImageDTO> _blogImages;
        public virtual IEnumerable<BlogImageDTO> BlogImagesQuery { get; set; }
        public virtual List<BlogImageDTO> BlogImages
        {
            get
            {
                if (_blogImages == null && BlogImagesQuery != null)
                    _blogImages = BlogImagesQuery.ToList();
                return _blogImages;
            }
            set
            {
                BlogImagesQuery = _blogImages = value;
            }
        }

        private List<CommentDTO> _comments;
        public virtual IEnumerable<CommentDTO> CommentsQuery { get; set; }
        public virtual List<CommentDTO> Comments
        {
            get
            {
                if (_comments == null && CommentsQuery != null)
                    _comments = CommentsQuery.ToList();
                return _comments;
            }
            set
            {
                CommentsQuery = _comments = value;
            }
        }

        public int BeforBlogId { get; set; }
        public int AfterBlogId { get; set; }
    }
}