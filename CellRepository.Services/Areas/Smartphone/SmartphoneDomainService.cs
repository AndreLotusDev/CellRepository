using CellRepository.Domain.Entities;
using CellRepository.DomainServices;
using CellRepository.Infra.AwsService.Amazon;
using CellRepository.Infra.DataAcess.UnityOfWork;
using CellRepository.Services.Areas.Smartphone;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellRepository.Services.Areas.User
{
    public class SmartphoneDomainService : DomainServiceBase<SmartphoneEntity> ,ISmartphoneDomainService
    {
        public ICloudImgService ServiceCloud { get; }

        public SmartphoneDomainService(IUnityOfWork uof, ICloudImgService serviceCloud): base(uof)
        {
            ServiceCloud = serviceCloud;
        }

        public async Task<IReadOnlyList<SmartphoneEntity>> GetTop100Smartphones()
        {
            var listOfSmartphonesModels = await UOF.SmartphoneRepository.GetAllAsync();

            return listOfSmartphonesModels.ToList().AsReadOnly();
        }

        public async Task<(string message, bool status)> RegisterANewSmartphoneAsync(SmartphoneEntity model, byte[] imgBytes = null)
        {
            //Validation of the model
            model.UpdateDateUpdate(); //I'm updating the date of the update (when the model is new or not)

            if (!model.Validate())
            {
                return ($"U need to validate {model.GetFirstValidationMessage()}",false);
            }

            if (model.Id == 0)
                model.UpdateDateOfCreation();

            var existOneModel = await UOF.SmartphoneRepository.GetAsync(m => m.SmartphoneName.ToUpper() == model.SmartphoneName.ToUpper());

            if (existOneModel != null)
            { 
                AddMessage(nameof(SmartphoneEntity.SmartphoneName), "Already exists");
                return ("Already exists a smartphone with this name in the database", false);
            }

            try
            {
                const bool IS_OKAY = true;

                //if(ServiceCloud is not null)
                //{
                //    (string message, bool status, string idImage) = await ServiceCloud.PerformASave(imgBytes);

                //    if (status == IS_OKAY)
                //        model.SetIdImage(idImage);
                //}

                await UOF.SmartphoneRepository.AddAsync(model);

                await UOF.CommitAsync();
            }
            catch (Exception ex)
            {
                return (ex.Message, false);
            }
            finally
            {
                UOF.Dispose(); 
            }

            return ("Created with success", true);
        }
    }
}
