using System;
using System.Collections.Generic;

namespace CCPSAPPS.Models
{
    public partial class SalleDeClass
    {
        public int SalleDeclasseId { get; set; }
        public string NomDuSalle { get; set; } = null!;
        public string? SalleDescription { get; set; }
        public int? NombreDePersonne { get; set; }
    }
}
