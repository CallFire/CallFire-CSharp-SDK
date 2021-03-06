﻿using System.Linq;
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
            var resource = BaseRequest<ResourceReference>(HttpMethod.Post, new SendText(cfSendText), new CallfireRestRoute<Text>());
            return resource.Id;
        }

        public CfTextQueryResult QueryTexts(CfActionQuery cfQueryText)
        {
            var resourceList = BaseRequest<ResourceList>(HttpMethod.Get, new ActionQuery(cfQueryText),
                new CallfireRestRoute<Text>());

            var text = resourceList.Resource == null ? null
                : resourceList.Resource.Select(r => TextMapper.FromText((Text)r)).ToArray();
            return new CfTextQueryResult(resourceList.TotalResults, text);
        }

        public CfText GetText(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null, new CallfireRestRoute<Text>(id));
            return TextMapper.FromText(resource.Resources as Text);
        }

        public long CreateAutoReply(CfCreateAutoReply cfCreateAutoReply)
        {
            var resource = BaseRequest<ResourceReference>(HttpMethod.Post, new CreateAutoReply(cfCreateAutoReply), new CallfireRestRoute<Text>(null, TextRestRouteObjects.AutoReply, null));
            return resource.Id;
        }

        public CfAutoReplyQueryResult QueryAutoReplies(CfQueryAutoReplies cfQueryAutoReplies)
        {
            var resourceList = BaseRequest<ResourceList>(HttpMethod.Get, new QueryAutoReplies(cfQueryAutoReplies),
                new CallfireRestRoute<Text>(null, TextRestRouteObjects.AutoReply, null));

            var autoReply = resourceList.Resource == null ? null
                : resourceList.Resource.Select(r => AutoReplyMapper.FromAutoReplay((AutoReply)r)).ToArray();
            return new CfAutoReplyQueryResult(resourceList.TotalResults, autoReply);
        }

        public CfAutoReply GetAutoReply(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null, new CallfireRestRoute<Text>(id, TextRestRouteObjects.AutoReply, null));
            return AutoReplyMapper.FromAutoReplay(resource.Resources as AutoReply);
        }

        public void DeleteAutoReply(long id)
        {
            BaseRequest<string>(HttpMethod.Delete, null, new CallfireRestRoute<Text>(id, TextRestRouteObjects.AutoReply, null));
        }
    }
}
