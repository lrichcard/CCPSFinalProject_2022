using System;
using System.Collections.Generic;

namespace CCPSAPPS.Models
{
    public partial class MinisteresDetail
    {
        public int MinistereDetailId { get; set; }
        public string NomMinistere { get; set; } = null!;
        public int MinistereId { get; set; }
    }
}
