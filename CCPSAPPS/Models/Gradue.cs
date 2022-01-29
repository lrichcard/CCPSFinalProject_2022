using System;
using System.Collections.Generic;

namespace CCPSAPPS.Models
{
    public partial class Gradue
    {
        public int GradueId { get; set; }
        public int PersonneId { get; set; }
        public DateTime DateGraduation { get; set; }
        public int NbreDiplomeImpreme { get; set; }
        public DateTime DateImprime { get; set; }
        public string? Sujet { get; set; }
    }
}
