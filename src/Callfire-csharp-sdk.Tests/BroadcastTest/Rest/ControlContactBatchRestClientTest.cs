﻿using System;
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
    public class ControlContactBatchRestClientTest : ControlContactBatchClientTest
    {
        protected JsonServiceClient JsonServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            JsonServiceClientMock = MockRepository.GenerateMock<JsonServiceClient>();
            Client = new RestBroadcastClient(JsonServiceClientMock);

            ControlContactBatchId = 1;
            ExpectedControlContactBatch = new CfControlContactBatch(ControlContactBatchId, "controlContactBatch", true);

            JsonServiceClientMock
                .Stub(j => j.Send<long>(Arg<string>.Is.Equal(HttpMethods.Put),
                    Arg<string>.Is.Equal(String.Format("/broadcast/batch/{0}/control", ControlContactBatchId)),
                    Arg<ControlContactBatch>.Matches(x => x.Id == ExpectedControlContactBatch.Id &&
                                                       x.Name == ExpectedControlContactBatch.Name &&
                                                       x.Enabled == ExpectedControlContactBatch.Enabled)));
        }
    }
}
