using System;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class Call
    {
        public Call()
        {
        }
        
        public Call(string fromNumber, ToNumber toNumber, string state, long batchId, long broadcastId, long contactId, bool inbound,
            DateTime created, DateTime modified, string finalResult, Label[] label, long identifier, CallRecord[] callRecord)
        {
            FromNumber = fromNumber;
            ToNumber = toNumber;
            State = state;
            BatchId = batchId;
            BroadcastId = broadcastId;
            ContactId = contactId;
            Inbound = inbound;
            Created = created;
            Modified = modified;
            FinalResult = finalResult;
            Label = label;
            id = identifier;
            CallRecord = callRecord;
        }
    }
}
