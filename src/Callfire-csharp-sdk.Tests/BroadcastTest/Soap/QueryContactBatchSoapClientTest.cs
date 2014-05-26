using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Soap
{
    [TestFixture]
    public class QueryContactBatchSoapClientTest : QueryContactBatchClientTest
    {
        protected IBroadcastServicePortTypeClient BroadcastServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            BroadcastServiceMock = MockRepository.GenerateStub<IBroadcastServicePortTypeClient>();
            Client = new SoapBroadcastClient(BroadcastServiceMock);

            ExpectedQueryBroadcastData = new CfQueryBroadcastData(500, 0, 1);

            ExpectedContactBatch = new CfContactBatch(1, "contactBatch", CfBatchStatus.Active, 2, DateTime.Now, 10, 15);

            var contactBatchArray = new CfContactBatch[1];
            contactBatchArray[0] = ExpectedContactBatch;

            ExpectedContactBatchQueryResult = new CfContactBatchQueryResult(10, contactBatchArray);

            BroadcastServiceMock
                .Stub(b => b.QueryContactBatches( Arg<QueryContactBatches>.Matches(x => x.MaxResults == ExpectedQueryBroadcastData.MaxResults &&
                                                                                        x.FirstResult == ExpectedQueryBroadcastData.FirstResult &&
                                                                                        x.BroadcastId == ExpectedQueryBroadcastData.BroadcastId)))
                .Return(ContactBatchQueryResultMapper.ToSoapContactBatchQueryResult(ExpectedContactBatchQueryResult));
        }
    }
}
