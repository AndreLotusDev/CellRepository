using CellRepository.Domain.Entities;
using CellRepository.Domain.Enum;
using CellRepository.Infra.DataAcess.EntityConfig.Areas;
using CellRepository.Infra.DataAcess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CellRepository.Infra.DataAcess.Context
{
    public class CellRepositoryContext : DbContext , IContext 
    {
        public CellRepositoryContext()
        {
                
        }

        public CellRepositoryContext(DbContextOptions<CellRepositoryContext> options) : base(options)
        {
            
        }

        public CellRepositoryContext(DbContextOptionsBuilder<CellRepositoryContext> options) 
        {
            options.UseNpgsql();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigSmartphoneEntity.Config(modelBuilder);
            ConfigUserLoginEntity.Config(modelBuilder);

            modelBuilder.HasPostgresEnum<ERoles>();
        }
    }
}
