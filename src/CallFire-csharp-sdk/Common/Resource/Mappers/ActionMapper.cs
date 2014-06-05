using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class ActionMapper
    {
        internal static CfAction FromAction(Action source)
        {
            return source == null ? null : new CfAction(source);
        }

        internal static Action ToAction(CfAction source)
        {
            return source == null ? null : new Action(source);
        }
    }
}
