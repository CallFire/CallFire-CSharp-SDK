using System;
using System.IO;
using System.Net;
using System.Text;

namespace CallFire_csharp_sdk.Common
{
    internal class HttpClient
    {
        private readonly Uri _baseUrl;
        private readonly CredentialCache _credentials;

        internal HttpClient(string baseUrl, string user, string password)
        {
            _baseUrl = new Uri(baseUrl);
            _credentials = new CredentialCache { { _baseUrl, "Basic", new NetworkCredential(user, password) } };
        }

        internal string Send(string relativeUrl, HttpMethod method, string body)
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

            if (!string.IsNullOrEmpty(body))
            {
                byte[] byteData = Encoding.UTF8.GetBytes(body);
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
    }
}
