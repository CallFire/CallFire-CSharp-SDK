using System.Linq;
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
            var toNumber = ToNumberMapper.FromToNumber(source.ToNumber);
            var state = EnumeratedMapper.EnumFromSoapEnumerated<CfActionState>(source.State);
            var finalResult = EnumeratedMapper.EnumFromSoapEnumerated<CfResult>(source.FinalResult);
            var label = source.Label == null ? null : source.Label.Select(LabelMapper.FromLabel).ToArray();
            return new CfAction(source.FromNumber, toNumber, state, source.BatchId, source.BroadcastId, source.ContactId,
                source.Inbound, source.Created, source.Modified, finalResult, label, source.id);
        }

        internal static Action ToAction(CfAction source)
        {
            return source == null ? null : new Action(source);
        }
    }
}