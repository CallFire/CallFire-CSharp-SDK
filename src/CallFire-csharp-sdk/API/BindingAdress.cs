using System.Configuration;
using System.Linq;

namespace CallFire_csharp_sdk.API
{
    internal class BindingAdress
    {
        private const string DefaultRestRoute = "https://www.callfire.com/api/1.1/rest/";
        private const string DefaultSoapRoute = "https://www.callfire.com/api/1.1/soap12";

        public static string Rest
        {
            get
            {
                return GetKeyFromAppConfig("CallFireRestRoute") ?? DefaultRestRoute;
            }
        }

        public static string Soap
        {
            get
            {
                return GetKeyFromAppConfig("CallFireSoapRoute") ?? DefaultSoapRoute;
            }
        }

        private static string GetKeyFromAppConfig(string key)
        {
            return ConfigurationManager.AppSettings.AllKeys.FirstOrDefault(s => s == key);
        }
    }
}
