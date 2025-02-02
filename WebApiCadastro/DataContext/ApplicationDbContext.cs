using Microsoft.EntityFrameworkCore;
using WebApiCadastro.Models;

namespace WebApiCadastro.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) { 
        
        }

        public DbSet<UsuarioModel> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioModel>()
                .Property(u => u.Departamento)
                .HasConversion<string>();

            modelBuilder.Entity<UsuarioModel>()
                .Property(u => u.TipoTrabalho)
                .HasConversion<string>();
        }
    }
}
