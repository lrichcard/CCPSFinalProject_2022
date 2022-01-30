using CCPSAPPS.Models;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
namespace CCPSAPPS.Data
{
    public class ApplicationDbContext : DbContext
    {
       
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        public DbSet<HeuresDeClasses> HeureDeClasses { get; set; }
        public DbSet<JoursDeClass> JoursDeClasses { get; set; }
        public DbSet<SalleDeClass> SalleDeClasses { get; set; }
        public object JourDeClass { get; internal set; }
        public object SalleDeClass { get; internal set; }

    }
}