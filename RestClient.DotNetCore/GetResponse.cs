using System.Net;

namespace RestClient.DotNetCore
{
    public class GetResponse : IRequestResponse
    {
        public string Content { get; }
        public HttpStatusCode StatusCode { get; }
        public GetResponse(HttpStatusCode statusCode, string content)
        {
            Content = content;
            StatusCode = statusCode;
        }
    }
}
