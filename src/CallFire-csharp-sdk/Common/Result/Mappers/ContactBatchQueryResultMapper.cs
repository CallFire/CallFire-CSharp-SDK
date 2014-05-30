using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal class ContactBatchQueryResultMapper
    {
        internal static CfContactBatchQueryResult FromSoapContactBatchQueryResult(ContactBatchQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var contactBatch = source.ContactBatch == null ? null
                                : source.ContactBatch.Select(ContactBatchMapper.FromSoapContactBatch).ToArray();
            return new CfContactBatchQueryResult(source.TotalResults, contactBatch);
        }

        internal static ContactBatchQueryResult ToSoapContactBatchQueryResult(CfContactBatchQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var contactBatch = source.ContactBatch == null ? null
                                : source.ContactBatch.Select(ContactBatchMapper.ToSoapContactBatch).ToArray();
            return new ContactBatchQueryResult(source.TotalResults, contactBatch);
        }
    }
}
