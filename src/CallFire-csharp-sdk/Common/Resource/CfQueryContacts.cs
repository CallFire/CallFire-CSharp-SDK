namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfQueryContacts : CfQuery
    {
        public CfQueryContacts(long maxResult, long firstResult, string field, long contactListId, string str)
            : base(maxResult, firstResult)
        {
            Field = field;
            ContactListId = contactListId;
            String = str;
        }

        public string Field { get; set; }

        public long ContactListId { get; set; }

        public string String { get; set; }  
    }
}
