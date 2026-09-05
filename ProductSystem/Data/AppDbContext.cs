using Microsoft.EntityFrameworkCore;
using ProductSystem.Models;
namespace ProductSystem.Data
{
    public class AppDbContext : DbContext
    {

        //Passa as Configurações do AppDbContext para o construtor de DbContext(ponte de acesso do banco)
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        //DbSet Representa a tabela do banco
        public DbSet<Product> Products { get; set; }
    }
}
