using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Commands
{
    public interface IUpdateAuthenticatedDomainSettingCommand : IContextQuery<IUpdateAuthenticatedDomainSettingCommand>

    {
        IUpdateAuthenticatedDomainSettingCommand ByModel(AuthenticatedDomainSetting value);
    }

    internal class UpdateAuthenticatedDomainSettingCommand :
        AbstractCommand<AuthenticatedDomainSetting, UpdateAuthenticatedDomainSettingCommand>,
        IUpdateAuthenticatedDomainSettingCommand,
        ICommand<AuthenticatedDomainSetting>
    {
        public UpdateAuthenticatedDomainSettingCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("default")]
        internal bool IsDefault { get; set; }

        [JsonProperty("custom_spf")]
        internal bool IsCustomSpfRecord { get; set; }

        [JsonProperty("id")]
        internal string Id { get; set; }

        public Task<IResult<AuthenticatedDomainSetting>> Execute()
        {
            return Processor
                .Process<AuthenticatedDomainSetting, IUpdateAuthenticatedDomainSettingCommand,
                    UpdateAuthenticatedDomainSettingCommand>(this,
                    context => context.UpdateAuthenticatedDomainSetting(this) /*, context =>
                    {
                        var validator = new UpdateAuthenticatedDomainSettingCommandValidator(context);
                        return validator.ValidateAsync(this);
                    }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<AuthenticatedDomainSetting, IUpdateAuthenticatedDomainSettingCommand,
                    UpdateAuthenticatedDomainSettingCommand>(this,
                    context => context.UpdateAuthenticatedDomainSetting(this) /*, context =>
                    {
                        var validator = new UpdateAuthenticatedDomainSettingCommandValidator(context);
                        return validator.ValidateAsync(this);
                    }*/);
        }

        public IUpdateAuthenticatedDomainSettingCommand ByModel(AuthenticatedDomainSetting value)
        {
            Id = value.Id;
            IsDefault = value.Default;
            IsCustomSpfRecord = value.CustomSpf;
            return this;
        }

        public IUpdateAuthenticatedDomainSettingCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}