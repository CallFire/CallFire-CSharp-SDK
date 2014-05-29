using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;

namespace CallFire_csharp_sdk.API.Soap
{
    public class SoapCallClient : BaseSoapClient, ICallClient
    {
        internal ICallServicePortTypeClient CallService;

        public SoapCallClient(string username, string password)
        {
            CallService = new CallServicePortTypeClient(GetCustomBinding(), GetEndpointAddress<Call>())
            {
                ClientCredentials = { UserName = { UserName = username, Password = password } }
            };
        }

        internal SoapCallClient(ICallServicePortTypeClient client)
        {
            CallService = client;
        }

        public long SendCall(CfSendCall cfSendCall)
        {
            var type = EnumeratedMapper.ScreamingSnakeCase(cfSendCall.Type.ToString());
            var toNumber = ToNumberMapper.ToToNumber(cfSendCall.ToNumber);
            var broadcastConfig = BroadcastConfigMapper.ToBroadcastConfig(cfSendCall.Item, cfSendCall.Type);
            var sendCall = new SendCall(cfSendCall.RequestId, type, cfSendCall.BroadcastName, toNumber, cfSendCall.ScrubBroadcastDuplicates, broadcastConfig);
            return CallService.SendCall(sendCall);
        }

        public CfCallQueryResult QueryCalls(CfActionQuery cfActionQuery)
        {
            var callQueryResult = CallService.QueryCalls(new ActionQuery(cfActionQuery));
            return CallQueryResultMapper.FromCallQueryResult(callQueryResult);
        }

        public CfCall GetCall(long id)
        {
            var call = CallService.GetCall(new IdRequest(id));
            return CallMapper.FromCall(call);
        }

        public long CreateSound(CfCreateSound cfCreateSound)
        {
            return CallService.CreateSound(new CreateSound(cfCreateSound.Name, cfCreateSound.Item, cfCreateSound.SoundTextVoice));
        }

        public CfSoundMetaQueryResult QuerySoundMeta(CfQuery cfQuerySoundMeta)
        {
            var soundMetaQueryResult = CallService.QuerySoundMeta(new Query(cfQuerySoundMeta.MaxResults, cfQuerySoundMeta.FirstResult));
            return SoundMetaQueryResultMapper.FromSoundMetaQueryResult(soundMetaQueryResult);
        }

        public CfSoundMeta GetSoundMeta(long id)
        {
            var soundMeta = CallService.GetSoundMeta(new IdRequest(id));
            return SoundMetaMapper.FromSoundMeta(soundMeta);
        }
    }
}
