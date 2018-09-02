using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.ApiKeys.Core.Commands
{
    public interface IApiKeySingleQuery : IContextQuery<IApiKeySingleQuery>

    {
        /// <summary>
        ///     The ID of the API Key for which you are requesting information. This is everything in the API key after the SG and
        ///     before the second dot, so if this were an example API key: SG.aaaaaaaaaaaaaa.bbbbbbbbbbbbbbbbbbbbbbbb, your
        ///     api_key_id would be aaaaaaaaaaaaaa.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        IApiKeySingleQuery ById(string id);
    }
}