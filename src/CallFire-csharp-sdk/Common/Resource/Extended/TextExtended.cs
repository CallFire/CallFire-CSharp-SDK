using System;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class Text
    {
        public Text(string fromNumber, ToNumber toNumber, string state, long batchId, long broadcastId, long contactId,
            bool inbound, DateTime created, DateTime modified, string finalResult, Label[] label, long identifier, string message, TextRecord[] textRecord) 
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
            Message = message;
            TextRecord = textRecord;
        }

        public Text()
        {
        }
    }
}
