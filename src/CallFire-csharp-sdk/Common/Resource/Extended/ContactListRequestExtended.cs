using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ContactListRequest
    {
        public ContactListRequest(CfContactListRequest source)
        {
            ContactListId = source.ContactListId;
            Validate = source.Validate;
            ContactSource = ContactSourceMapper.ToContactSource(source.ContactSource);
        }
    }
}
