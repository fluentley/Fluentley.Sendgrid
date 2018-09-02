using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Contexts.Extensions;
using Fluentley.SendGrid.Contexts.HttpClientHelpers;
using Fluentley.SendGrid.Operations.Alerts.Commands;
using Fluentley.SendGrid.Operations.Alerts.Models;
using Fluentley.SendGrid.Operations.ApiKeys.Commands;
using Fluentley.SendGrid.Operations.ApiKeys.Models;
using Fluentley.SendGrid.Operations.ApiKeys.Queries;
using Fluentley.SendGrid.Operations.BlockedEmailAddresses.Commands;
using Fluentley.SendGrid.Operations.BlockedEmailAddresses.Queries;
using Fluentley.SendGrid.Operations.BouncedEmailAddresses.Commands;
using Fluentley.SendGrid.Operations.BouncedEmailAddresses.Queries;
using Fluentley.SendGrid.Operations.Campaigns.Commands;
using Fluentley.SendGrid.Operations.Campaigns.Models;
using Fluentley.SendGrid.Operations.Campaigns.Queries;
using Fluentley.SendGrid.Operations.CampaignSchedules.Commands;
using Fluentley.SendGrid.Operations.CampaignSchedules.Models;
using Fluentley.SendGrid.Operations.Categories.Models;
using Fluentley.SendGrid.Operations.Categories.Queries;
using Fluentley.SendGrid.Operations.DomainAuthentications.Commands;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;
using Fluentley.SendGrid.Operations.DomainAuthentications.Queries;
using Fluentley.SendGrid.Operations.EmailCNameRecords.Commands;
using Fluentley.SendGrid.Operations.EmailCNameRecords.Models;
using Fluentley.SendGrid.Operations.EmailOperations;
using Fluentley.SendGrid.Operations.InvalidEmailAddresses.Commands;
using Fluentley.SendGrid.Operations.InvalidEmailAddresses.Queries;
using Fluentley.SendGrid.Operations.IpAccessManagements.Commands;
using Fluentley.SendGrid.Operations.IpAccessManagements.Models;
using Fluentley.SendGrid.Operations.IpAccessManagements.Queries;
using Fluentley.SendGrid.Operations.IpAddresses.Commands;
using Fluentley.SendGrid.Operations.IpAddresses.Extensions;
using Fluentley.SendGrid.Operations.IpAddresses.Models;
using Fluentley.SendGrid.Operations.IpAddresses.Queries;
using Fluentley.SendGrid.Operations.IpPools.Commands;
using Fluentley.SendGrid.Operations.IpPools.Models;
using Fluentley.SendGrid.Operations.IpWarmups.Commands;
using Fluentley.SendGrid.Operations.IpWarmups.Models;
using Fluentley.SendGrid.Operations.LinkBrandings.Commands;
using Fluentley.SendGrid.Operations.LinkBrandings.Models;
using Fluentley.SendGrid.Operations.LinkBrandings.Queries;
using Fluentley.SendGrid.Operations.MonitorSettings.Commands;
using Fluentley.SendGrid.Operations.MonitorSettings.Models;
using Fluentley.SendGrid.Operations.Reputations.Models;
using Fluentley.SendGrid.Operations.Reputations.Queries;
using Fluentley.SendGrid.Operations.ReverseDnses.Commands;
using Fluentley.SendGrid.Operations.ReverseDnses.Models;
using Fluentley.SendGrid.Operations.ReverseDnses.Queries;
using Fluentley.SendGrid.Operations.SenderIdentities.Commands;
using Fluentley.SendGrid.Operations.SenderIdentities.Models;
using Fluentley.SendGrid.Operations.SettingEnforcedTls.Commands;
using Fluentley.SendGrid.Operations.SettingEnforcedTls.Models;
using Fluentley.SendGrid.Operations.SettingInboundParse.Commands;
using Fluentley.SendGrid.Operations.SettingInboundParse.Models;
using Fluentley.SendGrid.Operations.SettingMail.Commands;
using Fluentley.SendGrid.Operations.SettingMail.Models;
using Fluentley.SendGrid.Operations.SettingMail.Queries;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Commands;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Models;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Queries;
using Fluentley.SendGrid.Operations.Statistics.Extensions;
using Fluentley.SendGrid.Operations.Statistics.Models;
using Fluentley.SendGrid.Operations.Statistics.Queries;
using Fluentley.SendGrid.Operations.SubUsers.Commands;
using Fluentley.SendGrid.Operations.SubUsers.Models;
using Fluentley.SendGrid.Operations.SubUsers.Queries;
using Fluentley.SendGrid.Operations.Teammates.Commands;
using Fluentley.SendGrid.Operations.Teammates.Core;
using Fluentley.SendGrid.Operations.Teammates.Models;
using Fluentley.SendGrid.Operations.Teammates.Queries;
using Fluentley.SendGrid.Operations.Users.Commands;
using Fluentley.SendGrid.Operations.Users.Models;
using Fluentley.SendGrid.Operations.Webhooks.Commands;
using Fluentley.SendGrid.Operations.Webhooks.Models;
using Fluentley.SendGrid.Operations.Webhooks.Queries;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using User = Fluentley.SendGrid.Operations.Users.Models.User;

namespace Fluentley.SendGrid.Contexts
{
    internal class Context
    {
        private readonly IContext _context;

        public Context(string key, bool shouldSendRequest = true)
        {
            var httpHandler = new CustomHttpClientHandler(shouldSendRequest);
            var httpClient = new HttpClient(httpHandler)
            {
                BaseAddress = new Uri("https://api.sendgrid.com/v3/")
            };

            _context = new RestClient(httpClient).AddJsonBodySerializer().For<IContext>();
            _context.ApiKey = $"Bearer {key}";
            _context.ContentType = "application/json";
        }

        public void SetOnBehalfOf(string subUserName)
        {
            _context.OnBehalfOf = subUserName;
        }

        public void SetApiKey(string key)
        {
            _context.ApiKey = $"Bearer {key}";
        }

        #region Send Email

        public Task<Response<string>> SendEmail(SendEmailCommand command)
        {
            return _context.SendEmail(command);
        }

        #endregion

        #region Reputations

        public Task<Response<List<Reputation>>> SubuserReputations(
            ReputationListQuery option = null)
        {
            return _context.SubuserReputations(option?.SubUserNames.ToArray());
        }

        #endregion

        #region Email Statistics

        public Task<Response<List<EmailStatistic>>> EmailStatics(
            EmailStatisticsListQuery option = null)
        {
            string startDateTime = null;

            if (option?.StartTimeTimeSpan != null)
                startDateTime = new DateTime(2012, 01, 01).Add(option.StartTimeTimeSpan.Value).ToString("YYYY-MM-DD");

            string endDateTime = null;

            if (option?.EndTimeTimeSpan != null)
                endDateTime = new DateTime(2012, 01, 01).Add(option.EndTimeTimeSpan.Value).ToString("YYYY-MM-DD");

            var subUserDictionary = new Dictionary<string, string>();
            if (option?.SubUserNames != null && option.SubUserNames.Any())
                foreach (var userName in option.SubUserNames)
                    subUserDictionary.Add("subusers", userName);

            if (option?.SubUserNames?.Any() ?? false || (option?.RetrieveForAllSubUsers ?? false))
                return _context.EmailStatisticsForSubUsers(option?.PageSize, option?.PageIndex,
                    startDate: startDateTime,
                    endDate: endDateTime, subusers: subUserDictionary,
                    aggregatedby: option?.StatisticAggregate.ToAggregateByString());

            if (option?.Categories?.Any() ?? false || (option?.RetrieveForAllCategories ?? false))
                return _context.EmailStatisticsForCategories(option?.PageSize, option?.PageIndex,
                    startDate: startDateTime,
                    endDate: endDateTime, subusers: subUserDictionary,
                    aggregatedby: option?.StatisticAggregate.ToAggregateByString());

            return _context.EmailStatisticsForSubUsers(option?.PageSize, option?.PageIndex, startDate: startDateTime,
                endDate: endDateTime, subusers: subUserDictionary,
                aggregatedby: option?.StatisticAggregate.ToAggregateByString());
        }

        #endregion

        #region Categories

        public Task<Response<List<Category>>> Categories(CategoryListQuery categoryListQuery)
        {
            return _context.Categories(categoryListQuery.PageSize, categoryListQuery.PageIndex,
                categoryListQuery.Category);
        }

        #endregion

        public Task<Response<WebhookSettings>> WebhookSettings()
        {
            return _context.WebhookSettings();
        }

        public Task<Response<SendGridResult<List<WebhookParseSettings>>>> WebhookParseSettings()
        {
            return _context.WebhookParseSettings();
        }

        public Task<Response<List<WebhookParseStatistics>>> WebhookParseStatistics(
            WebhookParseStatisticsListQuery option)
        {
            string startDateTime = null;

            if (option?.StartTimeTimeSpan != null)
                startDateTime = new DateTime(2012, 01, 01).Add(option.StartTimeTimeSpan.Value).ToString("YYYY-MM-DD");

            string endDateTime = null;

            if (option?.EndTimeTimeSpan != null)
                endDateTime = new DateTime(2012, 01, 01).Add(option.EndTimeTimeSpan.Value).ToString("YYYY-MM-DD");

            return _context.WebhookParseStatistics(option?.PageSize, option?.PageIndex, startDateTime,
                endDateTime, option?.StatisticAggregate.ToAggregateByString());
        }

        public Task<Response<WebhookSettings>> UpdateWebhookSettings(UpdateWebHookSettingsCommand command)
        {
            return _context.UpdateWebhookSettings(command);
        }

        public Task<Response<string>> SendTestWebhookEvent(SendTestWebhookEventCommand command)
        {
            return _context.SendTestWebhookEvent(command);
        }

        public Task<Response<SendGridResult<List<RemainingIpAddress>>>> RemainingIpAddresses()
        {
            return _context.RemainingIpAddresses();
        }

        public Task<Response<List<IpAddress>>> IpAddresses(IpAddressListQuery query)
        {
            return _context.IpAddresses(query.PageIndex, query.PageSize, query.Direction.ToText(),
                query.ExcludeWhiteLables, query.IpAddress, query.SubUser);
        }

        public Task<Response<IpAddress>> IpAddressByIpAddress(string ipAddress)
        {
            return _context.IpAddressByIpAddress(ipAddress);
        }

        public Task<Response<List<AssignedIpAddress>>> AssignedIpAddresses()
        {
            return _context.AssignedIpAddresses();
        }

        public Task<Response<AddIpResult>> AddIpAddress(AddIpAddressCommand command)
        {
            return _context.AddIpAddress(command);
        }

        public Task<Response<SendDnsInformationResult>> SendGeneratedDnsInformation(
            SendGeneratedDnsInformationCommand command)
        {
            return _context.SendGeneratedDnsInformation(command);
        }

        public Task<Response<List<ReverseDns>>> ReverseDnses(ReverseDnsListQuery query)
        {
            return _context.ReverseDnses(query.PageIndex, query.PageSize, query.IpAddress);
        }

        public Task<Response<ReverseDns>> ReverseDnsById(string id)
        {
            return _context.ReverserDnsById(id);
        }

        public Task<Response<ReverseDns>> SetupReverseDns(SetupReverseDnsCommand command)
        {
            return _context.SetupReverseDns(command);
        }

        public Task<Response<string>> DeleteReverseDns(string id)
        {
            return _context.DeleteReverseDns(id);
        }

        public Task<Response<ReverseDnsValidationResult>> ValidateReverseDnsById(string id)
        {
            return _context.ValidateReverseDnsById(id);
        }

        #region Teammates

        public Task<Response<List<TeammateAccessRequest>>> TeammateAccessRequests(TeammateAccessRequestListQuery query)
        {
            return _context.TeammateAccessRequests(query.PageSize, query.PageIndex);
        }

        #endregion

        public Task<Response<string>> DenyTeammateAccessRequestById(string id)
        {
            return _context.DenyTeammateAccessRequestById(id);
        }

        public Task<Response<ApproveTeammateRequestResult>> ApproveTeammateAccessRequestById(string id)
        {
            return _context.ApproveTeammateAccessRequestById(id);
        }

        public Task<Response<TeammateInviteResult>> ResendTeammateInviteByToken(string token)
        {
            return _context.ResendTeammateInviteByToken(token);
        }

        public Task<Response<SendGridResult<List<PendingTeammateInvitation>>>> PendingTeammateInvitations()
        {
            return _context.PendingTeammateInvitations();
        }

        public Task<Response<string>> DeletePendingTeammateInviteByToken(string token)
        {
            return _context.DeletePendingTeammateInviteByToken(token);
        }

        public Task<Response<TeammateInviteResult>> InviteTeammate(InviteTeammateCommand command)
        {
            return _context.InviteTeammate(command);
        }

        public Task<Response<List<Teammate>>> Teammates(TeammateListQuery query)
        {
            return _context.Teammates(query.PageSize, query.PageIndex);
        }

        public Task<Response<Teammate>> TeammateByUserName(string userName)
        {
            return _context.TeammateByUserName(userName);
        }

        public Task<Response<string>> DeleteTeammateByUserName(string userName)
        {
            return _context.DeleteTeammateByUserName(userName);
        }

        public Task<Response<TeammateWithScope>> UpdateTeammateByUserName(UpdateTeammateCommand command)
        {
            return _context.UpdateTeammateByUserName(command.UserName, command);
        }

        public Task<Response<ParseSetting>> CreateParseSetting(CreateParseSettingCommand command)
        {
            return _context.CreateParseSetting(command);
        }

        public Task<Response<SendGridResult<List<ParseSetting>>>> ParseSettings()
        {
            return _context.ParseSettings();
        }

        public Task<Response<ParseSetting>> ParseSettingByHostName(string hostName)
        {
            return _context.ParseSettingByHostName(hostName);
        }

        #region Parse Settings

        public Task<Response<ParseSetting>> UpdateParseSetting(UpdateParseSettingCommand command)
        {
            return _context.UpdateParseSetting(command.HostnameOfParseSettings, command);
        }

        #endregion

        public Task<Response<string>> DeleteParseSetting(DeleteParseSettingCommand command)
        {
            return _context.DeleteParseSetting(command.HostName);
        }

        #region Mail Settings

        public Task<Response<SendGridResult<List<MailSetting>>>> MailSettings(MailSettingListQuery query)
        {
            return _context.MailSettings(query.PageIndex, query.PageSize);
        }

        #endregion

        public Task<Response<BccSetting>> BccSetting()
        {
            return _context.BccSetting();
        }

        public Task<Response<EmailAddressWhiteListSetting>> EmailAddressWhiteListSetting()
        {
            return _context.EmailAddressWhiteListSetting();
        }

        public Task<Response<MailFooterSetting>> MailFooterSetting()
        {
            return _context.MailFooterSetting();
        }

        public Task<Response<SpamForwardingSetting>> SpamForwardingSetting()
        {
            return _context.SpamForwardingSetting();
        }

        public Task<Response<SpamCheckSetting>> SpamCheckSetting()
        {
            return _context.SpamCheckSetting();
        }

        public Task<Response<PlainContentSetting>> PlainContentSetting()
        {
            return _context.PlainContentSetting();
        }

        public Task<Response<TemplateSetting>> TemplateSetting()
        {
            return _context.TemplateSetting();
        }

        public Task<Response<BouncePurgeSetting>> BouncePurgeSetting()
        {
            return _context.BouncePurgeSetting();
        }

        public Task<Response<BounceForwardSetting>> BounceForwardSetting()
        {
            return _context.BounceForwardSetting();
        }

        public Task<Response<BccSetting>> UpdateBccSetting(UpdateBccSettingCommand command)
        {
            return _context.UpdateBccSetting(command);
        }

        public Task<Response<EmailAddressWhiteListSetting>> UpdateEmailAddressWhiteListSetting(
            UpdateEmailAddressWhiteListSettingCommand command)
        {
            return _context.UpdateEmailAddressWhiteListSetting(command);
        }

        public Task<Response<MailFooterSetting>> UpdateMailFooterSetting(UpdateMailFooterSettingCommand command)
        {
            return _context.UpdateMailFooterSetting(command);
        }

        public Task<Response<SpamForwardingSetting>> UpdateSpamForwardingSetting(
            UpdateSpamForwardingSettingCommand command)
        {
            return _context.UpdateSpamForwardingSetting(command);
        }

        public Task<Response<PlainContentSetting>> UpdatePlainContentSetting(UpdatePlainContentSettingCommand command)
        {
            return _context.UpdatePlainContentSetting(command);
        }

        public Task<Response<SpamCheckSetting>> UpdateSpamCheckSetting(UpdateSpamCheckSettingCommand command)
        {
            return _context.UpdateSpamCheckSetting(command);
        }

        public Task<Response<TemplateSetting>> UpdateTemplateSetting(UpdateTemplateSettingCommand command)
        {
            return _context.UpdateTemplateSetting(command);
        }

        public Task<Response<BouncePurgeSetting>> UpdateBouncePurgeSetting(UpdateBouncePurgeSettingCommand command)
        {
            return _context.UpdateBouncePurgeSetting(command);
        }

        public Task<Response<BounceForwardSetting>> UpdateBounceForwardSetting(
            UpdateBounceForwardSettingCommand command)
        {
            return _context.UpdateBounceForwardSetting(command);
        }

        #region Campaign

        public Task<Response<Campaign>> CreateCampaign(CreateCampaignCommand command)
        {
            return _context.CreateCampaign(command);
        }

        public Task<Response<Campaign>> UpdateCampaign(UpdateCampaignCommand command)
        {
            return _context.UpdateCampaign(command.IdOfCampaign, command);
        }

        public Task<Response<Campaign>> CampaignById(string id)
        {
            return _context.CampaignById(id);
        }

        public Task<Response<SendGridResult<List<Campaign>>>> Campaigns(CampaignListQuery option = null)
        {
            return _context.Campaigns(option?.PageSize, option?.PageIndex);
        }

        public Task<Response<string>> DeleteCampaignById(string id)
        {
            return _context.DeleteCampaignById(id);
        }

        public Task<Response<CampaignSchedule>> SendCampaignById(CampaignSendCommand command)
        {
            if (!string.IsNullOrEmpty(command.TestEmailTo))
                return _context.SendSchedulesTest(command.Id, command);

            return _context.SendCampaignById(command.Id);
        }

        #endregion

        #region Campaign Schedule

        public Task<Response<CampaignSchedule>> UpdateScheduleCampaignById(UpdateCampaignScheduleCommand command)
        {
            return _context.UpdateScheduleCampaignById(command.ScheduleCampaignId, command);
        }

        public Task<Response<CampaignSchedule>> CreateCampaignSchedule(
            CreateCampaignScheduleCommand createCampaignScheduleCommand)
        {
            return _context.CreateCampaignSchedule(createCampaignScheduleCommand.ScheduleCampaignId,
                createCampaignScheduleCommand);
        }

        public Task<Response<string>> DeleteScheduleCampaignById(string campaignId)
        {
            return _context.DeleteScheduleCampaignById(campaignId);
        }

        public Task<Response<CampaignSchedule>> CampaignScheduleByCampaignId(string campaignId)
        {
            return _context.CampaignScheduleByCampaignId(campaignId);
        }

        #endregion

        #region Alerts

        public Task<Response<Alert>> CreateAlert(CreateAlertCommand command)
        {
            return _context.CreateAlert(command);
        }

        public Task<Response<string>> DeleteAlertById(string id)
        {
            return _context.DeleteAlertById(id);
        }

        public Task<Response<Alert>> UpdateAlert(UpdateAlertCommand command)
        {
            return _context.UpdateAlert(command.IdForAlert, command);
        }

        public Task<Response<List<Alert>>> Alerts()
        {
            return _context.Alerts();
        }

        public Task<Response<Alert>> AlertById(string id)
        {
            return _context.AlertById(id);
        }

        #endregion

        #region Api Keys

        public Task<Response<SendGridResult<List<ApiKey>>>> ApiKeys(ApiKeyListQuery query = null)
        {
            return _context.ApiKeys(query?.Limit);
        }

        public Task<Response<ApiKey>> ApiKeyById(string id)
        {
            return _context.ApiKeyById(id);
        }

        public Task<Response<ApiKey>> CreateApiKey(CreateApiKeyCommand command)
        {
            return _context.CreateApiKey(command);
        }

        public Task<Response<ApiKey>> UpdateApiKey(UpdateApiKeyCommand command)
        {
            if (command.Scopes == null)
                return _context.UpdateApiKey(command.ApiKeyId, command);

            return _context.UpdateApiKeyWithScopes(command.ApiKeyId, command);
        }

        public Task<Response<string>> DeleteApiKeyById(string id)
        {
            return _context.DeleteApiKey(id);
        }

        #endregion

        #region Blocked EmailAddresses

        public Task<Response<List<EmailReport>>> BlockedEmailAddresses(
            BlockedEmailAddressListQuery option = null)
        {
            long? statime = null;
            if (option?.StartTimeTimeSpan != null)
                statime = Convert.ToInt64(option.StartTimeTimeSpan.Value.TotalSeconds);

            long? endTime = null;
            if (option?.EndTimeTimeSpan != null)
                endTime = Convert.ToInt64(option.EndTimeTimeSpan.Value.TotalSeconds);

            return _context.BlockedEmailAddresses(option?.PageSize, option?.PageIndex, statime, endTime);
        }

        public Task<Response<EmailReport>> BlockedEmailAddressByEmailAddress(string emailAddress)
        {
            return _context.BlockedEmailAddressByEmailAddress(emailAddress);
        }

        public Task<Response<string>> DeleteBlockedEmailAddress(DeleteBlockedEmailAddressCommand command)
        {
            return _context.DeleteBlockedEmailAddressByEmailAddress(command);
        }

        #endregion

        #region Bounced EmailAddresses

        public Task<Response<List<EmailReport>>> BouncedEmailAddresses(
            BouncedEmailAddressListQuery option = null)
        {
            long? statime = null;
            if (option?.StartTimeTimeSpan != null)
                statime = Convert.ToInt64(option.StartTimeTimeSpan.Value.TotalSeconds);

            long? endTime = null;
            if (option?.EndTimeTimeSpan != null)
                endTime = Convert.ToInt64(option.EndTimeTimeSpan.Value.TotalSeconds);

            return _context.BouncedEmailAddresses(statime, endTime);
        }

        public Task<Response<EmailReport>> BouncedEmailAddressByEmailAddress(string emailAddress)
        {
            return _context.BouncedEmailAddressByEmailAddress(emailAddress);
        }

        public Task<Response<string>> DeleteBouncedEmailAddress(DeleteBouncedEmailAddressCommand command)
        {
            return _context.DeleteBouncedEmailAddressByEmailAddress(command);
        }

        #endregion

        #region Invalid EmailAddresses

        public Task<Response<List<EmailReport>>> InvalidEmailAddresses(
            InvalidEmailAddressListQuery option = null)
        {
            long? statime = null;
            if (option?.StartTimeTimeSpan != null)
                statime = Convert.ToInt64(option.StartTimeTimeSpan.Value.TotalSeconds);

            long? endTime = null;
            if (option?.EndTimeTimeSpan != null)
                endTime = Convert.ToInt64(option.EndTimeTimeSpan.Value.TotalSeconds);

            return _context.InvalidEmailAddresses(option?.PageSize, option?.PageIndex, statime, endTime);
        }

        public Task<Response<EmailReport>> InvalidEmailAddressByEmailAddress(string emailAddress)
        {
            return _context.InvalidEmailAddressByEmailAddress(emailAddress);
        }

        public Task<Response<string>> DeleteInvalidEmailAddress(DeleteInvalidEmailAddressCommand command)
        {
            return _context.DeleteInvalidEmailAddressByEmailAddress(command);
        }

        #endregion

        #region SpamReported EmailAddresses

        public Task<Response<List<SpamReportedEmailAddress>>> SpamReportedEmailAddresses(
            SpamReportedEmailAddressListQuery option = null)
        {
            long? statime = null;
            if (option?.StartTimeTimeSpan != null)
                statime = Convert.ToInt64(option.StartTimeTimeSpan.Value.TotalSeconds);

            long? endTime = null;
            if (option?.EndTimeTimeSpan != null)
                endTime = Convert.ToInt64(option.EndTimeTimeSpan.Value.TotalSeconds);

            return _context.SpamReportedEmailAddresses(option?.PageSize, option?.PageIndex, statime, endTime);
        }

        public Task<Response<SpamReportedEmailAddress>> SpamReportedEmailAddressByEmailAddress(string emailAddress)
        {
            return _context.SpamReportedEmailAddressByEmailAddress(emailAddress);
        }

        public Task<Response<string>> DeleteSpamReportedEmailAddress(DeleteSpamReportedEmailAddressCommand command)
        {
            return _context.DeleteSpamReportedEmailAddressByEmailAddress(command);
        }

        #endregion

        #region Monitor Settings

        public Task<Response<string>> DeleteMonitorSettingByUserName(string subUserName)
        {
            return _context.DeleteMonitorSettingByUserName(subUserName);
        }

        public Task<Response<MonitorSetting>> MonitorSettingBySubUserName(string subUserName)
        {
            return _context.MonitorSettingBySubUserName(subUserName);
        }

        public Task<Response<MonitorSetting>> UpdateMonitorSettingByUserName(string subUserName,
            UpdateMonitorSettingCommand monitorSetting)
        {
            return _context.UpdateMonitorSettingBySubUserName(subUserName, monitorSetting);
        }

        #endregion

        #region SubUser

        public Task<Response<string>> EnableOrDisableSubUser(string subUserName, bool isDisabled)
        {
            return _context.EnableOrDisableSubUser(subUserName, new { disabled = isDisabled });
        }

        public Task<Response<List<SubUser>>> SubUsers(
            SubUserListQuery option = null)
        {
            return _context.SubUsers(option?.PageSize, option?.PageIndex, option?.SubUserName);
        }

        public Task<Response<SubUser>> CreateSubUser(CreateSubUserCommand command)
        {
            return _context.CreateSubUser(command);
        }

        public Task<Response<SubUser>> UpdateSubUser(SubUser command)
        {
            return _context.UpdateSubUser(command.Id, command);
        }

        public Task<Response<string>> DeleteSubUserById(string id)
        {
            return _context.DeleteSubUserById(id);
        }

        #endregion

        #region UserProfile

        public Task<Response<UserProfile>> UserProfile()
        {
            return _context.UserProfile();
        }

        public Task<Response<UserAccount>> UserAccount()
        {
            return _context.UserAccount();
        }

        public Task<Response<UserEmailAddress>> UserEmailAddress()
        {
            return _context.UserEmailAddress();
        }

        public Task<Response<User>> User()
        {
            return _context.User();
        }

        public Task<Response<UserCredit>> UserCredit()
        {
            return _context.UserCredit();
        }

        public Task<Response<UserProfile>> UpdateUserProfile(UpdateUserProfileCommand command)
        {
            return _context.UpdateUserProfile(command);
        }

        public Task<Response<UserEmailAddress>> UpdateUserEmailAddress(UpdateUserEmailAddressCommand command)
        {
            return _context.UpdateUserEmailAddress(command);
        }

        public Task<Response<User>> UpdateUserName(UpdateUserNameCommand command)
        {
            return _context.UpdateUserName(command);
        }

        #endregion

        #region Sender Identities

        public Task<Response<string>> UpdateUserPassword(UpdateUserPasswordCommand command)
        {
            return _context.UpdateUserPassword(command);
        }

        public Task<Response<SenderIdentity>> UpdateSenderIdentity(UpdateSenderIdentityCommand command)
        {
            return _context.UpdateSenderIdentity(command.Id, command);
        }

        public Task<Response<string>> DeleteSenderIdentityById(string id)
        {
            return _context.DeleteSenderIdentity(id);
        }

        public Task<Response<string>> ResendVerificationSenderIdentityById(string id)
        {
            return _context.ResendVerificationSenderIdentityById(id);
        }

        public Task<Response<SendGridResult<List<SenderIdentity>>>> SenderIdentities()
        {
            return _context.SenderIdentities();
        }

        public Task<Response<SenderIdentity>> SenderIdentityById(string id)
        {
            return _context.SenderIdentityById(id);
        }

        public Task<Response<SenderIdentity>> CreateSenderIdentity(CreateSenderIdentityCommand command)
        {
            return _context.CreateSenderIdentity(command);
        }

        #endregion

        #region Ip Warmups

        public Task<Response<IpWarmup>> IpWarmupByIpAddress(string ipAddress)
        {
            return _context.IpWarmupByIpAddress(ipAddress);
        }

        public Task<Response<List<IpWarmup>>> IpWarmups()
        {
            return _context.IpWarmups();
        }

        public Task<Response<IpWarmup>> CreateIpWarmup(CreateIpWarmupCommand command)
        {
            return _context.CreateIpWarmup(command);
        }

        public Task<Response<string>> DeleteIpWarmupById(string ipAddress)
        {
            return _context.DeleteIpWarmup(ipAddress);
        }

        #endregion

        #region Ip Pool

        public Task<Response<IpPool>> CreateIpPool(CreateIpPoolCommand command)
        {
            return _context.CreateIpPool(command);
        }

        public Task<Response<IpPool>> UpdateIpPool(UpdateIpPoolCommand command)
        {
            return _context.UpdateIpPool(command.OldName, command);
        }

        public Task<Response<string>> DeleteIpPoolByName(string name)
        {
            return _context.DeleteIpPoolByName(name);
        }

        public Task<Response<IpAddress>> AddIpAddressToPool(AddIpAddressToPoolCommand command)
        {
            return _context.AddIpAddressToPool(command.IpPoolName, command);
        }

        public Task<Response<IpPool>> IpPoolByName(string name)
        {
            return _context.IpPoolByName(name);
        }

        public Task<Response<List<IpPool>>> IpPools()
        {
            return _context.IpPools();
        }

        public Task<Response<string>> RemoveIpAddressFromPool(RemoveIpAddressFromPoolCommand command)
        {
            return _context.RemoveIpAddressFromPool(command.IpPoolName, command.IpAddressToRemove);
        }

        #endregion

        #region Ip Management

        public Task<Response<SendGridResult<List<IpAccessManagementSettingActivity>>>>
            IpAccessManagementSettingActivities(IpAccessManagementSettingActivityListQuery command)
        {
            return _context.IpAccessManagementSettingActivities(command.Limit);
        }

        public Task<Response<SendGridResult<List<WhiteListedIpAddress>>>> WhiteListedIpAddresses()
        {
            return _context.WhiteListedIpAddresses();
        }

        public Task<Response<WhiteListedIpAddress>> WhiteListedIpAddressById(string id)
        {
            return _context.WhiteListedIpAddressById(id);
        }

        public Task<Response<List<WhiteListedIpAddress>>> AddWhiteListedIpAddress(
            AddWhiteListedIpAddressCommand command)
        {
            return _context.AddWhiteListedIpAddress(command);
        }

        public Task<Response<string>> RemoveWhiteListedIpAddress(RemoveWhiteListedIpAddressCommand command)
        {
            return _context.RemoveWhiteListedIpAddress(command);
        }

        #endregion

        #region Branded Links

        public Task<Response<List<BrandedLink>>> BrandedLinks(BrandedLinkListQuery query)
        {
            return _context.BrandedLinks(query.Limit);
        }

        public Task<Response<BrandedLink>> BrandedLinkById(string id)
        {
            return _context.BrandedLinkById(id);
        }

        public Task<Response<BrandedLink>> DefaultBrandedLink(string domainUrl)
        {
            return _context.DefaultBrandedLink(domainUrl);
        }

        public Task<Response<BrandedLink>> CreateBrandedLink(CreateBrandedLinkCommand command)
        {
            return _context.CreateBrandedLink(command);
        }

        public Task<Response<BrandedLink>> UpdateBrandedLink(UpdateBrandedLinkCommand command)
        {
            return _context.UpdateBrandedLink(command.Id, command);
        }

        public Task<Response<string>> DeleteBrandedLinkById(string id)
        {
            return _context.DeleteBrandedLink(id);
        }

        public Task<Response<BrandedLinkValidationResult>> ValidateBrandedLinkById(string id)
        {
            return _context.ValidateBrandedLinkById(id);
        }

        public Task<Response<BrandedLink>> BrandedLinksForSubuser(string subUserName)
        {
            return _context.BrandedlinksForSubuser(subUserName);
        }

        public Task<Response<string>> DisassociateBrandedForSubUser(string userName)
        {
            return _context.DisassociateBrandedForSubUser(userName);
        }

        public Task<Response<string>> AssociateBrandedForSubUser(AssociateBrandedForSubUserCommand command)
        {
            return _context.AssociateBrandedForSubUser(command.Id, command);
        }

        #endregion

        #region Authtenticted Domains

        public Task<Response<List<AuthenticatedDomain>>> AuthenticatedDomains(AuthenticatedDomainListQuery query)
        {
            return _context.AuthtenticatedDomains(query.PageIndex, query.PageSize, query.AuthenticatedDomain,
                query.ShouldExcludeSubUsers, query.UserName);
        }

        public Task<Response<AuthenticatedDomain>> AuthenticateToDomain(DomainAuthenticate model)
        {
            return _context.AuthenticateToDomain(model);
        }

        public Task<Response<AuthenticatedDomain>> AuthenticatedDomainById(string id)
        {
            return _context.AuthtenticatedDomainById(id);
        }

        public Task<Response<AuthenticatedDomainSetting>> UpdateAuthenticatedDomainSetting(
            UpdateAuthenticatedDomainSettingCommand command)
        {
            return _context.UpdateAuthenticatedDomainSetting(command.Id, command);
        }

        public Task<Response<string>> DeleteAuthenticatedDomainById(string id)
        {
            return _context.DeleteAuthenticatedDomainById(id);
        }

        public Task<Response<AuthenticatedDomain>> DefaultAuthenticatedDomainByDomain()
        {
            return _context.DefaultAuthenticatedDomainByDomain();
        }

        public Task<Response<AuthenticatedDomain>> AddIpAddressToAuthenticatedDomain(
            AddIpAddressToAuthenticatedDomainCommand command)
        {
            return _context.AddIpAddressToAuthenticatedDomain(command.AuthenticatedDomainId, command);
        }

        public Task<Response<AuthenticatedDomain>> RemoveIpAddressFromAuthenticatedDomain(
            RemoveIpAddressFromAuthenticatedDomainCommand command)
        {
            return _context.RemoveIpAddressFromAuthenticatedDomain(command.AuthenticatedDomainId,
                command.IpAddressToRemove);
        }

        public Task<Response<AuthenticatedDomainValidation>> ValidateAuthenticatedDomainById(string id)
        {
            return _context.ValidateAuthenticatedDomainById(id);
        }

        public Task<Response<List<AuthenticatedDomain>>> AuthenticatedDomainsForSubUser(
            AuthenticatedDomainListForSubuserQuery query)
        {
            return _context.AuthenticatedDomainsForSubUser();
        }

        public Task<Response<string>> DisassociateSubuserFromAuthenticatedDomain()
        {
            return _context.DisassociateSubuserFromAuthenticatedDomain();
        }

        public Task<Response<AuthenticatedDomain>> AssociateSubuserToAuthenticatedDomain(
            AssociateSubuserToAuthenticatedDomainCommand command)
        {
            return _context.AssociateSubuserToAuthenticatedDomain(command.AssociateWithDomainId, command);
        }

        #endregion

        #region Tls Setting

        public Task<Response<EnforcedTls>> EnforcedTls()
        {
            return _context.EnforcedTls();
        }

        public Task<Response<EnforcedTls>> UpdateEnforcedTls(UpdateEnforcedTlsCommand command)
        {
            return _context.UpdateEnforcedTls(command);
        }

        #endregion
    }
}