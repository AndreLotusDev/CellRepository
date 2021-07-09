using CellRepository.Domain.Entities;
using CellRepository.Infra.DataAcess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CellRepository.Infra.DataAcess.Context
{
    public class CellRepositoryContext : DbContext , IContext 
    {
        public CellRepositoryContext(DbContextOptions<CellRepositoryContext> options) : base(options)
        {
            
        }

        public CellRepositoryContext(DbContextOptionsBuilder<CellRepositoryContext> options) 
        {
            options.UseNpgsql();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SmartphoneEntity>().ToTable("Smartphones");
                
            builder.Entity<SmartphoneEntity>().Property(m => m.Name).IsRequired();
        }
    }
}
