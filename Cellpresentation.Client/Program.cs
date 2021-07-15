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

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
