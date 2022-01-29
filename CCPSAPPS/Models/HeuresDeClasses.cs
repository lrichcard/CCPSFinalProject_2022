namespace CCPSAPPS.Data;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using System.ComponentModel.DataAnnotations;


    public class HeuresDeClasses
{
     [Key]
    public int HeureID { get; set; }
         public string? HeureDescription { get; set; }

        public string? Categorie { get; set; }

}
