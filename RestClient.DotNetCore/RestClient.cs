using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestClient.DotNetCore
{
    public class RestClient
    {
        private HttpClient Client { get; }
        public RestClient(HttpClient client)
        {
            Client = client;
        }

        public async Task<HttpResponseMessage> Request(HttpMethod method, string url, string body, IEnumerable<KeyValuePair<string, string>> headers, int retries)
        {
            return null;
        }
    }
}
