using GOQUAL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Views.Home
{
    public class IndexViewModel
    {
        public int Lang { get; set; }
        public List<BlogDTO> Blogs { get; set; }
    }
}