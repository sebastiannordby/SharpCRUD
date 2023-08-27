using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Communication.Http.Tools
{
    public interface ISharpCRUDHttpClientService
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage);
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpClient> GetHttpClient();
    }

    internal class SharpCRUDHttpClientService : ISharpCRUDHttpClientService
    {
        private HttpClient _httpClient;
        protected readonly ISharpCRUDConfigurationService _cmdConfigurationService;

        public SharpCRUDHttpClientService(
            ISharpCRUDConfigurationService cmdConfigurationService)
        {
            _cmdConfigurationService = cmdConfigurationService;
        }

        public async Task<HttpClient> GetHttpClient()
        {
            if (_httpClient != null && _httpClient.BaseAddress != null)
                return _httpClient;

            var baseUri = await _cmdConfigurationService.GetBaseAPIUrl();
            if (string.IsNullOrWhiteSpace(baseUri))
                throw new ArgumentException($"Method {nameof(GetHttpClient)}: Parameter baseUri is null or empty");

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUri);
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "nb-NO");

            return _httpClient;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await (await GetHttpClient()).GetAsync(url);
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            return await (await GetHttpClient()).SendAsync(httpRequestMessage);
        }
    }
}
