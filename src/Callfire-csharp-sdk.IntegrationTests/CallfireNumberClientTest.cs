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

        //QueryRegions
        [Test]
        public void Test__QueryRegionsAllResults()
        {

            //go to Try it out!

        }

        [Test]
        public void Test_QueryRegionsComplete()
        {

            //fields complete
            //MaxResults 200
            //FirstResult 90

        }

        //QueryNumbers
        [Test]
        public void Test__QueryNumbersAllResults()
        {

            //go to Try it out!

        }

        [Test]
        public void Test_QueryNumbersComplete()
        {

            //fields complete
            //MaxResults 10
            //FirstResult 50

        }

        //GetNumber
        [Test]
        public void Test_GetNumberValidNumber()
        {
            //Number Valid
        }

        [Test]
        public void Test_GetNumberInValidNumber()
        {
            //Number InValido
        }
        [Test]
        public void Test_GetNumbernull()
        {
            //Number null
        }

        //ConfigureNumber
        [Test]
        public void Test_ConfigureNumberValidNumber()
        {
            //Number Valid only
            //
        }

        [Test]
        public void Test_ConfigureNumberInValidNumber()
        {
            //Number InValido 
        }

        [Test]
        public void Test_ConfigureNumberNull()
        {
            // 
        }
        [Test]
        public void Test_ConfigureNumberTrakingNull()
        {
            //InboundCallConfigurationType=  Traking 
            //the rest of the fields empty
        }
        [Test]
        public void Test_ConfigureNumberTrakingComplete()
        {
            //InboundCallConfigurationType=  Traking 
            //all fields complete
        }
        [Test]
        public void Test_ConfigureNumberIVRNull()
        {
            //InboundCallConfigurationType=  IVR
            //the rest of the fields empty
        }
        [Test]
        public void Test_ConfigureNumberIVRComplete()
        {
            //InboundCallConfigurationType=  IVR 
            //all fields complete
        }

        //SearchAvailableNumbers
        [Test]
        public void Test_ConfigureNumberMandatory()
        {
            //mandatory= count?
        }
        [Test]
        public void Test_ConfigureNumbeComplete()
        {
            //mandatory= count?
            //all fields complete
            //TollFree= true

        }
        [Test]
        public void Test_ConfigureNumbeWrong()
        {
            //mandatory= count?
            //State	!= Country ?
            
        }

        //QueryKeywords

        [Test]
        public void Test_QueryKeywordsAllResults()
        {
            //go to Try it out!

        }
        [Test]
        public void Test_QueryKeywordsComplete()
        {

            //fields complete
            //MaxResults 37
            //FirstResult 1

        }

        //SearchAvailableKeywords
        [Test]
        public void Test_SearchAvailableKeywordsNotExist()
        {

            //Not exist

        }
        [Test]
        public void Test_SearchAvailableKeywordsComplete()
        {

            //valid

        }


        //CreateNumberOrder
        [Test]
        public void Test_CreateNumberOrderMandatory()
        {

            //Count 

        }
        [Test]
        public void Test_CreateNumberOrderComplete()
        {

            //all fields complete

        }

        //GetNumberOrder
        [Test]
        public void Test_GetNumberOrderValidId()
        {
            //ID Valido
        }

        [Test]
        public void Test_GetNumberOrderInValidId()
        {
            //ID InValido
        }
        [Test]
        public void Test_GetContactIDnull()
        {
            //ID null
        }

        //Release
        [Test]
        public void Test_ReleaseMandatory()
        {
            //Num
        }
        [Test]
        public void Test_ReleaseComplete()
        {
            //all fields complete
        }
        [Test]
        public void Test_ReleaseInvalidNum()
        {
            //invalid number
        }







    















        
        [Test]
        public void Test_QueryRegions()
        {
            var regionQueryResult = NumberClient.QueryRegions(RegionQuery);
            Assert.IsNotNull(regionQueryResult);
            Assert.IsNotNull(regionQueryResult.Region);
            Assert.IsTrue(regionQueryResult.Region.Any(r => r.City != null && r.City.Equals("HACKENSACK")));
            //Assert.IsTrue(regionQueryResult.Region.Any(r => r.Prefix == "1201208" && r.City.Equals("HACKENSACK")));
            //Assert.AreEqual("1201208", regionQueryResult.nUMBERO);
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
