using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class SendCall
    {
        public SendCall()
        {
        }
        
        public SendCall(CfSendCall cfSendCall)
        {
            RequestId = cfSendCall.RequestId;
            Type = EnumeratedMapper.ScreamingSnakeCase(cfSendCall.Type.ToString());
            BroadcastName = cfSendCall.BroadcastName;
            ToNumber = ToNumberMapper.ToToNumber(cfSendCall.ToNumber);
            ScrubBroadcastDuplicates = cfSendCall.ScrubBroadcastDuplicates;
            Label = cfSendCall.Labels;
            Item = BroadcastConfigMapper.ToBroadcastConfig(cfSendCall.Item, cfSendCall.Type);
        }
    }
}
