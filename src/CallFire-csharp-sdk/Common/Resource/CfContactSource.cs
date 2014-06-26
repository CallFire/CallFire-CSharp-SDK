using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfContactSource
    {
        public CfContactSource()
        {
        }

        public CfContactSource(object[] items)
        {
            if (items != null && items.Any())
            {
                if (items.GetValue(0).GetType() == typeof(Contact))
                {
                    Items = items.Select(i => ContactMapper.FromContact(i as Contact)).ToArray();
                }
                else if (items.GetValue(0).GetType() == typeof(ContactSourceNumbers))
                {
                    Items = items.Select(i => ContactSourceNumbersMapper.FromContactSourceNumbers(i as ContactSourceNumbers)).ToArray();
                }
                else
                {
                    Items = items;
                }
            }
        }

        /// <summary>
        /// List of contacts, numbers, contactIds, or csv file.
        /// </summary>
        public object[] Items { get; set; }
    }
}
