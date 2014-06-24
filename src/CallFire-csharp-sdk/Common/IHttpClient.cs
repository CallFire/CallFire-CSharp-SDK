using System.IO;

namespace CallFire_csharp_sdk.Common
{
    internal interface IHttpClient
    {
        string Send(string relativeUrl, HttpMethod method, object body);
        string Send(string relativeUrl, object body, Stream file, string contentType);
    }
}
