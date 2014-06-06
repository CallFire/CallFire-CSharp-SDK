using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests.Soap
{
    [TestFixture]
    public class CallfireNumberSoapClientTest : CallfireNumberClientTest
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            var region = new CfRegion(null, null, null, null, null, null, null, null, null, null);
            NumberClient = new SoapNumberClient(MockClient.User(), MockClient.Password());
            RegionQuery = new CfRegionQuery(100, 0, region);
            SearchAvailableKeywords = new CfSearchAvailableKeywords("null");
            SearchAvailableNumbers = new CfSearchAvailableNumbers(null, true, 100);
            QueryKeywords = new CfQuery();
            QueryNumbers = new CfQueryNumbers(100, 0, region, null);
        }
    }
}
