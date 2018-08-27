using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Users.Core;
using Fluentley.SendGrid.Operations.Users.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Users.Commands
{
    internal class UpdateUserProfileCommand : AbstractCommand<UserProfile, UpdateUserProfileCommand>,
        IUpdateUserProfileCommand,
        ICommand<UserProfile>
    {
        public UpdateUserProfileCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        public Task<IResult<UserProfile>> Execute()
        {
            return Processor.Process<UserProfile, IUpdateUserProfileCommand, UpdateUserProfileCommand>(this,
                context => context.UpdateUserProfile(this) /*, context =>
                {
                    var validator = new UpdateUserProfileCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<UserProfile, IUpdateUserProfileCommand, UpdateUserProfileCommand>(this,
                context => context.UpdateUserProfile(this) /*, context =>
                {
                    var validator = new UpdateUserProfileCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public IUpdateUserProfileCommand ByModel(UserProfile userProfile)
        {
            Address = userProfile.Address;
            Address2 = userProfile.Address2;
            City = userProfile.City;
            State = userProfile.State;
            Zip = userProfile.Zip;
            Country = userProfile.Country;
            Company = userProfile.Company;
            Website = userProfile.Website;
            Phone = userProfile.Phone;
            FirstName = userProfile.FirstName;
            LastName = userProfile.LastName;
            return this;
        }

        public IUpdateUserProfileCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}