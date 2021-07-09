using CellRepository.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CellRepository.Infra.DataAcess.Context
{
    public class CellRepositoryContext : DbContext
    {
        public CellRepositoryContext() : base() 
        { 
        
        }

        public CellRepositoryContext(DbContextOptions<CellRepositoryContext> options) : base(options)
        {
            
        }

        public CellRepositoryContext(DbContextOptionsBuilder<CellRepositoryContext> options) 
        {
            options.UseNpgsql();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SmartphoneEntity>().Property(m => m.Name).IsRequired();
                
        }
    }
}
