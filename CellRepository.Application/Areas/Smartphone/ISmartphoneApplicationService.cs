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
        Task<(string message, bool status)> RegisterANewSmartphoneAsync(SmartphoneEntity model);

        Task<IReadOnlyList<SmartphoneEntity>> Get100SmartphonesAsync();
    }
}
