using Frontend;
using Frontend.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SharpCRUD.Communication;
using SharpCRUD.Communication.Http;

namespace Frontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSharpCRUDCommunication();
            builder.Services.AddSharpCRUDHttpRepositories<SharpCRUDConfigurationProvider>();

            await builder.Build().RunAsync();
        }
    }
}