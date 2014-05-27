using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class LabelMapper
    {
        internal static CfLabel FromSoapLabel(Label source)
        {
            if (source == null)
            {
                return null;
            }
            return new CfLabel
            {
                Name = source.Name
            };
        }

        internal static Label ToSoapLabel(CfLabel source)
        {
            if (source == null)
            {
                return null;
            }
            return new Label
            {
                Name = source.Name
            };
        }
    }
}
