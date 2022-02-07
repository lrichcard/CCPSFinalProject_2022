using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CCPSAPPS.Models
{
    public partial class EtudiantsCourant
    {
        [Key]
        public int EtudiantsCourantsId { get; set; }
        public int PersonneId { get; set; }
        public int SessionId { get; set; }
        public string CreeParUsername { get; set; } = null!;
        public DateTime DateCreee { get; set; }
      
        public int Admis { get; set; }
        public string? AdmisPar { get; set; }
        public int LockEdit { get; set; }
        public DateTime DateAdmis { get; set; }
    }
}
