using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.DotNetCore
{
    public class Retry
    {
        public async Task<HttpResponseMessage> RetryRequest(int retries, Func<string, Task<HttpResponseMessage>> request, string url)
        {
            HttpResponseMessage response = null;

            for (int i = 0; i < retries; i++)
            {
                response = await request(url);
                if (response.IsSuccessStatusCode)
                    return response;
            }

            return response;
        }
    }
}
