using CellRepository.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cellpresentation.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var baseAddress = builder.Configuration.GetValue<string>("BaseUrl");
            var encryptKey = builder.Configuration.GetValue<string>("PasswordKey");

            ConfigJson configJson = new(encryptKey);

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
            builder.Services.AddSingleton(configJson);

            await builder.Build().RunAsync();
        }
    }
}
