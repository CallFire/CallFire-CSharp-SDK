using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface ILabelClient : IClient
    {
        /// <summary>
        /// Removes a label from all labeled objects and deletes it
        /// </summary>
        /// <param name="labelName">Label name</param>
        void DeleteLabel(string labelName);

        /// <summary>
        /// Returns all defined labels
        /// </summary>
        /// <param name="queryLabels"></param>
        /// <returns></returns>
        CfLabelQueryResult QueryLabels(CfQuery queryLabels);

        /// <summary>
        /// Adds a label to a broadcast, creating the label if it doesn't already exist
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        /// <param name="labelName">Label name</param>
        void LabelBroadcast(long id, string labelName);

        /// <summary>
        /// Removes a label from a single broadcast
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        /// <param name="labelName">Label name</param>
        void UnlabelBroadcast(long id, string labelName);

        /// <summary>
        /// Adds a label to a single number
        /// </summary>
        /// <param name="number">List of E.164 11 digit numbers space seperated and optional fieldName</param>
        /// <param name="labelName">Label name</param>
        void LabelNumber(string number, string labelName);

        /// <summary>
        /// Removes a label to a single number
        /// </summary>
        /// <param name="number">List of E.164 11 digit numbers space seperated and optional fieldName</param>
        /// <param name="labelName">Label name</param>
        void UnlabelNumber(string number, string labelName);
    }
}
