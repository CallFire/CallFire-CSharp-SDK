using System.Linq;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;
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

            Items = items.GetType() == typeof(CfToNumber[]) ? 
                items.Select(i => ToNumberMapper.ToToNumber(i as CfToNumber)).ToArray() : items;
            ScrubBroadcastDuplicates = scrubBroadcastDuplicates;
        }
    }
}
