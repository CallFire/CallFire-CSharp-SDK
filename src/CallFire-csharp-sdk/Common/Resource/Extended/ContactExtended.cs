using CallFire_csharp_sdk.Common.DataManagement;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap 
{
    public partial class Contact
    {
        public Contact()
        {
        }
        
        public Contact(CfContact source)
        {
            if (source.Id.HasValue)
            {
                id = source.Id.Value;
                idSpecified = true;
            }
            firstName = source.FirstName;
            lastName = source.LastName;
            zipcode = source.Zipcode;
            homePhone = source.HomePhone;
            workPhone = source.WorkPhone;
            mobilePhone = source.MobilePhone;
            externalId = source.ExternalId;
            externalSystem = source.ExternalSystem;
            AnyAttr = source.AnyAttr;
        }
    }
}
