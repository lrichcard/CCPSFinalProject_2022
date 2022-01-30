using System.ComponentModel.DataAnnotations;


namespace CCPSAPPS.Models
{
    public partial class SalleDeClass
    {
        [Key]
        public int? SalleDeclasseID { get; set; } = 2;

        public string Nom_du_salle { get; set; }
        public string? SalleDescription { get; set; }
        public int? Nombre_de_Personne { get; set; }
    }
}
