using System.Linq;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests
{
    [TestFixture]
    public abstract class CallfireNumberClientTest
    {
        protected INumberClient NumberClient;

        protected CfRegionQuery RegionQuery;
        protected CfSearchAvailableKeywords SearchAvailableKeywords;
        protected CfSearchAvailableNumbers SearchAvailableNumbers;
        protected CfQuery QueryKeywords;
        
        [Test]
        public void Test_QueryRegions()
        {
            var regionQueryResult = NumberClient.QueryRegions(RegionQuery);
            Assert.IsNotNull(regionQueryResult);
            Assert.IsNotNull(regionQueryResult.Region);
            Assert.IsTrue(regionQueryResult.Region.Any(r => r.City != null && r.City.Equals("HACKENSACK")));
        }

        [Test]
        public void Test_SearchAvailableKeywords()
        {
            var keywordQueryResult = NumberClient.SearchAvailableKeywords(SearchAvailableKeywords);
            Assert.IsNotNull(keywordQueryResult);
            Assert.IsNotNull(keywordQueryResult.Keyword);
            Assert.IsTrue(keywordQueryResult.Keyword.Any(r => r.ShortCode != null && r.ShortCode.Equals("67076")));
        }

        [Test]
        public void Test_SearchAvailableNumbers()
        {
            var numbersQueryResult = NumberClient.SearchAvailableNumbers(SearchAvailableNumbers);
            Assert.IsNotNull(numbersQueryResult);
            Assert.IsNotNull(numbersQueryResult.Number);
            Assert.IsTrue(numbersQueryResult.Number.Any(r => r.Number1 != null && r.Number1.Equals("18558649944")));
        }

        [Test]
        public void Test_Querykeywords()
        {
            var keywordQueryResult = NumberClient.QueryKeywords(QueryKeywords);
            Assert.IsNotNull(keywordQueryResult);
            Assert.AreEqual(keywordQueryResult.TotalResults, 0);
        }
    }
}
