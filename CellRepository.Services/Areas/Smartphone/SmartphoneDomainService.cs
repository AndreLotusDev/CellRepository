using CellRepository.DomainServices;
using System.Threading.Tasks;
using CellRepository.Domain.Entities;
using CellRepository.Infra.DataAcess.UnityOfWork;

namespace CellRepository.Services.Areas.Smartphone
{
    public class SmartphoneDomainService : DomainServiceBase<SmartphoneEntity> ,ISmartphoneDomainService
    {
        public SmartphoneDomainService(UnityOfWork uof): base(uof){}

        public async Task<bool> RegisterANewSmartphone(SmartphoneEntity model)
        {
            //Validation of the model

            if (!model.IsOkay())
                return false;

            UOF.SmartphoneRepository.
        }
    }
}
