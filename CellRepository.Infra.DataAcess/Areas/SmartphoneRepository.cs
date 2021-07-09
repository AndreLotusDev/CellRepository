using CellRepository.Domain.Entities;
using CellRepository.Domain.Interfaces.Repositories;
using CellRepository.Infra.DataAcess.Context;
using CellRepository.Infra.DataAcess.Interfaces;

namespace CellRepository.Infra.DataAcess.Areas
{
    public class SmartphoneRepository : RepositoryBase<SmartphoneEntity>, ISmartphoneRepository
    {
        public SmartphoneRepository(IContext db) : base(db)
        {

        }
    }
}
