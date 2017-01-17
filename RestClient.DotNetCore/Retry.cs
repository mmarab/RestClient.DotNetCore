using System;
using System.Collections.Generic;
using System.Text;

namespace RestClient.DotNetCore
{
    public class Retry
    {
        public bool RetryRequest(int retries)
        {
            for (int i = 0; i < retries; i++)
            {
                var response = 1+1; //request
            }

            return true;
        }
    }
}
