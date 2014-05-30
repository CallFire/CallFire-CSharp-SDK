using CallFire_csharp_sdk.Common.Resource;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class QueryContacts
    {
        public QueryContacts(CfQueryContacts source)
            : base(source.MaxResults, source.FirstResult)
        {
            Field = source.Field;
            ContactListId = source.ContactListId;
            String = source.String;
        }
        
        public QueryContacts()
        {
        }
    }
}
