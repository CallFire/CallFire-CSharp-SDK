using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class ContactBatchMapper
    {
        internal static CfContactBatch FromSoapContactBatch(ContactBatch source)
        {
            if (source == null)
            {
                return null;
            }
            return new CfContactBatch(source.id, source.Name, EnumeratedMapper.EnumFromSoapEnumerated<CfBatchStatus>(source.Status.ToString()),
                source.BroadcastId, source.Created, source.Size, source.Remaining);
        }

        internal static ContactBatch ToSoapContactBatch(CfContactBatch source)
        {
            return source == null ? null : new ContactBatch(source);
        }
    }
}
