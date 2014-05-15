// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class CreateContactBatch
    {
        public CreateContactBatch(string requestId, long broadcastId, string name, object[] items, bool scrubBroadcastDuplicates)
        {
            RequestId = requestId;
            BroadcastId = broadcastId;
            Name = name;
            Items = items;
            ScrubBroadcastDuplicates = scrubBroadcastDuplicates;
        }
    }
}
