using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface ITextClient : IClient
    {
        /// <summary>
        /// Send text message and return broadcastId
        /// </summary>
        /// <param name="cfSendText"></param>
        /// <returns>Unique ID of resource</returns>
        long SendText(CfSendText cfSendText);

        /// <summary>
        /// List sent and received text messages
        /// </summary>
        /// <param name="cfActionQuery"></param>
        /// <returns>List of Texts</returns>
        CfTextQueryResult QueryTexts(CfActionQuery cfActionQuery);

        /// <summary>
        /// Gets a text message by ID
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        /// <returns>Text requested</returns>
        CfText GetText(long id);

        /// <summary>
        /// Configures a new auto-reply
        /// </summary>
        /// <param name="cfCreateAutoReply"></param>
        /// <returns>Unique ID of resource</returns>
        long CreateAutoReply(CfCreateAutoReply cfCreateAutoReply);

        /// <summary>
        /// Lists configured auto-replies
        /// </summary>
        /// <param name="cfQueryAutoReplies"></param>
        /// <returns>List of AutoReplies</returns>
        CfAutoReplyQueryResult QueryAutoReplies(CfQueryAutoReplies cfQueryAutoReplies);

        /// <summary>
        /// Gets an auto-reply by ID
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        /// <returns>AutoReply requested</returns>
        CfAutoReply GetAutoReply(long id);
        
        /// <summary>
        /// Deletes an auto-reply by ID
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        void DeleteAutoReply(long id);
    }
}
