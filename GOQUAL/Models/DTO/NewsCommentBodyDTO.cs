using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Models.DTO
{
    public class NewsCommentBodyDTO
    {
        public List<NewsCommentDTO> Comments { get; set; }
        public int TotalCount { get; set; }
    }
}