using System;
using System.Collections.Generic;

namespace CCPSAPPS.Models
{
    public partial class HeuresDeClass
    {
        public int HeureId { get; set; }
        public string HeureDescription { get; set; } = null!;
        public string? Categorie { get; set; }
    }
}
