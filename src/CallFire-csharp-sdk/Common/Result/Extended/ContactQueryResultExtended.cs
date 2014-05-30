// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ContactQueryResult
    {
        public ContactQueryResult()
        {
        }
        
        public ContactQueryResult(long totalResults, Contact[] contact)
        {
            TotalResults = totalResults;
            Contact = contact;
        }
    }
}
