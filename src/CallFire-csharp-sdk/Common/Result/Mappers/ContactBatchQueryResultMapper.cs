using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal class ContactBatchQueryResultMapper
    {
        internal static CfContactBatchQueryResult FromSoapContactBatchQueryResult(ContactBatchQueryResult source)
        {
            return source == null ? null :
                new CfContactBatchQueryResult(
                    source.TotalResults,
                    source.ContactBatch == null ? null : source.ContactBatch.Select(ContactBatchMapper.FromSoapContactBatch).ToArray());
        }

        internal static ContactBatchQueryResult ToSoapContactBatchQueryResult(CfContactBatchQueryResult source)
        {
            return source == null ? null :
                new ContactBatchQueryResult(
                    source.TotalResults,
                    source.ContactBatch == null ? null : source.ContactBatch.Select(ContactBatchMapper.ToSoapContactBatch).ToArray());
        }
    }
}
