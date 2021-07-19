using CellRepository.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.ApplicationService.Areas.User
{
    public interface IUserApplicationService
    {
        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="userToRegister"></param>
        /// <returns>returns the message of the operation, the status, if okay it's true</returns>
        Task<(string message, bool status)> RegisterANewUserAsync(UserLoginDto userToRegister);

        /// <summary>
        /// Try to peek a user
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns>return the info of the user, the message and the status</returns>
        Task<(UserLoginDto user, string message, bool status)> LoginAsync(UserLoginDto userLoginDto);
    }
}
