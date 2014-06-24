using System;
using System.Collections.Generic;
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

            return GetResponse(request);
        }

        public string Send(string relativeUrl, object body, Stream file, string contentType)
        {
            var request = GetRequest(relativeUrl, body, file, contentType);

            return GetResponse(request);
        }

        private string GetResponse(HttpWebRequest request)
        {
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

            var formEncodedObject = _serializer.SerializeToFormData(body);

            if (method == HttpMethod.Get && !string.IsNullOrEmpty(formEncodedObject))
            {
                relativeUrl = string.Format("{0}?{1}", relativeUrl, formEncodedObject);
            }

            var address = new Uri(_baseUrl, relativeUrl);
            var request = (HttpWebRequest)WebRequest.Create(address);

            request.Method = method.ToString().ToUpper();
            request.Credentials = _credentials;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "text/xml";

            if (method == HttpMethod.Get || string.IsNullOrEmpty(formEncodedObject))
            {
                return request;
            }

            var utf8ByteData = Encoding.UTF8.GetBytes(formEncodedObject);
            request.ContentLength = utf8ByteData.Length;

            using (var postStream = request.GetRequestStream())
            {
                postStream.Write(utf8ByteData, 0, utf8ByteData.Length);
            }

            return request;
        }

        private HttpWebRequest GetRequest(string relativeUrl, object body, Stream file, string contentType)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            if (relativeUrl.StartsWith("/"))
            {
                relativeUrl = string.Format(".{0}", relativeUrl);
            }

            var address = new Uri(_baseUrl, relativeUrl);
            var request = (HttpWebRequest)WebRequest.Create(address);

            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;
            request.Credentials = _credentials;

            Stream rs = request.GetRequestStream();
            var parameters = body == null ? new List<KeyValuePair<string, string>>() : _serializer.GetProperties(body);

            const string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (var parameter in parameters)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, parameter.Key, parameter.Value);
                byte[] formitembytes = Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            const string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; \r\nContent-Type: {1}\r\n\r\n";
            string header = string.Format(headerTemplate, "Data", contentType);
            byte[] headerbytes = Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            var buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = file.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            file.Close();

            byte[] trailer = Encoding.ASCII.GetBytes(string.Format("\r\n--" + boundary + "--\r\n"));
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            return request;
        }
    }
}
