namespace CallFire_csharp_sdk.Common
{
    internal interface IHttpClient
    {
        string Send(string relativeUrl, HttpMethod method, object body);
    }
}
