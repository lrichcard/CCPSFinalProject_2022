using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CCPSAPPS.Models
{

    public partial class JoursDeClass
    {
        [Key]
        public int JourId { get; set; }
        
        //[DisplayName("")]
        public string JourDescription { get; set; } = null!;
    }
}
 