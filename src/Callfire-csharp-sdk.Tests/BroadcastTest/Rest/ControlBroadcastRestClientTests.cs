using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    class ControlBroadcastRestClientTests : ControlBroadcastClientTest
    {
        protected XmlServiceClient XmlServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            XmlServiceClientMock = MockRepository.GenerateMock<XmlServiceClient>();
            Client = new RestBroadcastClient(XmlServiceClientMock);

            ExpectedControlBroadcast = new CfControlBroadcast(1, "123", CfBroadcastCommand.Start, 5);
            
            XmlServiceClientMock
                .Stub(j => j.Send<long>(Arg<string>.Is.Equal(HttpMethods.Put),
                    Arg<string>.Is.Equal("/broadcast"),
                    Arg<ControlBroadcast>.Matches(x => x.Id == ExpectedControlBroadcast.Id &&
                                                       x.RequestId == ExpectedControlBroadcast.RequestId &&
                                                       x.Command == BroadcastCommand.START &&
                                                       x.MaxActive == ExpectedControlBroadcast.MaxActive)));
        }
    }
}
