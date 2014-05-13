using System;
using CallFire_csharp_sdk.API.Rest.BroadcastRest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class GetContactBatchRestClientTest : GetContactBatchClientTest
    {
        protected JsonServiceClient JsonServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            JsonServiceClientMock = MockRepository.GenerateMock<JsonServiceClient>();
            Client = new RestBroadcastClient(JsonServiceClientMock);

            ContactBatchId = 1;
            ExpectedContactBatch = new CfContactBatch(ContactBatchId, "contactBatch", CfBatchStatus.Active, 5, DateTime.Now, 200, 10);

            var contactBatch = ContactBatchMapper.ToSoapContactBatch(ExpectedContactBatch);

            JsonServiceClientMock
                .Stub(j => j.Send<ContactBatch>(Arg<string>.Is.Equal(HttpMethods.Get),
                    Arg<string>.Is.Equal(String.Format("/broadcast/batch/{0}", ContactBatchId)),
                    Arg<object>.Is.Null))
                .Return(contactBatch);
        }
    }
}
