using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Models.DTO
{
    public class AdviseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool IsDeprecated { get; set; }
        public int? Hit { get; set; }

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
    }
}