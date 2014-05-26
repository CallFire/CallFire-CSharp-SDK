using System.Configuration;

namespace Callfire_csharp_sdk.IntegrationTests
{
    internal static class MockClient
    {
        internal static string User()
        {
            return ConfigurationManager.AppSettings.Get("AppLogin");
        }

        internal static string Password()
        {
            return ConfigurationManager.AppSettings.Get("Password");
        }
    }
}
