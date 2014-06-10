using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class ActionMapper
    {
        internal static CfAction FromAction(Action source)
        {
            if (source == null)
            {
                return null;
            }

            CfAction item = null;
            if (source.GetType() == typeof(Text))
            {
                item = TextMapper.FromText((Text)source);
            }
            else if (source.GetType() == typeof(Call))
            {
                item = CallMapper.FromCall((Call)source);
            }
            return item;
        }

        internal static Action ToAction(CfAction source)
        {
            if (source == null)
            {
                return null;
            }

            Action item = null;
            if (source.GetType() == typeof(CfText))
            {
                item = TextMapper.ToText((CfText)source);
            }
            else if (source.GetType() == typeof(CfCall))
            {
                item = CallMapper.ToCall((CfCall)source);
            }
            return item;
        }
    }
}