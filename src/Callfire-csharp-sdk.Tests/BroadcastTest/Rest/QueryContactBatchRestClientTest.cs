using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class QueryContactBatchRestClientTest : QueryContactBatchClientTest
    {
        internal HttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<HttpClient>();
            Client = new RestBroadcastClient(HttpClientMock);

            ExpectedQueryContactBatches = new CfQueryContactBatches(500, 0, 1);

            ExpectedContactBatch = new CfContactBatch(1, "contactBatch", CfBatchStatus.Active, 2, DateTime.Now, 10, 15);

            var contactBatchArray = new CfContactBatch[1];
            contactBatchArray[0] = ExpectedContactBatch;

            ExpectedContactBatchQueryResult = new CfContactBatchQueryResult(10, contactBatchArray);

            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/broadcast/{0}/batch?MaxResults={1}&FirstResult={2}",
                            ExpectedQueryContactBatches.BroadcastId, ExpectedQueryContactBatches.MaxResults,
                            ExpectedQueryContactBatches.FirstResult)),
                            Arg<HttpMethod>.Is.Equal(HttpMethod.Get),
                            Arg<object>.Is.Null))
                .Return("");//ContactBatchQueryResultMapper.ToSoapContactBatchQueryResult(ExpectedContactBatchQueryResult));
        }
    }
}
