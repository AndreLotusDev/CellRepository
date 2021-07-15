using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Infra.DataAcess.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllNoCache();

        void Update(TEntity obj);
        void Remove(TEntity obj);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAllWith(Expression<Func<TEntity, bool>> predicate);

        void Dispose();

        #region Async Methods
        Task AddAsync(TEntity obj);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllNoCacheAsync();

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllWithAsync(Expression<Func<TEntity, bool>> predicate);

        Task DisposeAsync();
        #endregion
    }
}
