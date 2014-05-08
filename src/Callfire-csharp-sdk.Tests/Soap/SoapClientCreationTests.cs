using CallFire_csharp_sdk.API;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.Soap
{
    [TestFixture]
    public class SoapClientCreationTests : ClientCreationTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            Client = new CallfireClient("", "",CallfireClients.Soap);
        }
    }
}
