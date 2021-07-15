using CellRepository.ApplicationModels;
using CellRepository.ApplicationService;
using CellRepository.ApplicationService.Areas.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SmartphoneApi.Controllers.Areas
{
    [Route("Areas/User")]
    public class UserController : Controller
    {
        private readonly IUserApplicationService _userService;
        public UserController(IUserApplicationService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="user">information who be stored in the server</param>
        /// <returns></returns>
        [HttpPost, Route("RegisterANewUserAsync")]
        public async Task<IActionResult> RegisterANewUserAsync([FromBody]UserLoginDto user)
        {
            ApiModel<string> modelToReturn = new();

            if (user == null)
                return BadRequest(modelToReturn);

            try
            {
                var addUserServiceResponse = await _userService.RegisterANewUserAsync(user);

                if (addUserServiceResponse.status)
                {
                    modelToReturn.StatusCode = EStatusCode.Ok;
                    modelToReturn.SetData(addUserServiceResponse.message);
                    modelToReturn.AddComment(addUserServiceResponse.message);
                }
                else
                {
                    modelToReturn.StatusCode = EStatusCode.ImATeaPot;
                    modelToReturn.SetData(addUserServiceResponse.message);
                    modelToReturn.AddComment(addUserServiceResponse.message);
                }

                return Ok(modelToReturn);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }          
        }
    }
}
