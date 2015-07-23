using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Models.DTO
{
    public class AdviseCommentBodyDTO
    {
        public List<AdviseCommentDTO> Comments { get; set; }
        public int TotalCount { get; set; }
    }
}