// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap 
{
    public partial class Contact
    {
        public Contact(long identifier, string firstName1, string lastName1, string zipcode1, string homePhone1, string workPhone1, string mobilePhone1,
            string externalId1, string externalSystem1, System.Xml.XmlAttribute[] anyAttr)
        {
            id = identifier;
            firstName = firstName1;
            lastName = lastName1;
            zipcode = zipcode1;
            homePhone = homePhone1;
            workPhone = workPhone1;
            mobilePhone = mobilePhone1;
            externalId = externalId1;
            externalSystem = externalSystem1;
            AnyAttr = anyAttr;
        }

        public Contact()
        {
        }
    }
}
