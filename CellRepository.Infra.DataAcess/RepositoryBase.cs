using CellRepository.Infra.DataAcess.Context;
using CellRepository.Infra.DataAcess.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Infra.DataAcess
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly CellRepositoryContext Db = new();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public IEnumerable<TEntity> GetAllNoCache()
        {
            return Db.Set<TEntity>().AsNoTracking().ToList();
        }

        public async Task AddAsync(TEntity obj)
        {
            await Db.Set<TEntity>().AddAsync(obj);
            await Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Db.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllNoCacheAsync()
        {
            return await Db.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            await Db.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            await Db.SaveChangesAsync();
        }

        public async Task DisposeAsync()
        {
            await Db.DisposeAsync();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            
        }
    }
}
