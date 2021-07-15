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
        Task<(string message, bool status)> RegisterANewUserAsync(UserLoginDto userToRegister);
    }
}
