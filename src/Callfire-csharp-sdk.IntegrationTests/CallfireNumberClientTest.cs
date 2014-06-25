using System;
using System.Linq;
using System.Net;
using System.ServiceModel;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests
{
    [TestFixture]
    public abstract class CallfireNumberClientTest
    {
        protected INumberClient Client;

        protected CfRegionQuery RegionQuery;
        protected CfSearchAvailableKeywords SearchAvailableKeywords;
        protected CfSearchAvailableNumbers SearchAvailableNumbers;
        protected CfQuery QueryKeywords;
        protected CfQueryNumbers QueryNumbers;

        protected const string VerifyFromNumber = "+15712655344";
        protected const string VerifyShortCode = "67076";

        protected const string ExistingNumber = "13107742289";
        protected const string ExistingKeyword = "NETTEST";
        
        public void AssertClientException<TRest, TSoap>(TestDelegate test)
            where TRest : Exception
            where TSoap : Exception
        {
            if (Client.GetType() == typeof(RestNumberClient))
            {
                Assert.Throws<TRest>(test);
            }
            else
            {
                Assert.Throws<TSoap>(test);
            }
        }

        /// <summary>
        /// QueryRegions
        /// </summary>
        
        [Test]
        public void Test__QueryRegionsAllResults()
        {
            var regionQuery = new CfRegionQuery
            {
                MaxResults = 100,
                Region = new CfRegion()
            };
            var regions = Client.QueryRegions(regionQuery);
            Assert.IsNotNull(regions);
        }

        [Test]
        public void Test_QueryRegionsComplete()//TODO
        {
            var regionQuery = new CfRegionQuery
            {
                MaxResults = 200,
                FirstResult = 90,
                Region = new CfRegion
                {
                    Prefix = "1201202",
                    City = "HACKENSACK",
                    State = "NJ",
                    Zipcode = "07601",
                    Country = "US",
                    Lata = "224",
                    RateCenter = "HACKENSACK",
                    Latitude = (float) 40.887,
                    Longitude = (float) -74.0391,
                    TimeZone = "America/New_York"
                }
            };
            var regions = Client.QueryRegions(regionQuery);
            Assert.IsNotNull(regions);
        }

        /// <summary>
        /// QueryNumbers
        /// </summary>
        [Test]
        public void Test__QueryNumbersAllResults()
        {
            var queryNumbers = new CfQueryNumbers
            {
                Region = new CfRegion()
            };
            var numberQueryResult = Client.QueryNumbers(queryNumbers);
            Assert.IsNotNull(numberQueryResult);
        }

        [Test]
        public void Test_QueryNumbersComplete()//TODO
        {
            var queryNumbers = new CfQueryNumbers
            {
                MaxResults = 10,
                FirstResult = 50,
                Region = new CfRegion
                {
                    Prefix = "1310774",
                    City = "MALIBU",
                    State = "CA",
                    Zipcode = "90264",
                    Country = "US",
                    Lata = "730",
                    RateCenter = "MALIBU",
                    Latitude = (float)34.0331,
                    Longitude = (float)-118.633,
                    TimeZone = "America/Los_Angeles"
                }
            };
            var numberQueryResult = Client.QueryNumbers(queryNumbers);
            Assert.IsNotNull(numberQueryResult);
        }

        /// <summary>
        /// GetNumber
        /// </summary>
        [Test]
        public void Test_GetNumberValidNumber()
        {
            var number = Client.GetNumber(ExistingNumber);
            Assert.IsNotNull(number);
        }

        [Test]
        public void Test_GetNumberInValidNumber()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.GetNumber("4988461"));
        }

        [Test]
        public void Test_GetNumbernull()
        {
            if (Client.GetType() == typeof(RestNumberClient))
            {
                var number = Client.GetNumber(null);
                Assert.IsNull(number);
            }
            else
            {
                Assert.Throws<FaultException>(() => Client.GetNumber(null));
            }
        }

        /// <summary>
        /// ConfigureNumber
        /// </summary>
        [Test]
        public void Test_ConfigureNumberValidNumber()
        {
            var configureNumber = new CfConfigureNumber
            {
                Number = ExistingNumber,
                NumberConfiguration = new CfNumberConfiguration
                {
                    TextFeature = CfNumberFeature.Enabled
                }
            };
            Client.ConfigureNumber(configureNumber);
        }

        [Test]
        public void Test_ConfigureNumberInValidNumber()
        {
            var configureNumber = new CfConfigureNumber
            {
                Number = "48943156648",
                NumberConfiguration = new CfNumberConfiguration()
            };
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.ConfigureNumber(configureNumber));
        }

        [Test]
        public void Test_ConfigureNumberNull()
        {
            if (Client.GetType() == typeof(RestNumberClient))
            {
                Client.ConfigureNumber(new CfConfigureNumber());
            }
            else
            {
                Assert.Throws<FaultException>(() => Client.ConfigureNumber(new CfConfigureNumber()));
            }
        }

        [Test]
        public void Test_ConfigureNumberTrakingNull()
        {
            var configureNumber = new CfConfigureNumber
            {
                Number = ExistingNumber,
                NumberConfiguration = new CfNumberConfiguration
                {
                    InboundCallConfigurationType = CfInboundType.Tracking,
                    InboundCallConfiguration = new CfNumberConfigurationInboundCallConfiguration()
                }
            };
            if (Client.GetType() == typeof(RestNumberClient))
            {
                Client.ConfigureNumber(configureNumber);
            }
            else
            {
                Assert.Throws<FaultException>(() => Client.ConfigureNumber(configureNumber));
            }
        }

        [Test]
        public void Test_ConfigureNumberTrakingComplete()
        {
            var configureNumber = new CfConfigureNumber
            {
                Number = ExistingNumber,
                NumberConfiguration = new CfNumberConfiguration
                {
                    InboundCallConfigurationType = CfInboundType.Tracking,
                    InboundCallConfiguration = new CfNumberConfigurationInboundCallConfiguration
                    {
                        Item = new CfCallTrackingConfig
                        {
                            TransferNumber = ExistingNumber,
                            Record = true,
                            Screen = true,
                            IntroSoundId = 460803001,
                            WhisperSoundId = 460803001
                        }
                    }
                }
            };
            Client.ConfigureNumber(configureNumber);
        }

        [Test]
        public void Test_ConfigureNumberIVRNull()
        {
            var configureNumber = new CfConfigureNumber
            {
                Number = ExistingNumber,
                NumberConfiguration = new CfNumberConfiguration
                {
                    InboundCallConfigurationType = CfInboundType.Ivr,
                    InboundCallConfiguration = new CfNumberConfigurationInboundCallConfiguration()
                }
            };
            if (Client.GetType() == typeof(RestNumberClient))
            {
                Client.ConfigureNumber(configureNumber);
            }
            else
            {
                Assert.Throws<FaultException>(() => Client.ConfigureNumber(configureNumber));
            }
        }

        [Test]
        public void Test_ConfigureNumberIVRComplete()
        {
            var configureNumber = new CfConfigureNumber
            {
                Number = ExistingNumber,
                NumberConfiguration = new CfNumberConfiguration
                {
                    InboundCallConfigurationType = CfInboundType.Ivr,
                    InboundCallConfiguration = new CfNumberConfigurationInboundCallConfiguration
                    {
                        Item = new CfIvrInboundConfig
                        {
                            DialplanXml = "<dialplan><play type=\"tts\">Dialplan for Configure Number.</play></dialplan>"
                        }
                    }
                }
            };
            Client.ConfigureNumber(configureNumber);
        }

        /// <summary>
        /// SearchAvailableNumbers
        /// </summary>
        [Test]
        public void Test_SearchAvailableNumbers()
        {
            var numbersQueryResult = Client.SearchAvailableNumbers(SearchAvailableNumbers);
            Assert.IsNotNull(numbersQueryResult);
            Assert.IsNotNull(numbersQueryResult.Number);
            Assert.IsTrue(numbersQueryResult.Number.Any(r => r.Number1 != null));
        }
        
        [Test]
        public void Test_SearchAvailableNumbersMandatory()
        {
            var numberQueryResult = Client.SearchAvailableNumbers(new CfSearchAvailableNumbers());
            Assert.IsNotNull(numberQueryResult);
        }

        [Test]
        public void Test_SearchAvailableNumbersComplete()
        {
            var searchAvailableNumbers = new CfSearchAvailableNumbers
            {
                Count = 10,
                TollFree = true,
                Region = new CfRegion
                {
                    City = "MALIBU",
                    State = "CA",
                }
            };
            var numberQueryResult = Client.SearchAvailableNumbers(searchAvailableNumbers);
            Assert.IsNotNull(numberQueryResult);
        }

        [Test]
        public void Test_SearchAvailableNumbersWrong()
        {
            var searchAvailableNumbers = new CfSearchAvailableNumbers
            {
                Region = new CfRegion
                {
                    City = "MALIBU",
                    State = "CA",
                    Country = "URU"
                }
            };
            var numberQueryResult = Client.SearchAvailableNumbers(searchAvailableNumbers);
            Assert.IsNotNull(numberQueryResult);
        }

        /// <summary>
        /// QueryKeywords
        /// </summary>
        [Test]
        public void Test_Querykeywords()
        {
            var keywordQueryResult = Client.QueryKeywords(QueryKeywords);
            Assert.IsNotNull(keywordQueryResult);
            Assert.AreEqual(keywordQueryResult.TotalResults, 0);
        }
        
        [Test]
        public void Test_QueryKeywordsAllResults()
        {
            var keywordQueryResult = Client.QueryKeywords(new CfQuery());
            Assert.IsNotNull(keywordQueryResult);
        }

        [Test]
        public void Test_QueryKeywordsComplete()
        {
            var query = new CfQuery
            {
                MaxResults = 37,
                FirstResult = 1
            };
            var keywordQueryResult = Client.QueryKeywords(query);
            Assert.IsNotNull(keywordQueryResult);
        }

        /// <summary>
        /// SearchAvailableKeywords
        /// </summary>
        [Test]
        public void Test_SearchAvailableKeywords()
        {
            var keywordQueryResult = Client.SearchAvailableKeywords(SearchAvailableKeywords);
            Assert.IsNotNull(keywordQueryResult);
            Assert.IsNull(keywordQueryResult.Keyword);
        }
        
        [Test]
        public void Test_SearchAvailableKeywordsNotExist()
        {
            var searchAvailableKeywords = new CfSearchAvailableKeywords
            {
                Keywords = "KEYWORD"
            };
            var keywordQueryResult = Client.SearchAvailableKeywords(searchAvailableKeywords);
            Assert.IsNotNull(keywordQueryResult);
        }

        [Test]
        public void Test_SearchAvailableKeywordsComplete()
        {
            var searchAvailableKeywords = new CfSearchAvailableKeywords
            {
                Keywords = ExistingKeyword
            };
            var keywordQueryResult = Client.SearchAvailableKeywords(searchAvailableKeywords);
            Assert.IsNotNull(keywordQueryResult);
        }


        /// <summary>
        /// CreateNumberOrder
        /// </summary>
        [Test]
        public void Test_CreateNumberOrderMandatory()
        {
            var createNumberOrder = new CfCreateNumberOrder
            {
                Numbers = ExistingNumber,
                Keywords = ExistingKeyword
            };
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.CreateNumberOrder(createNumberOrder));
        }

        [Test]
        public void Test_CreateNumberOrderComplete()
        {
            var createNumberOrder = new CfCreateNumberOrder
            {
                Numbers = "13105551212",
                Keywords = "NEWKEYWORD",
                BulkLocal = new CfCreateNumberOrderBulkLocal
                {
                    Count = 10,
                    Region = new CfRegion
                    {
                        City = "MALIBU",
                        State = "CA",
                        Country = "US",
                        RateCenter = "MALIBU",
                        TimeZone = "America/Los_Angeles"
                    }
                },
                BulkTollFree = new CfCreateNumberOrderBulkTollFree
                {
                    Count = 1
                }
            };
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.CreateNumberOrder(createNumberOrder));
        }

        /// <summary>
        /// GetNumberOrder
        /// </summary>
        [Test]
        public void Test_GetNumberOrderValidId()//TODO
        {
            var numberOrder = Client.GetNumberOrder(987445615);
            Assert.IsNotNull(numberOrder);
        }

        [Test]
        public void Test_GetNumberOrderInValidId()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.GetNumberOrder(524546));
        }

        //Release
        [Test]
        public void Test_ReleaseMandatory()
        {
            var release = new CfRelease
            {
                Number = ExistingNumber,
            };
            Client.Release(release);
        }

        [Test]
        public void Test_ReleaseComplete() //TODO
        {
            var release = new CfRelease
            {
                Number = ExistingNumber,
                Keyword = ExistingKeyword
            };
            Client.Release(release);
        }

        [Test]
        public void Test_ReleaseInvalidNum()
        {
            var release = new CfRelease
            {
                Number = "4684615687"
            };
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.Release(release));
        }
    }
}
