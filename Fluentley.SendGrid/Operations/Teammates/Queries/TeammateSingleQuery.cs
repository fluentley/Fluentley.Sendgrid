using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Teammates.Models;

namespace Fluentley.SendGrid.Operations.Teammates.Queries
{
    public interface ITeammateSingleQuery : IContextQuery<ITeammateSingleQuery>

    {
        ITeammateSingleQuery ByUserName(string value);
    }

    internal class TeammateSingleQuery : AbstractSingleQuery<Teammate>, ITeammateSingleQuery, IQuery<Teammate>
    {
        public TeammateSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string UserName { get; set; }

        public Task<IResult<Teammate>> Execute()
        {
            return QueryProcessor.Process<Teammate, ITeammateSingleQuery, TeammateSingleQuery>(this,
                context => context.TeammateByUserName(UserName));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<Teammate, ITeammateSingleQuery, TeammateSingleQuery>(this,
                context => context.TeammateByUserName(UserName));
        }

        public ITeammateSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public ITeammateSingleQuery ByUserName(string value)
        {
            UserName = value;
            return this;
        }
    }
}