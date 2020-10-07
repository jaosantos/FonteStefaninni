using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{
    public class ConfigureModelsDbContext : DbContext
    {
        public ConfigureModelsDbContext(DbContextOptions<ConfigureModelsDbContext> options) : base(options)
        {

        }

        public DbSet<Genero> Genero { get; set; }

        public DbSet<Filme> Filme { get; set; }
    }
}
