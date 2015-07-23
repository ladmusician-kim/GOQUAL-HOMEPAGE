using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Models.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int For_BlogId { get; set; }
        public int For_CommentId { get; set; }

        public CommentDTO Followed_Comment { get; set; }
        public BlogDTO Blog { get; set; }

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
    }
}