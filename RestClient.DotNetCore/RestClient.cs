using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestClient.DotNetCore
{      
    public class RestClient
    {
        private HttpClient Client { get; }
        public RestClient(string baseAddress)
        {
            Client = new HttpClient()
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        public async Task<T> Execute<T>(HttpMethod method, string url, string body, IEnumerable<KeyValuePair<string, string>> headers)
        {
            var result = await Execute(method, url, body, headers);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result.Content);  
        }
              

        public async Task<IRequestResponse> Execute(HttpMethod method, string url, string body, IEnumerable<KeyValuePair<string, string>> headers)
        {
            AddHeadders(headers);
            switch (method)
            {
                case HttpMethod.Get:                    
                    return await GetRequest(url);
               // case HttpMethod.Delete:
               //     return await Client.DeleteAsync(url);
               //case HttpMethod.Post:
               //     return await Client.PostAsync(url, new StringContent(body));
               // case HttpMethod.Put:
               //     return await Client.PutAsync(url, new StringContent(body));
            }

            throw new Exception("Http Method Not Found");
        }

        private async Task<IRequestResponse> GetRequest(string url)
        {
            var response = await Client.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            return new GetResponse(response.StatusCode, content);
        }

        private void AddHeadders(IEnumerable<KeyValuePair<string, string>> headers)
        {
            if (headers == null || !headers.Any())
                return;
            foreach (var header in headers)
            {
                Client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }           
        }
    }
}
