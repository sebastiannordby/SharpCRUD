using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SharpCRUD.Communication.Http.Tools
{
    public interface ISharpCRUDHttpClientTask
    {
        Task<T> Get<T>(string url) where T : class;
        Task<T> Post<T>(string url, object bodyContent = null);
        Task<T> Delete<T>(string url, object bodyContent = null);
    }

    internal class SharpCRUDHttpClientTask : ISharpCRUDHttpClientTask
    {
        private readonly ISharpCRUDHttpClientService _httpClientService;

        public SharpCRUDHttpClientTask(
            ISharpCRUDHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<T> Post<T>(string url, object bodyContent = null)
        {
            var serializedBody = AsJsonSerialized(bodyContent);
            var requestMessage = await PrepareRequestMessage(
                new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = AsJsonBodyContent(serializedBody)
                });

            var response = await GetRequestResponse(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var respContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<T>(respContent);

                return responseObject;
            }

            return default(T);
        }


        public async Task<T> Delete<T>(string url, object bodyContent = null)
        {
            var serializedBody = AsJsonSerialized(bodyContent);
            var requestMessage = await PrepareRequestMessage(
                new HttpRequestMessage(HttpMethod.Delete, url)
                {
                    Content = AsJsonBodyContent(serializedBody)
                });

            var response = await GetRequestResponse(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var respContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<T>(respContent);

                return responseObject;
            }

            return default(T);
        }

        public async Task<T> Get<T>(string url)
            where T : class
        {
            var requestMessage = await PrepareRequestMessage(
                new HttpRequestMessage(HttpMethod.Get, url));

            var response = await GetRequestResponse(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var respContent = await response.Content.ReadAsStringAsync();
                if (typeof(T) == typeof(string))
                    return respContent as T;

                return JsonSerializer.Deserialize<T>(respContent);
            }
            else
            {
            }

            return default(T);
        }

        public async Task<string> PostJsonResult(string uri, object bodyContent)
        {
            var serializedBody = AsJsonSerialized(bodyContent);
            var content = AsJsonBodyContent(serializedBody);
            var requestMessage = await PrepareRequestMessage(new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = content
            });

            var responseMessage = await GetRequestResponse(requestMessage);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseStream = await responseMessage.Content.ReadAsStreamAsync();
                using (var streamReader = new StreamReader(responseStream))
                {
                    var jsonString = streamReader.ReadToEnd();

                    return jsonString;
                }
            }

            return null;
        }

        protected async Task<HttpRequestMessage> SetRequestHeaders(HttpRequestMessage request)
        {
            //TODO: Possible Authorization
            return request;
        }

        public async Task<HttpRequestMessage> PrepareRequestMessage(HttpRequestMessage message)
        {
            return await SetRequestHeaders(message);
        }

        public string AsJsonSerialized(object bodyContent)
        {
            return (bodyContent != null) ? JsonSerializer.Serialize(bodyContent) : string.Empty;
        }

        public HttpContent AsJsonBodyContent(string serializedBodyContent)
        {
            return !string.IsNullOrEmpty(serializedBodyContent) ? 
                new StringContent(serializedBodyContent, Encoding.UTF8, "application/json") : null;
        }

        protected Task<HttpResponseMessage> GetRequestResponse(HttpRequestMessage requestMessage)
        {
            return _httpClientService.SendAsync(requestMessage);
        }
    }
}
