using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Models.DTO
{
    public class CommentBodyDTO
    {
        public List<CommentDTO> Comments { get; set; }
        public int TotalCount { get; set; }
    }
}