using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class Call
    {
        public Call()
        {
        }
        
        public Call(CfCall source)
        {
            FromNumber = source.FromNumber;
            ToNumber = ToNumberMapper.ToToNumber(source.ToNumber);
            State = EnumeratedMapper.ScreamingSnakeCase(source.State.ToString());
            if (source.BatchId.HasValue)
            {
                BatchId = source.BatchId.Value;
                BatchIdSpecified = true;
            }
            if (source.BroadcastId.HasValue)
            {
                BroadcastId = source.BroadcastId.Value;
                BroadcastIdSpecified = true;
            }
            ContactId = source.ContactId;
            Inbound = source.Inbound;
            Created = source.Created;
            Modified = source.Modified;
            FinalResult = EnumeratedMapper.ScreamingSnakeCase(source.FinalResult.ToString());
            Label = LabelMapper.ToLabel(source.Label);
            id = source.Id;
            CallRecord = CallRecordMapper.ToCallRecord(source.CallRecord);
        }
    }
}
