using System.Linq;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class Action
    {
        public Action(CfAction source)
        {
            FromNumber = source.FromNumber;
            ToNumber = ToNumberMapper.ToToNumber(source.ToNumber);
            State = EnumeratedMapper.ScreamingSnakeCase(source.State.ToString());
            BatchId = source.BatchId;
            BroadcastId = source.BroadcastId;
            ContactId = source.ContactId;
            Inbound = source.Inbound;
            Created = source.Created;
            Modified = source.Modified;
            FinalResult = EnumeratedMapper.ScreamingSnakeCase(source.FinalResult.ToString());
            Label = source.Label.Select(LabelMapper.ToLabel).ToArray();
            id = source.Id;
        }

        public Action()
        {
        }
    }
}
