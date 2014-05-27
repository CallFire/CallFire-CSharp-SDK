using System.Configuration;
using System.Linq;

namespace CallFire_csharp_sdk.API
{
    internal class BindingAdress
    {
        public static string Rest
        {
            get
            {
                return GetKeyFromAppConfig("CallFireRestRoute");
            }
        }

        public static string Soap
        {
            get
            {
                return GetKeyFromAppConfig("CallFireSoapRoute");
            }
        }

        private static string GetKeyFromAppConfig(string key)
        {
            if (ConfigurationManager.AppSettings.AllKeys.All(s => s != key))
            {
                throw new ConfigurationErrorsException(string.Format("{0} key is not configured.", key));
            }
            return ConfigurationManager.AppSettings[key];
        }
    }
}
