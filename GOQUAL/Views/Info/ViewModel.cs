using GOQUAL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Views.Info
{
    public class IndexViewModel
    {
        public int Lang { get; set; }
        public List<BlogDTO> Blogs { get; set; }
    }

    public class DetailViewModel
    {
        public int Lang { get; set; }
        public int Id { get; set; }
    }
}