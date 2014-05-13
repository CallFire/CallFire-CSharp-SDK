using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    public class ContactBatchMapper
    {
        internal static CfContactBatch FromSoapContactBatch(ContactBatch source)
        {
            if (source == null)
            {
                return null;
            }
            return new CfContactBatch(source.id, source.Name, BatchStatusMapper.FromSoapBatchStatus(source.Status),
                source.BroadcastId, source.Created, source.Size, source.Remaining);
        }

        internal static ContactBatch ToSoapContactBatch(CfContactBatch source)
        {
            if (source == null)
            {
                return null;
            }
            return new ContactBatch(source.Id, source.Name,
                BatchStatusMapper.ToSoapBatchStatus(source.Status), source.BroadcastId, source.Created, source.Size,
                source.Remaining);
        }
    }
}
