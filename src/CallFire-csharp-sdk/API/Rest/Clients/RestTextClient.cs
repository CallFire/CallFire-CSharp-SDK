using CallFire_csharp_sdk.API.Rest.Data;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API.Rest.Clients
{
    public class RestTextClient : BaseRestClient<Text>, ITextClient
    {
        public RestTextClient(string username, string password)
            : base(username, password)
        {
        }

        internal RestTextClient(IHttpClient xmlClient)
            : base(xmlClient)
        {
        }

        public long SendText(CfSendText cfSendText)
        {
            var resource = BaseRequest<ResourceReference>(HttpMethod.Post, new SendText(cfSendText), new CallfireRestRoute<Text>(null));
            return resource.Id;
        }

        public CfTextQueryResult QueryTexts(CfActionQuery cfQueryText)
        {
            var resourceList = BaseRequest<ResourceList>(HttpMethod.Get, new ActionQuery(cfQueryText),
                new CallfireRestRoute<Text>());

            var text = TextMapper.FromText(ResourceListOperations.CastResourceList<Text>(resourceList));
            return new CfTextQueryResult(resourceList.TotalResults, text);
        }

        public CfText GetText(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null, new CallfireRestRoute<Text>(id));
            return TextMapper.FromText(resource.Resources as Text);
        }

        public long CreateAutoReply(CfCreateAutoReply cfCreateAutoReply)
        {
            var resource = BaseRequest<ResourceReference>(HttpMethod.Post, new CreateAutoReply(cfCreateAutoReply), new CallfireRestRoute<Text>(null));
            return resource.Id;
        }

        public CfAutoReplyQueryResult QueryAutoReplies(CfQueryAutoReplies cfQueryAutoReplies)
        {
            var resourceList = BaseRequest<ResourceList>(HttpMethod.Get, new QueryAutoReplies(cfQueryAutoReplies),
                new CallfireRestRoute<Text>());

            var autoReply = AutoReplyMapper.FromAutoReplay(ResourceListOperations.CastResourceList<AutoReply>(resourceList));
            return new CfAutoReplyQueryResult(resourceList.TotalResults, autoReply);
        }

        public CfAutoReply GetAutoReply(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null, new CallfireRestRoute<Text>(id, BroadcastRestRouteObjects.AutoReply, null));
            return AutoReplyMapper.FromAutoReplay(resource.Resources as AutoReply);
        }

        public void DeleteAutoReply(long id)
        {
            BaseRequest<string>(HttpMethod.Delete, null, new CallfireRestRoute<Text>(id, BroadcastRestRouteObjects.AutoReply, null));
        }
    }
}
