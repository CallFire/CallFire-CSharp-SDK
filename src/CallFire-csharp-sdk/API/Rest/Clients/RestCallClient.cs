using System;
using CallFire_csharp_sdk.API.Rest.Data;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API.Rest.Clients
{
    public class RestCallClient : BaseRestClient<Call>, ICallClient
    {
        public RestCallClient(string username, string password)
            : base(username, password)
        {
        }

        internal RestCallClient(IHttpClient xmlClient)
            : base(xmlClient)
        {
        }

        public long SendCall(CfSendCall cfSendCall)
        {
            var resource = BaseRequest<ResourceReference>(HttpMethod.Post, new SendCall(cfSendCall), new CallfireRestRoute<Call>());
            return resource.Id;
        }

        public CfCallQueryResult QueryCalls(CfActionQuery cfQueryCalls)
        {
            var resourceList = BaseRequest<ResourceList>(HttpMethod.Get, new ActionQuery(cfQueryCalls),
                new CallfireRestRoute<Call>());

            var call = CallMapper.FromCall(ResourceListOperations.CastResourceList<Call>(resourceList));
            return new CfCallQueryResult(resourceList.TotalResults, call);
        }

        public CfCall GetCall(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null, new CallfireRestRoute<Call>(id));
            return CallMapper.FromCall(resource.Resources as Call);
        }

        public long CreateSound(CfCreateSound cfCreateSound)
        {
            var resource = BaseRequest<ResourceReference>(HttpMethod.Post, new CreateSound(cfCreateSound), new CallfireRestRoute<Call>());
            return resource.Id;
        }

        public CfSoundMetaQueryResult QuerySoundMeta(CfQuery cfQuerySoundMeta)
        {
            var resourceList = BaseRequest<ResourceList>(HttpMethod.Get, new Query(cfQuerySoundMeta),
                new CallfireRestRoute<Call>());
           
            var soundMeta = SoundMetaMapper.FromSoundMeta(ResourceListOperations.CastResourceList<SoundMeta>(resourceList));
            return new CfSoundMetaQueryResult(resourceList.TotalResults, soundMeta);
        }

        public CfSoundMeta GetSoundMeta(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null, new CallfireRestRoute<Call>(id));
            return SoundMetaMapper.FromSoundMeta(resource.Resources as SoundMeta);
        }

        public byte[] GetSoundData(CfGetSoundData cfGetSoundData)
        {
            throw new NotImplementedException();
        }

        public byte[] GetRecordingData(CfGetRecordingData cfGetRecordingData)
        {
            throw new NotImplementedException();
        }
    }
}
