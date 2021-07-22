using CellRepository.ApplicationModels;
using CellRepository.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.ApplicationService.Areas.Smartphone
{
    public interface ISmartphoneApplicationService
    {
        Task<(string message, bool status)> RegisterANewSmartphoneAsync(SmartphoneDto model, byte[] imgBytes);

        Task<IReadOnlyList<SmartphoneEntity>> Get100SmartphonesAsync();
    }
}
