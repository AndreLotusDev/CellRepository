using CellRepository.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Services.Areas.Smartphone
{
    public interface ISmartphoneDomainService : IDomainServiceBase<Smartphone>
    {
        Task<bool> RegisterANewSmartphone();

    }
}
