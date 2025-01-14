using Microsoft.EntityFrameworkCore;

namespace CadastroIEL.Infrastructure.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cadastro> Products { get; set; }

    }
}

