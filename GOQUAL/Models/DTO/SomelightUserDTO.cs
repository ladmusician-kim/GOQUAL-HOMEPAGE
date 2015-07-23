using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOQUAL.Models.DTO
{
    public class SomelightUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string regId { get; set; }
        public string phone { get; set; }
        public string PartnerName { get; set; }
        public string partnerPhone { get; set; }
        public int EmoticonCount { get; set; }
        public int InviteCount { get; set; }
    }
}