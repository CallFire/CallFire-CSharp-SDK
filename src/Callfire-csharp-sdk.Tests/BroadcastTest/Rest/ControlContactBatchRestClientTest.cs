using System;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class ControlContactBatchRestClientTest : ControlContactBatchClientTest
    {
        internal IHttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<IHttpClient>();
            Client = new RestBroadcastClient(HttpClientMock);

            ControlContactBatchId = 1;
            ExpectedControlContactBatch = new CfControlContactBatch(ControlContactBatchId, "controlContactBatch", true);

            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/broadcast/batch/{0}/control", ControlContactBatchId)),
                    Arg<HttpMethod>.Is.Equal(HttpMethod.Put),
                    Arg<ControlContactBatch>.Matches(x => x.Id == ExpectedControlContactBatch.Id &&
                                                          x.Name == ExpectedControlContactBatch.Name &&
                                                          x.Enabled == ExpectedControlContactBatch.Enabled)))
                .Return(string.Empty);
        }
    }
}
