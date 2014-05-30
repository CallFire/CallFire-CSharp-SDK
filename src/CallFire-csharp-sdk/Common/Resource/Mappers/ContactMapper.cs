using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class ContactMapper
    {
        internal static CfContact FromContact(Contact source)
        {
            return source == null ? null 
                : new CfContact(source.id, source.firstName, source.lastName, source.zipcode, source.homePhone,
                    source.workPhone, source.mobilePhone, source.externalId, source.externalSystem, source.AnyAttr);
        }

        internal static Contact ToContact(CfContact source)
        {
            return source == null ? null
                : new Contact(source.Id, source.FirstName, source.LastName, source.Zipcode, source.HomePhone,
                    source.WorkPhone, source.MobilePhone, source.ExternalId, source.ExternalSystem, source.AnyAttr);
        }
    }
}
