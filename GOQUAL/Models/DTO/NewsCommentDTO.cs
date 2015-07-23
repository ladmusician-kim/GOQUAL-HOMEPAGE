using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Models.DTO
{
    public class NewsCommentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int For_NewsId { get; set; }
        public int For_NewsCommentId { get; set; }

        public NewsCommentDTO Followed_NewsComment { get; set; }
        public NewsDTO Advise { get; set; }

        private List<NewsCommentDTO> _newsComments;
        public virtual IEnumerable<NewsCommentDTO> NewsCommentsQuery { get; set; }
        public virtual List<NewsCommentDTO> NewsComments
        {
            get
            {
                if (_newsComments == null && NewsCommentsQuery != null)
                    _newsComments = NewsCommentsQuery.ToList();
                return _newsComments;
            }
            set
            {
                NewsCommentsQuery = _newsComments = value;
            }
        }
    }
}