using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    public class ContactBatchQueryResultMapper
    {
        internal static CfContactBatchQueryResult FromSoapContactBatchQueryResult(ContactBatchQueryResult source)
        {
            if (source == null)
            {
                return null;
            }
            var contactBatch = source.ContactBatch;
            if (contactBatch == null)
            {
                return new CfContactBatchQueryResult(source.TotalResults, null);
            }
            var newContactBatchArray = new CfContactBatch[contactBatch.Count()];
            for (var i = 0; i < contactBatch.Count(); i++)
            {
                var item = contactBatch[i];
                newContactBatchArray[i] = ContactBatchMapper.FromSoapContactBatch(item);
            }
            return new CfContactBatchQueryResult(source.TotalResults, newContactBatchArray);
        }

        internal static ContactBatchQueryResult ToSoapContactBatchQueryResult(CfContactBatchQueryResult source)
        {
            if (source == null)
            {
                return null;
            }
            var contactBatch = source.ContactBatch;
            if (contactBatch == null)
            {
                return new ContactBatchQueryResult(source.TotalResults, null);
            }
            var newContactBatchArray = new ContactBatch[contactBatch.Count()];
            for (var i = 0; i < contactBatch.Count(); i++)
            {
                var item = contactBatch[i];
                newContactBatchArray[i] = ContactBatchMapper.ToSoapContactBatch(item);
            }
            return new ContactBatchQueryResult(source.TotalResults, newContactBatchArray);
        }
    }
}
