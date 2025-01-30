using Microsoft.EntityFrameworkCore;
using WebApiCadastro.Models;

namespace WebApiCadastro.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) { 
        
        }

        public DbSet<UsuarioModel> Usuario { get; set; }
    }
}
