using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace CallFire_csharp_sdk.Common
{
    internal interface IHttpClient
    {
        string Send(string relativeUrl, HttpMethod method, object body);
    }

    internal class HttpClient : IHttpClient
    {
        private readonly Uri _baseUrl;
        private readonly CredentialCache _credentials;

        internal HttpClient(string baseUrl, string user, string password)
        {
            _baseUrl = new Uri(baseUrl);
            _credentials = new CredentialCache { { _baseUrl, "Basic", new NetworkCredential(user, password) } };
        }

        internal HttpClient()
        {
        }

        public string Send(string relativeUrl, HttpMethod method, object body)
        {
            var response = string.Empty;

            if (relativeUrl.StartsWith("/"))
            {
                relativeUrl = "." + relativeUrl;
            }

            var address = new Uri(_baseUrl, relativeUrl);
            var request = (HttpWebRequest)WebRequest.Create(address);

            request.Method = method.ToString().ToUpper();
            request.Credentials = _credentials;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "text/xml";

            if (body!=null)
            {
                byte[] byteData = Encoding.UTF8.GetBytes(string.Join("&", Values(body).Select(v => v.Key + "=" + v.Value).ToArray()));
                request.ContentLength = byteData.Length;

                using (var postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }
            }

            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            {
                var responseStream = httpResponse.GetResponseStream();
                if (responseStream != null) response = ((new StreamReader(responseStream)).ReadToEnd());
            }

            return response;
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
                        result.Add(new KeyValuePair<string, string>(propertyInfo.Name, HttpUtility.UrlEncode(propertyInfo.GetValue(o, null).ToString())));
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
