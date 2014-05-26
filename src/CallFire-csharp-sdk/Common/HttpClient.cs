using System;
using System.IO;
using System.Net;
using System.Text;

namespace CallFire_csharp_sdk.Common
{
    internal class HttpClient : IHttpClient
    {
        private readonly Uri _baseUrl;
        private readonly CredentialCache _credentials;
        private readonly CustomSerializer _serializer;

        internal HttpClient(string baseUrl, string user, string password)
        {
            _baseUrl = new Uri(baseUrl);
            _credentials = new CredentialCache { { _baseUrl, "Basic", new NetworkCredential(user, password) } };
            _serializer = new CustomSerializer();
        }

        internal HttpClient()
        {
        }
        
        public string Send(string relativeUrl, HttpMethod method, object body)
        {
            var request = GetRequest(relativeUrl, method, body);

            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            {
                var responseStream = httpResponse.GetResponseStream();
                if (responseStream != null)
                {
                    return ((new StreamReader(responseStream)).ReadToEnd());
                }
            }

            return string.Empty;
        }

        private HttpWebRequest GetRequest(string relativeUrl, HttpMethod method, object body)
        {
            if (relativeUrl.StartsWith("/"))
            {
                relativeUrl = string.Format(".{0}", relativeUrl);
            }

            var address = new Uri(_baseUrl, relativeUrl);
            var request = (HttpWebRequest)WebRequest.Create(address);

            request.Method = method.ToString().ToUpper();
            request.Credentials = _credentials;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "text/xml";

            if (body != null)
            {
                var utf8ByteData = Encoding.UTF8.GetBytes(_serializer.SerializeToFormData(body));
                request.ContentLength = utf8ByteData.Length;

                using (var postStream = request.GetRequestStream())
                {
                    postStream.Write(utf8ByteData, 0, utf8ByteData.Length);
                }
            }
            return request;
        }
    }
}
