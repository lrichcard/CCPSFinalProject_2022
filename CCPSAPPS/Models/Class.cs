using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CCPSAPPS.Models
{
    public partial class Class
    {
        [Key]
        public int ClasseId { get; set; }
        public string NomClasse { get; set; } = null!;
        public string? Description { get; set; }
        public int NiveauClasse { get; set; }
        public string Categorie { get; set; } = null!;
    }
}
