using CellRepository.Domain.Interfaces.Repositories;
using CellRepository.Infra.DataAcess.Areas;
using CellRepository.Infra.DataAcess.Areas.User;
using CellRepository.Infra.DataAcess.Context;
using CellRepository.Infra.DataAcess.Interfaces;
using CellRepository.Infra.DataAcess.Interfaces.Repositories.User;
using System;
using System.Threading.Tasks;

namespace CellRepository.Infra.DataAcess.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly CellRepositoryContext _db = null;
        private ISmartphoneRepository smartphoneRepository = null;
        private IUserLoginRepository userRepository = null;

        public UnityOfWork(IContext db)
        {
            _db = (CellRepositoryContext)db;
        }

        #region Tables
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

        public IUserLoginRepository UserLoginRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserLoginRepository(_db);
                }
                return userRepository;
            }
        }
        #endregion

        #region Functions
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
        #endregion
    }

}
