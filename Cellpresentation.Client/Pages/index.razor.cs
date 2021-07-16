using Cellpresentation.Client.Services;
using CellRepository.ApplicationModels;
using CellRepository.ApplicationService;
using CellRepository.Shared;
using CellRepository.Shared.Functions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cellpresentation.Client.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        private HttpClient Client { get; set; }

        [Inject]
        private ConfigJson configJson { get; set; }

        protected string messagesToDisplays { get; set; }

        protected UserLoginDto userDto = new();

        protected async Task RegisterUserAsync()
        {
            UserApi userApi = new(Client);

            var response = await userApi.RegisterANewUserAsync(userDto);

            messagesToDisplays = response.GetFirstComment();
        }
    }
}
