using CellRepository.Domain.Interfaces.Repositories;
using CellRepository.Infra.DataAcess.Areas;
using CellRepository.Infra.DataAcess.Context;
using System;
using System.Threading.Tasks;

namespace CellRepository.Infra.DataAcess.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private readonly CellRepositoryContext db = null;
        private ISmartphoneRepository smartphoneRepository = null;

        public UnityOfWork()
        {
            db = new CellRepositoryContext();
        }

        public ISmartphoneRepository SmartphoneRepository
        {
            get 
            {
                if (smartphoneRepository == null)
                {
                    smartphoneRepository = new SmartphoneRepository();
                }
                return smartphoneRepository;
            }
        }

        public void Commit()
        {
            db.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }

}
