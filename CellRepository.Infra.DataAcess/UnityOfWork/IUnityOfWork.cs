using CellRepository.Domain.Entities;
using CellRepository.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace CellRepository.Infra.DataAcess.UnityOfWork
{
    public interface IUnityOfWork : IDisposable
    {
        ISmartphoneRepository SmartphoneRepository { get; }

        void Commit();
        Task CommitAsync();

    }
}
