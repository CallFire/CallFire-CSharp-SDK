using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Soap
{
    [TestFixture]
    public class GetContactBatchSoapClientTest : GetContactBatchClientTest
    {
        protected IBroadcastServicePortTypeClient BroadcastServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            BroadcastServiceMock = MockRepository.GenerateStub<IBroadcastServicePortTypeClient>();
            Client = new SoapBroadcastClient(BroadcastServiceMock);

            ContactBatchId = 1;
            ExpectedContactBatch = new CfContactBatch(ContactBatchId, "contactBatch", CfBatchStatus.Active, 5, DateTime.Now, 200, 10);

            var contactBatch = ContactBatchMapper.ToSoapContactBatch(ExpectedContactBatch);
            BroadcastServiceMock
                .Stub(b => b.GetContactBatch(Arg<IdRequest>.Matches(x => x.Id == ContactBatchId)))
                .Return(contactBatch);
        }
    }
}
