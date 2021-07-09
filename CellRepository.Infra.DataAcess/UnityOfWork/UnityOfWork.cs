using CellRepository.Domain.Interfaces.Repositories;
using CellRepository.Infra.DataAcess.Areas;
using CellRepository.Infra.DataAcess.Context;
using CellRepository.Infra.DataAcess.Interfaces;
using System;
using System.Threading.Tasks;

namespace CellRepository.Infra.DataAcess.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private readonly CellRepositoryContext _db = null;
        private ISmartphoneRepository smartphoneRepository = null;

        public UnityOfWork(IContext db)
        {
            _db = (CellRepositoryContext)db;
        }

        public ISmartphoneRepository SmartphoneRepository
        {
            get 
            {
                if (smartphoneRepository == null)
                {
                    smartphoneRepository = new SmartphoneRepository(_db);
                }
                return smartphoneRepository;
            }
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }

}
