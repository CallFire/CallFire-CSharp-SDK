using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class CreateContactBatchRestClientTest : CreateContactBatchClientTest
    {
        internal HttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<HttpClient>();
            Client = new RestBroadcastClient(HttpClientMock);

            BroadcastId = 28936;
            ExpectedCreateContactBatch = new CfCreateContactBatch("1", BroadcastId, "name", null, false);

            var response = string.Format(
               "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
               "<r:ResourceReference xmlns=\"http://api.callfire.com/data\" xmlns:r=\"http://api.callfire.com/resource\">" +
               "<r:Id>{0}</r:Id>" +
               "<r:Location>https://www.callfire.com/api/1.1/rest//broadcast/{0}/batch</r:Location>" +
               "</r:ResourceReference>", BroadcastId);
            
            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/broadcast/{0}/batch", BroadcastId)),
                    Arg<HttpMethod>.Is.Equal(HttpMethod.Post),
                    Arg<CreateContactBatch>.Matches(x => x.RequestId == ExpectedCreateContactBatch.RequestId &&
                                                         x.BroadcastId == ExpectedCreateContactBatch.BroadcastId &&
                                                         x.Name == ExpectedCreateContactBatch.Name &&
                                                         x.ScrubBroadcastDuplicates == ExpectedCreateContactBatch.ScrubBroadcastDuplicates)))
                .Return(response);
        }
    }
}
