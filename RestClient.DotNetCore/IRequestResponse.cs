using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RestClient.DotNetCore
{
    public interface IRequestResponse
    {
        HttpStatusCode StatusCode { get; }
        string Content { get; }
    }
}
