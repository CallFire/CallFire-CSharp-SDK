// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ContactBatchQueryResult
    {
        public ContactBatchQueryResult(long totalResults, ContactBatch[] contactBatch)
        {
            TotalResults = totalResults;
            ContactBatch = contactBatch;
        }

        public ContactBatchQueryResult()
        {
        }
    }
}
