using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class LabelMapper
    {

        internal static CfLabel[] FromLabel(Label[] source)
        {
            return source == null ? null : source.Select(FromLabel).ToArray();
        }

        internal static Label[] ToLabel(CfLabel[] source)
        {
            return source == null ? null : source.Select(ToLabel).ToArray();
        }

        internal static CfLabel FromLabel(Label source)
        {
            return source == null ? null : new CfLabel(source.Name);
        }

        internal static Label ToLabel(CfLabel source)
        {
            return source == null ? null : new Label(source.Name);
        }
    }
}
