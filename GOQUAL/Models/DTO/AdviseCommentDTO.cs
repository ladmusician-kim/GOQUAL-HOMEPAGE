using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Models.DTO
{
    public class AdviseCommentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int For_AdviseId { get; set; }
        public int For_CommentId { get; set; }

        public AdviseCommentDTO Followed_Comment { get; set; }
        public AdviseDTO Advise { get; set; }

        private List<AdviseCommentDTO> _adviseComments;
        public virtual IEnumerable<AdviseCommentDTO> AdviseCommentsQuery { get; set; }
        public virtual List<AdviseCommentDTO> AdviseComments
        {
            get
            {
                if (_adviseComments == null && AdviseCommentsQuery != null)
                    _adviseComments = AdviseCommentsQuery.ToList();
                return _adviseComments;
            }
            set
            {
                AdviseCommentsQuery = _adviseComments = value;
            }
        }
    }
}