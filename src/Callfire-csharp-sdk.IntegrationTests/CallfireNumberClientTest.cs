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
        protected CfQueryNumbers QueryNumbers;
        
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
            Assert.IsNull(keywordQueryResult.Keyword);
        }

        [Test]
        public void Test_SearchAvailableNumbers()
        {
            var numbersQueryResult = NumberClient.SearchAvailableNumbers(SearchAvailableNumbers);
            Assert.IsNotNull(numbersQueryResult);
            Assert.IsNotNull(numbersQueryResult.Number);
            Assert.IsTrue(numbersQueryResult.Number.Any(r => r.Number1 != null));
        }

        [Test]
        public void Test_Querykeywords()
        {
            var keywordQueryResult = NumberClient.QueryKeywords(QueryKeywords);
            Assert.IsNotNull(keywordQueryResult);
            Assert.AreEqual(keywordQueryResult.TotalResults, 0);
        }

        [Test]
        public void Test_QueryNumbers()
        {
            var numbersQueryResult = NumberClient.QueryNumbers(QueryNumbers);
            Assert.IsNotNull(numbersQueryResult);
            Assert.AreEqual(numbersQueryResult.TotalResults, 0);
        }
    }
}
