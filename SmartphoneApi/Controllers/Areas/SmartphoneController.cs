using CellRepository.ApplicationService;
using CellRepository.ApplicationService.Areas.Smartphone;
using CellRepository.Domain.Entities;
using CellRepository.Shared.Enums;
using EnumsNET;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartphoneApi.Controllers.Areas
{
    [Route("Areas/Smartphone")]
    public class SmartphoneController : Controller
    {
        private readonly ISmartphoneApplicationService _smartphoneS;
        public SmartphoneController(ISmartphoneApplicationService smart)
        {
            _smartphoneS = smart;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterANewsSmartphoneAsync(SmartphoneEntity model)
        {
            var result = await _smartphoneS.RegisterANewSmartphoneAsync(model);

            var message = result.message;
            var updateWithSuccess = result.status;

            ApiModel<bool> apiModel = new();

            if (updateWithSuccess)
            {
                apiModel.StatusCode = EStatusCode.Ok;
                apiModel.SetData(updateWithSuccess);
                apiModel.AddComment("Smartphone updated succefully");

                return Ok(apiModel);
            }

            apiModel.StatusCode = EStatusCode.NOk;
            apiModel.SetData(updateWithSuccess);
            apiModel.AddComment(message);

            return BadRequest();
        }

        /// <summary>
        /// Get the first hundred smartphones
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("/GetSmartphones")]
        public async Task<IActionResult> Get100SmartphonesAsync()
        {
            var result = await _smartphoneS.Get100SmartphonesAsync();

            ApiModel<IReadOnlyList<SmartphoneEntity>> apiModel = new();

            if (result is null)
            {
                apiModel.SetData(result);
                apiModel.StatusCode = EStatusCode.NOk;
                apiModel.AddComment((EMessageValidations.NoDbData).AsString(EnumFormat.Description));

                return BadRequest(apiModel);
            }

            apiModel.SetData(result);
            apiModel.StatusCode = EStatusCode.Ok;

            return Ok(apiModel);
        }
    }
}
