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
            return CallMapper.FromCall(CallService.GetCall(new IdRequest(id)));
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
            return SoundMetaMapper.FromSoundMeta(CallService.GetSoundMeta(new IdRequest(id)));
        }

        public byte[] GetSoundData(CfGetSoundData cfGetSoundData)
        {
            var format = EnumeratedMapper.ToSoapEnumerated<SoundFormat>(cfGetSoundData.Format.ToString());
            return CallService.GetSoundData(new GetSoundData(cfGetSoundData.Id, format));
        }

        public byte[] GetRecordingData(CfGetRecordingData cfGetRecordingData)
        {
            var itemsElementNameField = EnumeratedMapper.ToArraySoapEnumerated<CfItemsChoiceType, ItemsChoiceType>(cfGetRecordingData.ItemsElementNameField);
            var format = EnumeratedMapper.ToSoapEnumerated<SoundFormat>(cfGetRecordingData.Format.ToString());
            return CallService.GetRecordingData(new GetRecordingData(cfGetRecordingData.Items, itemsElementNameField, format));
        }
    }
}
