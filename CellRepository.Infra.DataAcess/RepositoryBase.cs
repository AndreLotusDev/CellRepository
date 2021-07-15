using CellRepository.Infra.DataAcess.Context;
using CellRepository.Infra.DataAcess.Interfaces;
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
        private readonly CellRepositoryContext _db;

        public RepositoryBase(IContext db)
        {
            _db = (CellRepositoryContext)db;
        }

        public void Add(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
        }

        public void Remove(TEntity obj)
        {
            _db.Set<TEntity>().Remove(obj);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IEnumerable<TEntity> GetAllNoCache()
        {
            return _db.Set<TEntity>().AsNoTracking().ToList();
        }

        public async Task AddAsync(TEntity obj)
        {
            await _db.Set<TEntity>().AddAsync(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllNoCacheAsync()
        {
            return await _db.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task DisposeAsync()
        {
            await _db.DisposeAsync();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

        public IEnumerable<TEntity> GetAllWith(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllWithAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().Where(predicate).ToListAsync();
        }
    }
}
