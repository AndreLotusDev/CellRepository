using CellRepository.Domain.Entities;
using CellRepository.DomainServices;
using CellRepository.Infra.DataAcess.UnityOfWork;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellRepository.Services.Areas.Smartphone
{
    public class SmartphoneDomainService : DomainServiceBase<SmartphoneEntity> ,ISmartphoneDomainService
    {
        public SmartphoneDomainService(IUnityOfWork uof): base(uof){}

        public async Task<IReadOnlyList<SmartphoneEntity>> GetTop100Smartphones()
        {
            var listOfSmartphonesModels = await UOF.SmartphoneRepository.GetAllAsync();

            return listOfSmartphonesModels.ToList().AsReadOnly();
        }

        public async Task<(string message, bool status)> RegisterANewSmartphoneAsync(SmartphoneEntity model)
        {
            //Validation of the model

            if (!model.IsOkay())
            {
                return ($"U need to validate {model.GetFirstValidationMessage()}",false);
            }

            var existOneModel = await UOF.SmartphoneRepository.GetAsync(m => m.SmartphoneName.ToUpper() == model.SmartphoneName.ToUpper());

            if (!(existOneModel is null))
            { 
                AddMessage(nameof(SmartphoneEntity.SmartphoneName), "Already exists");
                return ("Already exists a smartphone with this name in the database", false);
            }

            try
            {
                await UOF.SmartphoneRepository.AddAsync(model);

                await UOF.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                UOF.Dispose(); 
            }

            return ("Updated with success", true);
        }
    }
}
