using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CCPSAPPS.Models
{
    public partial class Parametre
    {
        [Key]
        public int? Id { get; set; } 
        public string Taux { get; set; } = null!;
        public int NombreEtudiantsParClasse { get; set; }
        public decimal MontantFrais { get; set; }
        public string? Parametre17 { get; set; } =null!;
        public string? Parametre16 { get; set; } = null!;
        public string? Parametre15 { get; set; } = null!;
        public string? Parametre14 { get; set; } = null!;
        public string? Parametre13 { get; set; } = null!;
        public string? Parametre12 { get; set; } = null!;
        public string? Parametre11 { get; set; } = null!;
        public string? Parametre1 { get; set; } = null!;
    }
}
