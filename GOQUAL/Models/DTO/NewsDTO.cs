using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Models.DTO
{
    public class NewsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool IsDeprecated { get; set; }
        public int? Hit { get; set; }

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