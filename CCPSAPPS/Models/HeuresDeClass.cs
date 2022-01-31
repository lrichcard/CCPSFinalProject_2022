using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CCPSAPPS.Models
{
    public partial class HeuresDeClass
    {
        [Key]
        public int HeureID { get; set; }
        public string HeureDescription { get; set; } = null!;
        public string? Categorie { get; set; }
    }
}
