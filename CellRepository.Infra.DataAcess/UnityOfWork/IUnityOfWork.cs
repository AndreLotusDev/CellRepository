using CellRepository.Domain.Entities;
using CellRepository.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace CellRepository.Infra.DataAcess.UnityOfWork
{
    public interface IUnityOfWork
    {
        ISmartphoneRepository SmartphoneRepository { get; }

        void Commit();
        Task CommitAsync();
    }
}
