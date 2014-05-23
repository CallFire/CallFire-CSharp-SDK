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
            HttpWebRequest request;
            var response = Response(relativeUrl, method, body, out request);

            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            {
                var responseStream = httpResponse.GetResponseStream();
                if (responseStream != null) response = ((new StreamReader(responseStream)).ReadToEnd());
            }

            return response;
        }

        private string Response(string relativeUrl, HttpMethod method, object body, out HttpWebRequest request)
        {
            var response = string.Empty;

            if (relativeUrl.StartsWith("/"))
            {
                relativeUrl = string.Format(".{0}", relativeUrl);
            }

            var address = new Uri(_baseUrl, relativeUrl);
            request = (HttpWebRequest) WebRequest.Create(address);

            request.Method = method.ToString().ToUpper();
            request.Credentials = _credentials;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "text/xml";

            if (body != null)
            {
                byte[] byteData = Encoding.UTF8.GetBytes(_serializer.SerializeToFormData(body));
                request.ContentLength = byteData.Length;

                using (var postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }
            }
            return response;
        }
    }
}
