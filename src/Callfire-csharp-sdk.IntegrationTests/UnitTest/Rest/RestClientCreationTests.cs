using CallFire_csharp_sdk.API;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests.UnitTest.Rest
{
    [TestFixture]
    public class RestClientCreationTests : ClientCreationTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            Client = new CallfireClient("", "", CallfireClients.Rest);
        }
    }
}
