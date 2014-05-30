using CallFire_csharp_sdk.API.Soap;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal static class ContactListQueryResultMapper
    {
        internal static CfContactListQueryResult FromContactListQueryResult(ContactListQueryResult source)
        {
            return source == null ? null : new CfContactListQueryResult(); //TODO
        }
    }
}
