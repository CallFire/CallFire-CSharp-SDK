using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using RestSharp;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace CallFire_csharp_sdk.API.Rest
{
    public abstract class BaseRestClient<T> 
    {
        private const string RestApiUrl = "https://www.callfire.com/api/1.1/rest/";
        internal readonly XmlServiceClient XmlClient;

        internal BaseRestClient(string username, string password)
            : this(CreateXmlServiceClient(username, password))
        {
        }

        private static XmlServiceClient CreateXmlServiceClient(string username, string password)
        {
            var client = new XmlServiceClient(RestApiUrl);
            client.SetCredentials(username, password);
            client.AlwaysSendBasicAuthHeader = true;
            
            return client;
        }

        internal BaseRestClient(XmlServiceClient xmlClient)
        {
            XmlClient = xmlClient;
        }
        /*
        public T GetById(long id)
        {
            return BaseRequest<T>(Method.GET, null, new CallfireRestRoute<T>(id));
        }
        */
        public long Create(T objectToCreate)
        {
            var resourcerReference = BaseRequest<ResourceReference>(HttpMethods.Post, objectToCreate, new CallfireRestRoute<T>(null));
            return resourcerReference.Id;
        }

        public void Delete(long id)
        {
            //BaseRequest<object>(Method.DELETE, null, new CallfireRestRoute<T>(id));
        }

        public TU BaseRequest<TU>(string method, object request, CallfireRestRoute<T> route)
        {
            var response = XmlClient.Send<string>(method, route.ToString(), request);
            
            var serializer = new XmlSerializer(typeof(TU));
            TextReader reader=new StringReader(response);
            return (TU)serializer.Deserialize(reader);
        }
    }
}
