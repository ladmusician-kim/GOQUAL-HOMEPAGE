using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Models.DTO
{
    public class LunchDTO
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Address { get; set; }
        public int Hit { get; set; }
    }
}