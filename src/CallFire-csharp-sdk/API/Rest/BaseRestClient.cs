using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using CallFire_csharp_sdk.Common;

namespace CallFire_csharp_sdk.API.Rest
{
    public abstract class BaseRestClient<T>
    {
        private const string RestApiUrl = "https://www.callfire.com/api/1.1/rest/";
        internal readonly HttpClient XmlClient;

        internal BaseRestClient(string username, string password)
            : this(CreateXmlServiceClient(username, password))
        {
        }

        private static HttpClient CreateXmlServiceClient(string username, string password)
        {
            return new HttpClient(RestApiUrl, username, password);
        }

        internal BaseRestClient(HttpClient xmlClient)
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
            var resourcerReference = BaseRequest<ResourceReference>(HttpMethod.Post, objectToCreate, new CallfireRestRoute<T>(null));
            return resourcerReference.Id;
        }

        public void Delete(long id)
        {
            //BaseRequest<object>(Method.DELETE, null, new CallfireRestRoute<T>(id));
        }

        internal TU BaseRequest<TU>(HttpMethod method, object request, CallfireRestRoute<T> route)
        {
            string body = null;

            if (request != null)
            {
                body = string.Join("&", Values(request).Select(v => v.Key + "=" + v.Value).ToArray());
            }

            var response = XmlClient.Send(route.ToString(), method, body);

            if (string.IsNullOrEmpty(response))
            {
                return default(TU);
            }

            var deserializer = new XmlSerializer(typeof(TU));
            TextReader reader = new StringReader(response);
            return (TU)deserializer.Deserialize(reader);
        }

        private IEnumerable<KeyValuePair<string, string>> Values(object o)
        {
            var result = new List<KeyValuePair<string, string>>();

            var type = o.GetType();
            var props = type.GetProperties();
            foreach (var propertyInfo in props)
            {
                if (propertyInfo.PropertyType.IsArray)
                {
                    var array = ((Array)o);
                    var arrayValue = array.Cast<object>().Aggregate(string.Empty, (current, element) => current + string.Format("{0} ", HttpUtility.UrlEncode(element.ToString())));
                    result.Add(new KeyValuePair<string, string>(propertyInfo.Name, HttpUtility.UrlEncode(arrayValue)));
                }
                else if (!propertyInfo.PropertyType.IsClass || propertyInfo.PropertyType.Namespace == "System")
                {
                    if (propertyInfo.PropertyType == typeof(DateTime))
                    {
                        result.Add(
                            new KeyValuePair<string, string>(propertyInfo.Name,
                                HttpUtility.UrlEncode(((DateTime)propertyInfo.GetValue(o, null)).ToString("yyyy-MM-ddThh:mm:ss"))));
                    }
                    else
                    {
                        result.Add(new KeyValuePair<string, string>(propertyInfo.Name,HttpUtility.UrlEncode(propertyInfo.GetValue(o, null).ToString())));
                    }
                }
                else
                {
                    var value = propertyInfo.GetValue(o, null);
                    if (value != null)
                    {
                        result.AddRange(Values(value));
                    }
                }
            }
            return result;
        }
    }
}
