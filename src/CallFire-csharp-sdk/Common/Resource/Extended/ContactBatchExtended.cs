using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ContactBatch
    {
        public ContactBatch()
        {
        }
        
        public ContactBatch(CfContactBatch source)
        {
            Name = source.Name;
            Status = EnumeratedMapper.ToSoapEnumerated<BatchStatus>(source.Status.ToString());
            BroadcastId = source.BroadcastId;
            Created = source.Created;
            if (source.Size.HasValue)
            {
                Size = source.Size.Value;
                SizeSpecified = true;
            }
            if (source.Remaining.HasValue)
            {
                Remaining = source.Remaining.Value;
                RemainingSpecified = true;
            }
            id = source.Id;
        }
    }
}
