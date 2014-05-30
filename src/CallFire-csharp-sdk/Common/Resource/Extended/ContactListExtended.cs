using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ContactList
    {
        public ContactList()
        {
        }

        public ContactList(CfContactList source)
        {
            Name = source.Name;
            Size = source.Size;
            Created = source.Created;
            Status = EnumeratedMapper.ToSoapEnumerated<ContactListStatus>(source.Status.ToString());
            id = source.Id;
        }
    }
}
