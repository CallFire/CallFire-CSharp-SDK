using CallFire_csharp_sdk.API;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.Rest
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
