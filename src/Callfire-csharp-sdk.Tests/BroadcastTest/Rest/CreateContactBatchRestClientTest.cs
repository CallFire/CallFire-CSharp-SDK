using System;
using CallFire_csharp_sdk.API.Rest.BroadcastRest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class CreateContactBatchRestClientTest : CreateContactBatchClientTest
    {
        protected JsonServiceClient JsonServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            JsonServiceClientMock = MockRepository.GenerateMock<JsonServiceClient>();
            Client = new RestBroadcastClient(JsonServiceClientMock);

            BroadcastId = 2;
            ExpectedCreateContactBatch = new CfCreateContactBatch("1", BroadcastId, "name", null, false);

            JsonServiceClientMock
                .Stub(j => j.Send<long>(Arg<string>.Is.Equal(HttpMethods.Post),
                    Arg<string>.Is.Equal(String.Format("/broadcast/{0}/batch", BroadcastId)),
                    Arg<CreateContactBatch>.Matches(x => x.RequestId == ExpectedCreateContactBatch.RequestId &&
                                                         x.BroadcastId == ExpectedCreateContactBatch.BroadcastId &&
                                                         x.Name == ExpectedCreateContactBatch.Name &&
                                                         x.ScrubBroadcastDuplicates ==
                                                         ExpectedCreateContactBatch.ScrubBroadcastDuplicates)))
                .Return(BroadcastId);
        }
    }
}
