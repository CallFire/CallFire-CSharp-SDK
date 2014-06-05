using System.Linq;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ContactSource
    {
        public ContactSource()
        {
        }
        
        public ContactSource(object[] items)
        {
            if (items.GetType() == typeof(CfContact[]))
            {
                Items = items.Select(i => ContactMapper.ToContact(i as CfContact)).ToArray();
            }
            else if (items.GetType() == typeof (CfContactSourceNumbers[]))
            {
                Items = items.Select(i => ContactSourceNumbersMapper.ToContactSourceNumbers(i as CfContactSourceNumbers)).ToArray();
            }
            else
            {
                Items = items;
            }
        }
    }
}
