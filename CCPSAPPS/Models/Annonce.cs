﻿using System;
using System.Collections.Generic;

namespace CCPSAPPS.Models
{
    public partial class Annonce
    {
        public int AnnonceId { get; set; }
        public string Annonce1 { get; set; } = null!;
        public DateTime DateCreee { get; set; }
        public int Actif { get; set; }
    }
}
