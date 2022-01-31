using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CCPSAPPS.Models
{
    public partial class DatesSessionCourante
    {   [Key]
        public int SessionDateId { get; set; }
        public DateTime SessionDateDebut { get; set; }
        public DateTime SessionDateFin { get; set; }
        public string? Remarque { get; set; }
        public int Actif { get; set; }
    }
}
