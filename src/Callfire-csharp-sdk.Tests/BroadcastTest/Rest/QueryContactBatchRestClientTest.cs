using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class QueryContactBatchRestClientTest : QueryContactBatchClientTest
    {
        protected XmlServiceClient XmlServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            XmlServiceClientMock = MockRepository.GenerateMock<XmlServiceClient>();
            Client = new RestBroadcastClient(XmlServiceClientMock);

            ExpectedQueryContactBatches = new CfQueryContactBatches(500, 0, 1);

            ExpectedContactBatch = new CfContactBatch(1, "contactBatch", CfBatchStatus.Active, 2, DateTime.Now, 10, 15);

            var contactBatchArray = new CfContactBatch[1];
            contactBatchArray[0] = ExpectedContactBatch;

            ExpectedContactBatchQueryResult = new CfContactBatchQueryResult(10, contactBatchArray);
            
            XmlServiceClientMock
                .Stub(j => j.Send<ContactBatchQueryResult>(Arg<string>.Is.Equal(HttpMethods.Get),
                    Arg<string>.Is.Equal(String.Format("/broadcast/{0}/batch?MaxResults={1}&FirstResult={2}",
                                    ExpectedQueryContactBatches.BroadcastId, ExpectedQueryContactBatches.MaxResults, ExpectedQueryContactBatches.FirstResult)),
                    Arg<object>.Is.Null))
                .Return(ContactBatchQueryResultMapper.ToSoapContactBatchQueryResult(ExpectedContactBatchQueryResult));
        }
    }
}
