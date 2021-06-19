using Microsoft.EntityFrameworkCore;
using Spedy.Desafio.API.Infrastructure.Data.Mappings;
using Spedy.Desafio.API.Models.Entities;

namespace Spedy.Desafio.API.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Classified> Classifieds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClassifiedMap());
        }
    }
}
