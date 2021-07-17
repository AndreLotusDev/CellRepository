using CellRepository.ApplicationModels;
using CellRepository.ApplicationService;
using CellRepository.ApplicationService.Areas.User;
using CellRepository.Shared;
using CellRepository.Shared.Functions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartphoneApi.Service;
using System.Threading.Tasks;

namespace SmartphoneApi.Controllers.Areas
{
    [Route("Areas/User")]
    public class UserController : Controller
    {
        private readonly IUserApplicationService _userService;
        private readonly ConfigJson _configJson;
        public UserController(IUserApplicationService userService, ConfigJson configJson)
        {
            _userService = userService;
            _configJson = configJson;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="user">information who be stored in the server</param>
        /// <returns></returns>
        [HttpPost, Route("RegisterANewUserAsync")]
        public async Task<IActionResult> RegisterANewUserAsync([FromBody]UserLoginDto user)
        {
            user.Password = Sha256.Encrypt(user.Password, _configJson.EncriptString);

            ApiModel<string> modelToReturn = new();

            if (user == null)
                return BadRequest(modelToReturn);

            try
            {
                var addUserServiceResponse = await _userService.RegisterANewUserAsync(user);

                if (addUserServiceResponse.status)
                {
                    modelToReturn.StatusCode = EStatusCode.Ok;
                    modelToReturn.IsOk = true;
                    modelToReturn.SetData(addUserServiceResponse.message);
                    modelToReturn.AddComment(addUserServiceResponse.message);
                }
                else
                {
                    modelToReturn.StatusCode = EStatusCode.ImATeaPot;
                    modelToReturn.IsOk = true;
                    modelToReturn.SetData(addUserServiceResponse.message);
                    modelToReturn.AddComment(addUserServiceResponse.message);
                }

                return Json(modelToReturn);
            }
            catch (System.Exception e)
            {
                return Json(e.Message);
            }          
        }

        [HttpPost, Route("Login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserLoginDto user)
        {
            user.Password = Sha256.Encrypt(user.Password, _configJson.EncriptString);
            var hasUser = await _userService.LoginAsync(user);

            if (hasUser == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService(_configJson).GenerateToken(hasUser);

            hasUser.Password = "";

            Response.StatusCode = 200; //OK
            return new
            {
                user = hasUser,
                token = token
            };
        }

        [HttpPost, Route("AuthenticationTest"), Authorize]
        public IActionResult AuthenticationTest()
        {
            return Json("Its fine");
        }
    }
}
