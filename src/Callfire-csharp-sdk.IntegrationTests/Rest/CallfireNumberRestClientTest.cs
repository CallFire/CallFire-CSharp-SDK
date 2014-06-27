using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests.Rest
{
    [TestFixture]
    public class CallfireNumberRestClientTest : CallfireNumberClientTest
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            var region = new CfRegion(null, null, null, null, null, null, null, null, null, null);
            Client = new RestNumberClient(MockClient.User(), MockClient.Password());
            RegionQuery = new CfRegionQuery(100, 0, region);
            SearchAvailableKeywords = new CfSearchAvailableKeywords(string.Empty);
            SearchAvailableNumbers = new CfSearchAvailableNumbers(null, true, 100);
            QueryKeywords = new CfQuery();
            QueryNumbers = new CfQueryNumbers(100, 0, region, null);
        }
    }
}
