using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace CallFire_csharp_sdk.API.Rest
{
    public abstract class BaseRestClient<T>  
    {
        private const string RestApiUrl = "https://www.callfire.com/api/1.1/rest/";
        internal readonly JsonServiceClient JsonClient;

        internal BaseRestClient(string username, string password)
            : this(CreateJsonServiceClient(username, password))
        {
        }

        private static JsonServiceClient CreateJsonServiceClient(string username, string password)
        {
            var client = new JsonServiceClient(RestApiUrl);
            client.SetCredentials(username, password);
            client.AlwaysSendBasicAuthHeader = true;

            return client;
        }

        internal BaseRestClient(JsonServiceClient jsonClient)
        {
            JsonClient = jsonClient;
        }

        public T GetById(long id)
        {
            return BaseRequest<T>(HttpMethods.Get, null, new CallfireRestRoute<T>(id));
        }

        public long Create(T objectToCreate)
        {
            return BaseRequest<long>(HttpMethods.Post, objectToCreate, new CallfireRestRoute<T>(null));
        }

        public void Delete(long id)
        {
            BaseRequest<string>(HttpMethods.Delete, null, new CallfireRestRoute<T>(id));
        }

        public TU BaseRequest<TU>(string method, object request, CallfireRestRoute<T> route)
        {
            return JsonClient.Send<TU>(method, route.ToString(), request);
        }
    }
}
