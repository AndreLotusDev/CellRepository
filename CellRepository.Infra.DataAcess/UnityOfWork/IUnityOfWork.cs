using CellRepository.Domain.Entities;
using CellRepository.Domain.Interfaces.Repositories;
using CellRepository.Infra.DataAcess.Interfaces.Repositories.User;
using System;
using System.Threading.Tasks;

namespace CellRepository.Infra.DataAcess.UnityOfWork
{
    public interface IUnityOfWork : IDisposable
    {
        ISmartphoneRepository SmartphoneRepository { get; }
        IUserLoginRepository UserLoginRepository { get; }

        void Commit();
        Task CommitAsync();

    }
}
