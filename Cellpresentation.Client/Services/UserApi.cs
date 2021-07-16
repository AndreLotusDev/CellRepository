using CellRepository.ApplicationModels;
using CellRepository.ApplicationService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cellpresentation.Client.Services
{
    public class UserApi : IUserApi
    {
        private readonly HttpClient _client;

        public UserApi(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiModel<string>> RegisterANewUserAsync(UserLoginDto user)
        {
            var response = await _client.PostAsJsonAsync("Areas/User/RegisterANewUserAsync", user);

            var resultOfResponse = await response.Content.ReadAsStringAsync();

            ApiModel<string> responseStatusOfUserCreated = new();

            await Task.Run(() =>
            {
                responseStatusOfUserCreated = JsonConvert.DeserializeObject<ApiModel<string>>(resultOfResponse);
            });

            Task.WaitAll();

            return responseStatusOfUserCreated;
        }
    }
}
