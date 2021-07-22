using CellRepository.Domain.Entities;
using CellRepository.DomainServices;
using CellRepository.Infra.DataAcess.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Services.Areas.Smartphone
{
    public interface ISmartphoneDomainService : IDomainServiceBase<SmartphoneEntity>
    {
        Task<(string message, bool status)> RegisterANewSmartphoneAsync(SmartphoneEntity model, byte[] imgBytes = null);

        Task<IReadOnlyList<SmartphoneEntity>> GetTop100Smartphones();
    }
}
