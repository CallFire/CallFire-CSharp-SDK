using CallFire_csharp_sdk.API.Soap;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class ContactSourceNumbersMapper
    {
        internal static CfContactSourceNumbers FromContactSourceNumbers(ContactSourceNumbers source)
        {
            return source == null ? null : new CfContactSourceNumbers(source.fieldName, source.Text);
        }

        internal static ContactSourceNumbers ToContactSourceNumbers(CfContactSourceNumbers source)
        {
            return source == null ? null : new ContactSourceNumbers(source);
        }
    }
}
