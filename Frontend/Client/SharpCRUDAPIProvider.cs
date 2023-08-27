using SharpCRUD.Communication.Http.Tools;

namespace Frontend.Client
{
    public class SharpCRUDConfigurationProvider : ISharpCRUDConfigurationService
    {
        public async Task<string> GetBaseAPIUrl()
        {
            return await Task.FromResult("https://localhost:7081/");
        }
    }
}
