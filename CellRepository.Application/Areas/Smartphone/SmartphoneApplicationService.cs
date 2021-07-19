using AutoMapper;
using CellRepository.ApplicationModels;
using CellRepository.Domain.Entities;
using CellRepository.Services.Areas.Smartphone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.ApplicationService.Areas.Smartphone
{
    public class SmartphoneApplicationService : ISmartphoneApplicationService
    {
        private readonly ISmartphoneDomainService _smartphoneDS;
        private readonly IMapper _mapper;
        public SmartphoneApplicationService(ISmartphoneDomainService smartphoneDS, IMapper mapper)
        {
            _smartphoneDS = smartphoneDS;
            _mapper = mapper;
        }

        /// <summary>
        /// Register a new smartphone
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Returns a message and a update state</returns>
        public async Task<(string message, bool status)> RegisterANewSmartphoneAsync(SmartphoneDto model)
        {
            return await _smartphoneDS.RegisterANewSmartphoneAsync(_mapper.Map<SmartphoneEntity>(model));
        }

        public async Task<IReadOnlyList<SmartphoneEntity>> Get100SmartphonesAsync()
        {
            return await _smartphoneDS.GetTop100Smartphones();
        }
    }
}
