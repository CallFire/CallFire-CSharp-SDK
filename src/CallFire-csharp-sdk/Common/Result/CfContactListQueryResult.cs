using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Result
{
    public class CfContactListQueryResult : CfQueryResult
    {
        public CfContactListQueryResult(long totalResults, CfContactList[] contactList)
            : base(totalResults)
        {
            ContactList = contactList;
        }

        public CfContactList[] ContactList { get; set; }
    }
}
