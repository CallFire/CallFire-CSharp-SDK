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
            return CallService.SendCall(new SendCall(cfSendCall));
        }

        public CfCallQueryResult QueryCalls(CfActionQuery cfActionQuery)
        {
            return CallQueryResultMapper.FromCallQueryResult(CallService.QueryCalls(new ActionQuery(cfActionQuery)));
        }

        public CfCall GetCall(long id)
        {
            return CallMapper.FromCall(CallService.GetCall(new IdRequest(id)));
        }

        public long CreateSound(CfCreateSound cfCreateSound)
        {
            return CallService.CreateSound(new CreateSound(cfCreateSound));
        }

        public CfSoundMetaQueryResult QuerySoundMeta(CfQuery cfQuerySoundMeta)
        {
            return SoundMetaQueryResultMapper.FromSoundMetaQueryResult(CallService.QuerySoundMeta(new Query(cfQuerySoundMeta)));
        }

        public CfSoundMeta GetSoundMeta(long id)
        {
            return SoundMetaMapper.FromSoundMeta(CallService.GetSoundMeta(new IdRequest(id)));
        }

        public byte[] GetSoundData(CfGetSoundData cfGetSoundData)
        {
            return CallService.GetSoundData(new GetSoundData(cfGetSoundData));
        }

        public byte[] GetRecordingData(CfGetRecordingData cfGetRecordingData)
        {
            return CallService.GetRecordingData(new GetRecordingData(cfGetRecordingData));
        }
    }
}
