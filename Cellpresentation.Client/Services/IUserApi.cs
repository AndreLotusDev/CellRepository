using CellRepository.ApplicationModels;
using CellRepository.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellpresentation.Client.Services
{
    public interface IUserApi
    {
        Task<ApiModel<string>> RegisterANewUserAsync(UserLoginDto user);
    }
}
