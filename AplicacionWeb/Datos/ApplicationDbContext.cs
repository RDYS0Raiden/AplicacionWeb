using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using AplicacionWeb.Modelos;
namespace AplicacionWeb.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        //Colocar aqui los modelos 
        public DbSet<Categoria> Categoria { get; set; }

    }

}
