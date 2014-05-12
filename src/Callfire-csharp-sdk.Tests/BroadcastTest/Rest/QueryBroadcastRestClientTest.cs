using System;
using CallFire_csharp_sdk.API.Rest.BroadcastRest;
using CallFire_csharp_sdk.API.Soap;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    class QueryBroadcastRestClientTest : QueryBroadcastClientTest
    {
        protected JsonServiceClient JsonServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            JsonServiceClientMock = MockRepository.GenerateMock<JsonServiceClient>();
            Client = new RestBroadcastClient(JsonServiceClientMock);

            MaxResult = 5;
            var cfBroadcastQueryResult = new BroadcastQueryResult(1, new Broadcast[1]);

            JsonServiceClientMock
                .Stub(j => j.Send<BroadcastQueryResult>(Arg<string>.Is.Equal(HttpMethods.Get),
                    Arg<string>.Is.Equal(String.Format("/broadcast?MaxResults={0}&FirstResult={1}", MaxResult, FirstResult)),
                    Arg<object>.Is.Null))
                .Return(cfBroadcastQueryResult);
        }
    }
}
