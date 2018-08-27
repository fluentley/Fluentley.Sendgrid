using System;
using System.Collections.Generic;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Alerts.Commands;
using Fluentley.SendGrid.Operations.Alerts.Models;
using Fluentley.SendGrid.Operations.Alerts.Queries;
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
using Fluentley.SendGrid.Operations.CampaignSchedules.Queries;
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
using Fluentley.SendGrid.Operations.IpAddresses.Models;
using Fluentley.SendGrid.Operations.IpAddresses.Queries;
using Fluentley.SendGrid.Operations.IpPools.Commands;
using Fluentley.SendGrid.Operations.IpPools.Models;
using Fluentley.SendGrid.Operations.IpPools.Queries;
using Fluentley.SendGrid.Operations.IpWarmups.Commands;
using Fluentley.SendGrid.Operations.IpWarmups.Models;
using Fluentley.SendGrid.Operations.IpWarmups.Queries;
using Fluentley.SendGrid.Operations.LinkBrandings.Commands;
using Fluentley.SendGrid.Operations.LinkBrandings.Models;
using Fluentley.SendGrid.Operations.LinkBrandings.Queries;
using Fluentley.SendGrid.Operations.MonitorSettings.Commands;
using Fluentley.SendGrid.Operations.MonitorSettings.Models;
using Fluentley.SendGrid.Operations.MonitorSettings.Queries;
using Fluentley.SendGrid.Operations.Reputations.Models;
using Fluentley.SendGrid.Operations.Reputations.Queries;
using Fluentley.SendGrid.Operations.ReverseDnses.Commands;
using Fluentley.SendGrid.Operations.ReverseDnses.Models;
using Fluentley.SendGrid.Operations.ReverseDnses.Queries;
using Fluentley.SendGrid.Operations.SenderIdentities.Commands;
using Fluentley.SendGrid.Operations.SenderIdentities.Models;
using Fluentley.SendGrid.Operations.SenderIdentities.Queries;
using Fluentley.SendGrid.Operations.SettingEnforcedTls.Commands;
using Fluentley.SendGrid.Operations.SettingEnforcedTls.Models;
using Fluentley.SendGrid.Operations.SettingEnforcedTls.Queries;
using Fluentley.SendGrid.Operations.SettingInboundParse.Commands;
using Fluentley.SendGrid.Operations.SettingInboundParse.Models;
using Fluentley.SendGrid.Operations.SettingInboundParse.Queries;
using Fluentley.SendGrid.Operations.SettingMail.Commands;
using Fluentley.SendGrid.Operations.SettingMail.Models;
using Fluentley.SendGrid.Operations.SettingMail.Queries;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Commands;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Models;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Queries;
using Fluentley.SendGrid.Operations.Statistics.Models;
using Fluentley.SendGrid.Operations.Statistics.Queries;
using Fluentley.SendGrid.Operations.SubUsers.Commands;
using Fluentley.SendGrid.Operations.SubUsers.Models;
using Fluentley.SendGrid.Operations.SubUsers.Queries;
using Fluentley.SendGrid.Operations.Teammates.Commands;
using Fluentley.SendGrid.Operations.Teammates.Models;
using Fluentley.SendGrid.Operations.Teammates.Queries;
using Fluentley.SendGrid.Operations.Users.Commands;
using Fluentley.SendGrid.Operations.Users.Models;
using Fluentley.SendGrid.Operations.Users.Queries;
using Fluentley.SendGrid.Operations.Webhooks.Commands;
using Fluentley.SendGrid.Operations.Webhooks.Models;
using Fluentley.SendGrid.Operations.Webhooks.Queries;
using Fluentley.SendGrid.Processors;
using User = Fluentley.SendGrid.Operations.Users.Models.User;

namespace Fluentley.SendGrid
{
    public class SendGridService
    {
        private readonly OptionProcessor _optionProcessor;

        public SendGridService(string apiKey)
        {
            _optionProcessor = new OptionProcessor(apiKey);
        }

        #region Email Statistics

        public IQuery<List<EmailStatistic>> EmailStatistics(Action<IEmailStatisticsListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IEmailStatisticsListQuery, EmailStatisticsListQuery>(queryAction);
        }

        #endregion

        #region Reputation

        public IQuery<List<Reputation>> Reputations(Action<IReputationListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IReputationListQuery, ReputationListQuery>(queryAction);
        }

        #endregion

        #region Categories

        public IQuery<List<Category>> Categories(Action<ICategoryListQuery> queryAction = null)
        {
            return _optionProcessor.Process<ICategoryListQuery, CategoryListQuery>(queryAction);
        }

        #endregion

        #region Send CName To Coworker

        public ICommand<SendDnsInformationResult> SendGeneratedDnsInformation(
            Action<ISendGeneratedDnsInformationCommand> commandAction)
        {
            return _optionProcessor
                    .Process<ISendGeneratedDnsInformationCommand, SendGeneratedDnsInformationCommand>(commandAction);
        }

        #endregion

        #region Send Email

        public ICommand<string> SendEmail(Action<ISendEmailCommand> commandAction = null)
        {
            return _optionProcessor.Process<ISendEmailCommand, SendEmailCommand>(commandAction);
        }

        #endregion

        #region Alerts

        public IQuery<List<Alert>> Alerts(Action<IAlertListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IAlertListQuery, AlertListQuery>(queryAction);
        }

        public IQuery<Alert> AlertById(Action<IAlertSingleQuery> queryAction)
        {
            return _optionProcessor.Process<IAlertSingleQuery, AlertSingleQuery>(queryAction);
        }

        public ICommand<Alert> CreateAlert(Action<ICreateAlertCommand> commandAction)
        {
            return _optionProcessor.Process<ICreateAlertCommand, CreateAlertCommand>(commandAction);
        }

        public ICommand<Alert> UpdateAlert(Action<IUpdateAlertCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateAlertCommand, UpdateAlertCommand>(commandAction);
        }

        public ICommand<string> DeleteAlert(Action<IDeleteAlertCommand> commandAction)
        {
            return _optionProcessor.Process<IDeleteAlertCommand, DeleteAlertCommand>(commandAction);
        }

        #endregion

        #region ApiKeys

        public IQuery<List<ApiKey>> ApiKeys(Action<IApiKeyListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IApiKeyListQuery, ApiKeyListQuery>(queryAction);
        }

        public IQuery<ApiKey> ApiKeyById(Action<IApiKeySingleQuery> queryAction)
        {
            return _optionProcessor.Process<IApiKeySingleQuery, ApiKeySingleQuery>(queryAction);
        }

        public ICommand<ApiKey> CreateApiKey(Action<ICreateApiKeyCommand> commandAction)
        {
            return _optionProcessor.Process<ICreateApiKeyCommand, CreateApiKeyCommand>(commandAction);
        }

        public ICommand<ApiKey> UpdateApiKey(Action<IUpdateApiKeyCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateApiKeyCommand, UpdateApiKeyCommand>(commandAction);
        }

        public ICommand<string> DeleteApiKey(Action<IDeleteApiKeyCommand> commandAction)
        {
            return _optionProcessor.Process<IDeleteApiKeyCommand, DeleteApiKeyCommand>(commandAction);
        }

        #endregion

        #region Blocked EmailAddresses

        public IQuery<List<EmailReport>> BlockedEmailAddresses(
            Action<IBlockedEmailAddressListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IBlockedEmailAddressListQuery, BlockedEmailAddressListQuery>(queryAction);
        }

        public IQuery<EmailReport> BlockedEmailAddressById(Action<IBlockedEmailAddressSingleQuery> queryAction)
        {
            return _optionProcessor.Process<IBlockedEmailAddressSingleQuery, BlockedEmailAddressSingleQuery>(queryAction);
        }

        public ICommand<string> DeleteBlockedEmailAddress(Action<IDeleteBlockedEmailAddressCommand> commandAction)
        {
            return _optionProcessor.Process<IDeleteBlockedEmailAddressCommand, DeleteBlockedEmailAddressCommand>(commandAction);
        }

        #endregion

        #region Bounced EmailAddresses

        public IQuery<List<EmailReport>> BouncedEmailAddresses(
            Action<IBouncedEmailAddressListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IBouncedEmailAddressListQuery, BouncedEmailAddressListQuery>(queryAction);
        }

        public IQuery<EmailReport> BouncedEmailAddressById(Action<IBouncedEmailAddressSingleQuery> queryAction)
        {
            return _optionProcessor.Process<IBouncedEmailAddressSingleQuery, BouncedEmailAddressSingleQuery>(queryAction);
        }

        public ICommand<string> DeleteBouncedEmailAddress(Action<IDeleteBouncedEmailAddressCommand> commandAction)
        {
            return _optionProcessor
                .Process<IDeleteBouncedEmailAddressCommand, DeleteBouncedEmailAddressCommand>(commandAction);
        }

        #endregion

        #region Spam Reported EmailAddresses

        public IQuery<List<SpamReportedEmailAddress>> SpamReportedEmailAddresses(
            Action<ISpamReportedEmailAddressListQuery> queryAction = null)
        {
            return _optionProcessor
                .Process<ISpamReportedEmailAddressListQuery, SpamReportedEmailAddressListQuery>(queryAction);
        }

        public IQuery<SpamReportedEmailAddress> SpamReportedEmailAddressById(
            Action<ISpamReportedEmailAddressSingleQuery> queryAction)
        {
            return _optionProcessor
                    .Process<ISpamReportedEmailAddressSingleQuery, SpamReportedEmailAddressSingleQuery>(queryAction);
        }

        public ICommand<string> DeleteSpamReportedEmailAddress(
            Action<IDeleteSpamReportedEmailAddressCommand> commandAction)
        {
            return _optionProcessor
                    .Process<IDeleteSpamReportedEmailAddressCommand, DeleteSpamReportedEmailAddressCommand>(
                        commandAction);
        }

        #endregion

        #region InvalidEmailAddresss

        public IQuery<List<EmailReport>> InvalidEmailAddresses(
            Action<IInvalidEmailAddressListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IInvalidEmailAddressListQuery, InvalidEmailAddressListQuery>(queryAction);
        }

        public IQuery<EmailReport> InvalidEmailAddressById(Action<IInvalidEmailAddressSingleQuery> queryAction)
        {
            return _optionProcessor
                .Process<IInvalidEmailAddressSingleQuery, InvalidEmailAddressSingleQuery>(queryAction);
        }

        public ICommand<string> DeleteInvalidEmailAddress(Action<IDeleteInvalidEmailAddressCommand> commandAction)
        {
            return _optionProcessor
                .Process<IDeleteInvalidEmailAddressCommand, DeleteInvalidEmailAddressCommand>(commandAction);
        }

        #endregion

        #region Monitor Settings

        public IQuery<MonitorSetting> MonitorSetting(Action<IMonitorSettingSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<IMonitorSettingSingleQuery, MonitorSettingSingleQuery>(queryAction);
        }

        public ICommand<MonitorSetting> UpdateMonitorSetting(Action<IUpdateMonitorSettingCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateMonitorSettingCommand, UpdateMonitorSettingCommand>(commandAction);
        }

        public ICommand<string> DeleteMonitorSetting(Action<IDeleteMonitorSettingCommand> commandAction)
        {
            return _optionProcessor.Process<IDeleteMonitorSettingCommand, DeleteMonitorSettingCommand>(commandAction);
        }

        #endregion

        #region Campaigns

        public IQuery<List<Campaign>> Campaigns(Action<ICampaignListQuery> queryAction = null)
        {
            return _optionProcessor.Process<ICampaignListQuery, CampaignListQuery>(queryAction);
        }

        public IQuery<Campaign> CampaignById(Action<ICampaignSingleQuery> queryAction)
        {
            return _optionProcessor.Process<ICampaignSingleQuery, CampaignSingleQuery>(queryAction);
        }

        public ICommand<Campaign> CreateCampaign(Action<ICreateCampaignCommand> commandAction)
        {
            return _optionProcessor.Process<ICreateCampaignCommand, CreateCampaignCommand>(commandAction);
        }

        public ICommand<Campaign> UpdateCampaign(Action<IUpdateCampaignCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateCampaignCommand, UpdateCampaignCommand>(commandAction);
        }

        public ICommand<CampaignSchedule> SendCampaign(Action<ICampaignSendCommand> commandAction)
        {
            return _optionProcessor.Process<ICampaignSendCommand, CampaignSendCommand>(commandAction);
        }

        public ICommand<string> DeleteCampaign(Action<IDeleteCampaignCommand> commandAction)
        {
            return _optionProcessor.Process<IDeleteCampaignCommand, DeleteCampaignCommand>(commandAction);
        }

        #endregion

        #region Campaign Schedules

        public IQuery<CampaignSchedule> CampaignScheduleByCampaignId(
            Action<ICampaignScheduleSingleQuery> queryAction)
        {
            return _optionProcessor.Process<ICampaignScheduleSingleQuery, CampaignScheduleSingleQuery>(queryAction);
        }

        public ICommand<CampaignSchedule> CreateCampaignSchedule(
            Action<ICreateCampaignScheduleCommand> commandAction)
        {
            return _optionProcessor
                .Process<ICreateCampaignScheduleCommand, CreateCampaignScheduleCommand>(commandAction);
        }

        public ICommand<CampaignSchedule> UpdateCampaignSchedule(
            Action<IUpdateCampaignScheduleCommand> commandAction)
        {
            return _optionProcessor
                .Process<IUpdateCampaignScheduleCommand, UpdateCampaignScheduleCommand>(commandAction);
        }

        public ICommand<string> DeleteCampaignSchedule(Action<IDeleteCampaignScheduleCommand> commandAction)
        {
            return _optionProcessor
                .Process<IDeleteCampaignScheduleCommand, DeleteCampaignScheduleCommand>(commandAction);
        }

        #endregion

        #region Subuser

        public IQuery<List<SubUser>> SubUsers(Action<ISubUserListQuery> queryAction = null)
        {
            return _optionProcessor.Process<ISubUserListQuery, SubUserListQuery>(queryAction);
        }

        public ICommand<SubUser> CreateSubUser(Action<ICreateSubUserCommand> queryAction = null)
        {
            return _optionProcessor.Process<ICreateSubUserCommand, CreateSubUserCommand>(queryAction);
        }

        public ICommand<SubUser> UpdateSubUser(Action<IUpdateSubUserCommand> queryAction = null)
        {
            return _optionProcessor.Process<IUpdateSubUserCommand, UpdateSubUserCommand>(queryAction);
        }

        public ICommand<string> DeleteSubUser(Action<IDeleteSubUserCommand> queryAction = null)
        {
            return _optionProcessor.Process<IDeleteSubUserCommand, DeleteSubUserCommand>(queryAction);
        }

        public ICommand<string> EnableOrDisableSubUser(Action<IEnableOrDisableSubUserCommand> queryAction = null)
        {
            return _optionProcessor.Process<IEnableOrDisableSubUserCommand, EnableOrDisableSubUserCommand>(queryAction);
        }

        #endregion

        #region User

        public IQuery<User> User(Action<IUserSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<IUserSingleQuery, UserSingleQuery>(queryAction);
        }

        public IQuery<UserAccount> UserAccount(Action<IUserAccountSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<IUserAccountSingleQuery, UserAccountSingleQuery>(queryAction);
        }

        public IQuery<UserProfile> UserProfile(Action<IUserProfileSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<IUserProfileSingleQuery, UserProfileSingleQuery>(queryAction);
        }

        public IQuery<UserCredit> UserCredit(Action<IUserCreditSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<IUserCreditSingleQuery, UserCreditSingleQuery>(queryAction);
        }

        public IQuery<UserEmailAddress> UserEmailAddress(Action<IUserEmailAddressSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<IUserEmailAddressSingleQuery, UserEmailAddressSingleQuery>(queryAction);
        }

        public ICommand<UserEmailAddress> UpdateUserEmailAddress(Action<IUpdateUserEmailAddressCommand> command)
        {
            return _optionProcessor.Process<IUpdateUserEmailAddressCommand, UpdateUserEmailAddressCommand>(command);
        }

        public ICommand<UserProfile> UpdateUserProfile(Action<IUpdateUserProfileCommand> command)
        {
            return _optionProcessor.Process<IUpdateUserProfileCommand, UpdateUserProfileCommand>(command);
        }

        public ICommand<string> UpdateUserPassword(Action<IUpdateUserPasswordCommand> command)
        {
            return _optionProcessor.Process<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>(command);
        }

        #endregion

        #region Sender Identities

        public IQuery<List<SenderIdentity>> SenderIdentities(Action<ISenderIdentityListQuery> queryAction = null)
        {
            return _optionProcessor.Process<ISenderIdentityListQuery, SenderIdentityListQuery>(queryAction);
        }

        public IQuery<SenderIdentity> SenderIdentityById(Action<ISenderIdentitySingleQuery> queryAction)
        {
            return _optionProcessor.Process<ISenderIdentitySingleQuery, SenderIdentitySingleQuery>(queryAction);
        }

        public ICommand<SenderIdentity> CreateSenderIdentity(Action<ICreateSenderIdentityCommand> commandAction)
        {
            return _optionProcessor.Process<ICreateSenderIdentityCommand, CreateSenderIdentityCommand>(commandAction);
        }

        public ICommand<SenderIdentity> UpdateSenderIdentity(Action<IUpdateSenderIdentityCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateSenderIdentityCommand, UpdateSenderIdentityCommand>(commandAction);
        }

        public ICommand<string> DeleteSenderIdentity(Action<IDeleteSenderIdentityCommand> commandAction)
        {
            return _optionProcessor.Process<IDeleteSenderIdentityCommand, DeleteSenderIdentityCommand>(commandAction);
        }

        public ICommand<string> ResendVerificationSenderIdentity(
            Action<IResendVerificationSenderIdentityCommand> commandAction)
        {
            return _optionProcessor
                .Process<IResendVerificationSenderIdentityCommand, ResendVerificationSenderIdentityCommand>(
                    commandAction);
        }

        #endregion

        #region Ip Warmup

        public IQuery<List<IpWarmup>> IpWarmups(Action<IIpWarmupListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IIpWarmupListQuery, IpWarmupListQuery>(queryAction);
        }

        public IQuery<IpWarmup> IpWarmupById(Action<IIpWarmupSingleQuery> queryAction)
        {
            return _optionProcessor.Process<IIpWarmupSingleQuery, IpWarmupSingleQuery>(queryAction);
        }

        public ICommand<IpWarmup> CreateIpWarmup(Action<ICreateIpWarmupCommand> commandAction)
        {
            return _optionProcessor.Process<ICreateIpWarmupCommand, CreateIpWarmupCommand>(commandAction);
        }

        public ICommand<string> RemoveAnIpFromWarmup(Action<IDeleteIpWarmupCommand> commandAction)
        {
            return _optionProcessor.Process<IDeleteIpWarmupCommand, DeleteIpWarmupCommand>(commandAction);
        }

        #endregion

        #region IpPools

        public IQuery<List<IpPool>> IpPools(Action<IIpPoolListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IIpPoolListQuery, IpPoolListQuery>(queryAction);
        }

        public IQuery<IpPool> IpAddressByIpPool(Action<IIpPoolSingleQuery> queryAction)
        {
            return _optionProcessor.Process<IIpPoolSingleQuery, IpPoolSingleQuery>(queryAction);
        }

        public ICommand<IpPool> CreateIpPool(Action<ICreateIpPoolCommand> commandAction)
        {
            return _optionProcessor.Process<ICreateIpPoolCommand, CreateIpPoolCommand>(commandAction);
        }

        public ICommand<IpAddress> AddIpAddressToPool(Action<IAddIpAddressToPoolCommand> commandAction)
        {
            return _optionProcessor.Process<IAddIpAddressToPoolCommand, AddIpAddressToPoolCommand>(commandAction);
        }

        public ICommand<string> RemoveIpAddressFromPool(Action<IRemoveIpAddressFromPoolCommand> commandAction)
        {
            return _optionProcessor.Process<IRemoveIpAddressFromPoolCommand, RemoveIpAddressFromPoolCommand>(commandAction);
        }

        public ICommand<IpPool> UpdateIpPool(Action<IUpdateIpPoolCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateIpPoolCommand, UpdateIpPoolCommand>(commandAction);
        }

        public ICommand<string> DeleteIpPool(Action<IDeleteIpPoolCommand> commandAction)
        {
            return _optionProcessor.Process<IDeleteIpPoolCommand, DeleteIpPoolCommand>(commandAction);
        }

        #endregion

        #region Webhooks

        public IQuery<List<WebhookParseSettings>> WebhookParseSettings(
            Action<IWebhookParseSettingsListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IWebhookParseSettingsListQuery, WebhookParseSettingsListQuery>(queryAction);
        }

        public IQuery<List<WebhookParseStatistics>> WebhookParseStatistics(
            Action<IWebhookParseStatisticsListQuery> queryAction = null)
        {
            return _optionProcessor
                .Process<IWebhookParseStatisticsListQuery, WebhookParseStatisticsListQuery>(queryAction);
        }

        public IQuery<WebhookSettings> WebhookSettingsSingleQuery(
            Action<IWebhookSettingsSingleQuery> queryAction)
        {
            return _optionProcessor.Process<IWebhookSettingsSingleQuery, WebhookSettingsSingleQuery>(queryAction);
        }

        public ICommand<string> SendTestWebhookEvent(Action<ISendTestWebhookEventCommand> commandAction)
        {
            return _optionProcessor.Process<ISendTestWebhookEventCommand, SendTestWebhookEventCommand>(commandAction);
        }

        public ICommand<WebhookSettings> UpdateWebhookSettings(Action<IUpdateWebHookSettingsCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateWebHookSettingsCommand, UpdateWebHookSettingsCommand>(commandAction);
        }

        #endregion

        #region Ip Addresses

        public IQuery<List<AssignedIpAddress>> AssignedIpAddresses(
            Action<IAssignedIpAddressListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IAssignedIpAddressListQuery, AssignedIpAddressListQuery>(queryAction);
        }

        public IQuery<List<IpAddress>> IpAddresses(Action<IIpAddressListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IIpAddressListQuery, IpAddressListQuery>(queryAction);
        }

        public IQuery<List<RemainingIpAddress>> RemaningIpAddresses(
            Action<IRemainingIpAddressListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IRemainingIpAddressListQuery, RemainingIpAddressListQuery>(queryAction);
        }

        public IQuery<IpAddress> IpAddress(Action<IIpAddressSingleQuery> queryAction)
        {
            return _optionProcessor.Process<IIpAddressSingleQuery, IpAddressSingleQuery>(queryAction);
        }

        public ICommand<AddIpResult> AddIpAddress(Action<IAddIpAddressCommand> commandAction)
        {
            return _optionProcessor.Process<IAddIpAddressCommand, AddIpAddressCommand>(commandAction);
        }

        #endregion

        #region Ip Access Management

        public ICommand<List<WhiteListedIpAddress>> AddWhiteListedIpAddress(
            Action<IAddWhiteListedIpAddressCommand> commandAction)
        {
            return _optionProcessor
                .Process<IAddWhiteListedIpAddressCommand, AddWhiteListedIpAddressCommand>(commandAction);
        }

        public ICommand<string> RemoveWhiteListedIpAddress(Action<IRemoveWhiteListedIpAddressCommand> commandAction)
        {
            return _optionProcessor
                    .Process<IRemoveWhiteListedIpAddressCommand, RemoveWhiteListedIpAddressCommand>(commandAction);
        }

        public IQuery<List<IpAccessManagementSettingActivity>> IpAccessManagementSettingActivity(
            Action<IIpAccessManagementSettingActivityListQuery> queryAction = null)
        {
            return _optionProcessor
                .Process<IIpAccessManagementSettingActivityListQuery, IpAccessManagementSettingActivityListQuery
                >(queryAction);
        }

        public IQuery<List<WhiteListedIpAddress>> WhiteListedIpAddressList(
            Action<IWhiteListedIpAddressListQuery> queryAction = null)
        {
            return _optionProcessor
                .Process<IWhiteListedIpAddressListQuery, WhiteListedIpAddressListQuery
                >(queryAction);
        }

        public IQuery<WhiteListedIpAddress> WhiteListedIpAddressSingle(
            Action<IWhiteListedIpAddressSingleQuery> queryAction = null)
        {
            return _optionProcessor
                .Process<IWhiteListedIpAddressSingleQuery, WhiteListedIpAddressSingleQuery
                >(queryAction);
        }

        #endregion

        #region Branded Links

        public IQuery<List<BrandedLink>> BrandedLinks(
            Action<IBrandedLinkListQuery> queryAction = null)
        {
            return _optionProcessor
                .Process<IBrandedLinkListQuery, BrandedLinkListQuery
                >(queryAction);
        }

        public IQuery<BrandedLink> DefaultBrandedLink(Action<IDefaultBrandedLinkSingleQuery> queryAction)
        {
            return _optionProcessor.Process<IDefaultBrandedLinkSingleQuery, DefaultBrandedLinkSingleQuery>(queryAction);
        }

        public IQuery<BrandedLink> BrandedLink(Action<IBrandedLinkSingleQuery> queryAction)
        {
            return _optionProcessor.Process<IBrandedLinkSingleQuery, BrandedLinkSingleQuery>(queryAction);
        }

        public IQuery<BrandedLink> BrandedLinkForSubuser(Action<IBrandedLinkForSubuserSingleQuery> queryAction)
        {
            return _optionProcessor
                .Process<IBrandedLinkForSubuserSingleQuery, BrandedLinkForSubuserSingleQuery>(queryAction);
        }

        public ICommand<BrandedLink> CreateBrandedLink(Action<ICreateBrandedLinkCommand> commandAction)
        {
            return _optionProcessor.Process<ICreateBrandedLinkCommand, CreateBrandedLinkCommand>(commandAction);
        }

        public ICommand<string> DeleteBrandedLink(Action<IDeleteBrandedLinkCommand> commandAction)
        {
            return _optionProcessor.Process<IDeleteBrandedLinkCommand, DeleteBrandedLinkCommand>(commandAction);
        }

        public ICommand<BrandedLink> UpdateBrandedLink(Action<IUpdateBrandedLinkCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateBrandedLinkCommand, UpdateBrandedLinkCommand>(commandAction);
        }

        public ICommand<BrandedLinkValidationResult> ValidateBrandedLink(
            Action<IValidateBrandedLinkCommand> commandAction)
        {
            return _optionProcessor.Process<IValidateBrandedLinkCommand, ValidateBrandedLinkCommand>(commandAction);
        }

        public ICommand<string> AssociateBrandedForSubUser(
            Action<IAssociateBrandedForSubUserCommand> commandAction)
        {
            return _optionProcessor
                    .Process<IAssociateBrandedForSubUserCommand, AssociateBrandedForSubUserCommand>(commandAction);
        }

        public ICommand<string> DisassociateBrandedForSubUser(
            Action<IDisassociateBrandedForSubUserCommand> commandAction)
        {
            return _optionProcessor
                    .Process<IDisassociateBrandedForSubUserCommand, DisassociateBrandedForSubUserCommand>(commandAction);
        }

        #endregion

        #region Reverse Dns

        public ICommand<ReverseDnsValidationResult> ValidateReverseDns(
            Action<IValidateReverseDnsCommand> commandAction)
        {
            return _optionProcessor
                    .Process<IValidateReverseDnsCommand, ValidateReverseDnsCommand>(commandAction);
        }

        public ICommand<ReverseDns> SetupReverseDns(Action<ISetupReverseDnsCommand> commandAction)
        {
            return _optionProcessor
                    .Process<ISetupReverseDnsCommand, SetupReverseDnsCommand>(commandAction);
        }

        public ICommand<string> DeleteReverseDns(Action<IDeleteReverseDnsCommand> commandAction)
        {
            return _optionProcessor
                    .Process<IDeleteReverseDnsCommand, DeleteReverseDnsCommand>(commandAction);
        }

        public IQuery<ReverseDns> ReverseDns(Action<IReverseDnsSingleQuery> queryAction)
        {
            return _optionProcessor.Process<IReverseDnsSingleQuery, ReverseDnsSingleQuery>(queryAction);
        }

        public IQuery<List<ReverseDns>> ReverseDnsList(
            Action<IReverseDnsListQuery> queryAction = null)
        {
            return _optionProcessor
                .Process<IReverseDnsListQuery, ReverseDnsListQuery
                >(queryAction);
        }

        #endregion

        #region Authenticated Domain

        public IQuery<List<AuthenticatedDomain>> AuthenticatedDomainListForSubuser(
            Action<IAuthenticatedDomainListForSubuserQuery> queryAction = null)
        {
            return _optionProcessor
                .Process<IAuthenticatedDomainListForSubuserQuery, AuthenticatedDomainListForSubuserQuery
                >(queryAction);
        }

        public IQuery<List<AuthenticatedDomain>> AuthenticatedDomainList(
            Action<IAuthenticatedDomainListQuery> queryAction = null)
        {
            return _optionProcessor
                .Process<IAuthenticatedDomainListQuery, AuthenticatedDomainListQuery
                >(queryAction);
        }

        public IQuery<AuthenticatedDomain> AuthenticatedDomainSingle(
            Action<IAuthenticatedDomainSingleQuery> queryAction = null)
        {
            return _optionProcessor
                .Process<IAuthenticatedDomainSingleQuery, AuthenticatedDomainSingleQuery
                >(queryAction);
        }

        public IQuery<AuthenticatedDomain> DefaultAuthtenticatedDomainSingle(
            Action<IDefaultAuthenticatedDomainSingleQuery> queryAction = null)
        {
            return _optionProcessor
                .Process<IDefaultAuthenticatedDomainSingleQuery, DefaultAuthenticatedDomainSingleQuery
                >(queryAction);
        }

        public ICommand<AuthenticatedDomain> AddIpAddressToAuthenticatedDomain(
            Action<IAddIpAddressToAuthenticatedDomainCommand> commandAction)
        {
            return _optionProcessor
                    .Process<IAddIpAddressToAuthenticatedDomainCommand, AddIpAddressToAuthenticatedDomainCommand>(
                        commandAction);
        }

        public ICommand<AuthenticatedDomain> AuthenticateToDomain(
            Action<IAuthenticateToDomainCommand> commandAction)
        {
            return _optionProcessor
                    .Process<IAuthenticateToDomainCommand, AuthenticateToDomainCommand>(
                        commandAction);
        }

        public ICommand<AuthenticatedDomain> AssociateSubuserToAuthenticatedDomain(
            Action<IAssociateSubuserToAuthenticatedDomainCommand> commandAction)
        {
            return _optionProcessor
                    .Process<IAssociateSubuserToAuthenticatedDomainCommand, AssociateSubuserToAuthenticatedDomainCommand
                    >(commandAction);
        }

        public ICommand<string> DisAssociateSubuserToAuthenticatedDomain(
            Action<IDisassociateSubUserFromAuthenticatedDomainCommand> commandAction = null)
        {
            return _optionProcessor
                    .Process<IDisassociateSubUserFromAuthenticatedDomainCommand,
                        DisassociateSubUserFromAuthenticatedDomainCommand>(commandAction);
        }

        public ICommand<AuthenticatedDomain> RemoveIpAddressToAuthenticatedDomain(
            Action<IRemoveIpAddressFromAuthenticatedDomainCommand> commandAction)
        {
            return _optionProcessor
                    .Process<IRemoveIpAddressFromAuthenticatedDomainCommand,
                        RemoveIpAddressFromAuthenticatedDomainCommand>(commandAction);
        }

        public ICommand<AuthenticatedDomainSetting> UpdateAuthenticatedDomainSetting(
            Action<IUpdateAuthenticatedDomainSettingCommand> commandAction)
        {
            return _optionProcessor
                    .Process<IUpdateAuthenticatedDomainSettingCommand,
                        UpdateAuthenticatedDomainSettingCommand>(commandAction);
        }

        public ICommand<string> DeleteAuthenticatedDomain(
            Action<IDeleteAuthenticatedDomainCommand> commandAction)
        {
            return _optionProcessor
                    .Process<IDeleteAuthenticatedDomainCommand,
                        DeleteAuthenticatedDomainCommand>(commandAction);
        }

        public ICommand<AuthenticatedDomainValidation> ValidateAuthenticatedDomain(
            Action<IValidateAuthenticatedDomainCommand> commandAction)
        {
            return _optionProcessor
                    .Process<IValidateAuthenticatedDomainCommand, ValidateAuthenticatedDomainCommand>(commandAction);
        }

        #endregion

        #region Teammates

        public ICommand<TeammateWithScope> UpdateTeammate(Action<IUpdateTeammateCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateTeammateCommand, UpdateTeammateCommand>(commandAction);
        }

        public ICommand<string> DeleteTeammate(Action<IDeleteTeammateCommand> commandAction)
        {
            return _optionProcessor.Process<IDeleteTeammateCommand, DeleteTeammateCommand>(commandAction);
        }

        public ICommand<ApproveTeammateRequestResult> ApproveTeammateAccessRequest(
            Action<IApproveTeammateAccessRequestCommand> commandAction)
        {
            return _optionProcessor.Process<IApproveTeammateAccessRequestCommand, ApproveTeammateAccessRequestCommand>(commandAction);
        }

        public ICommand<string> DenyTeammateAccessRequest(Action<IDenyTeammateAccessRequestCommand> commandAction)
        {
            return _optionProcessor
                .Process<IDenyTeammateAccessRequestCommand, DenyTeammateAccessRequestCommand>(commandAction);
        }

        public ICommand<string> DeletePendingTeammateInvite(
            Action<IDeletePendingTeammateInviteCommand> commandAction)
        {
            return _optionProcessor
                    .Process<IDeletePendingTeammateInviteCommand, DeletePendingTeammateInviteCommand>(commandAction);
        }

        public ICommand<TeammateInviteResult> InviteTeammate(Action<IInviteTeammateCommand> commandAction)
        {
            return _optionProcessor.Process<IInviteTeammateCommand, InviteTeammateCommand>(commandAction);
        }

        public ICommand<TeammateInviteResult> ResendTeammateInvite(
            Action<IResendTeammateInviteCommand> commandAction)
        {
            return _optionProcessor.Process<IResendTeammateInviteCommand, ResendTeammateInviteCommand>(commandAction);
        }

        public IQuery<List<Teammate>> Teammates(Action<ITeammateListQuery> queryAction = null)
        {
            return _optionProcessor.Process<ITeammateListQuery, TeammateListQuery>(queryAction);
        }

        public IQuery<Teammate> FindTeammate(Action<ITeammateSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<ITeammateSingleQuery, TeammateSingleQuery>(queryAction);
        }

        public IQuery<List<TeammateAccessRequest>> TeammateAccessRequests(
            Action<ITeammateAccessRequestListQuery> queryAction = null)
        {
            return _optionProcessor.Process<ITeammateAccessRequestListQuery, TeammateAccessRequestListQuery>(queryAction);
        }

        public IQuery<List<PendingTeammateInvitation>> PendingTemmateInvitations(
            Action<IPendingTeammateInvitationListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IPendingTeammateInvitationListQuery, PendingTeammateInvitationListQuery>(queryAction);
        }

        #endregion

        #region Enforced Settings

        public IQuery<EnforcedTls> EnforcedTls(Action<IEnforcedTlsSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<IEnforcedTlsSingleQuery, EnforcedTlsSingleQuery>(queryAction);
        }

        public ICommand<EnforcedTls> UpdateEnforcedTls(Action<IUpdateEnforcedTlsCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateEnforcedTlsCommand, UpdateEnforcedTlsCommand>(commandAction);
        }

        #endregion

        #region ParseSettings

        public IQuery<List<ParseSetting>> ParseSettings(Action<IParseSettingListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IParseSettingListQuery, ParseSettingListQuery>(queryAction);
        }

        public IQuery<ParseSetting> ParseSettingById(Action<IParseSettingSingleQuery> queryAction)
        {
            return _optionProcessor.Process<IParseSettingSingleQuery, ParseSettingSingleQuery>(queryAction);
        }

        public ICommand<ParseSetting> CreateParseSetting(Action<ICreateParseSettingCommand> commandAction)
        {
            return _optionProcessor.Process<ICreateParseSettingCommand, CreateParseSettingCommand>(commandAction);
        }

        public ICommand<ParseSetting> UpdateParseSetting(Action<IUpdateParseSettingCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateParseSettingCommand, UpdateParseSettingCommand>(commandAction);
        }

        public ICommand<string> DeleteParseSetting(Action<IDeleteParseSettingCommand> commandAction)
        {
            return _optionProcessor.Process<IDeleteParseSettingCommand, DeleteParseSettingCommand>(commandAction);
        }

        #endregion

        #region Mail Settings

        public ICommand<BccSetting> UpdateBccSetting(Action<IUpdateBccSettingCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateBccSettingCommand, UpdateBccSettingCommand>(commandAction);
        }

        public ICommand<TemplateSetting> UpdateTemplateSetting(Action<IUpdateTemplateSettingCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateTemplateSettingCommand, UpdateTemplateSettingCommand>(commandAction);
        }

        public ICommand<BounceForwardSetting> UpdateBounceForwardSetting(
            Action<IUpdateBounceForwardSettingCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateBounceForwardSettingCommand, UpdateBounceForwardSettingCommand>(
                commandAction);
        }

        public ICommand<SpamForwardingSetting> UpdateSpamForwardingSetting(
            Action<IUpdateSpamForwardingSettingCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateSpamForwardingSettingCommand, UpdateSpamForwardingSettingCommand>(
                commandAction);
        }

        public ICommand<SpamCheckSetting> UpdateSpamCheckSetting(Action<IUpdateSpamCheckSettingCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateSpamCheckSettingCommand, UpdateSpamCheckSettingCommand>(
                commandAction);
        }

        public ICommand<PlainContentSetting> UpdatePlainContentSetting(
            Action<IUpdatePlainContentSettingCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdatePlainContentSettingCommand, UpdatePlainContentSettingCommand>(
                commandAction);
        }

        public ICommand<MailFooterSetting> UpdateMailFooterSetting(
            Action<IUpdateMailFooterSettingCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateMailFooterSettingCommand, UpdateMailFooterSettingCommand>(
                commandAction);
        }

        public ICommand<EmailAddressWhiteListSetting> UpdateEmailAddressWhiteListSetting(
            Action<IUpdateEmailAddressWhiteListSettingCommand> commandAction)
        {
            return _optionProcessor
                .Process<IUpdateEmailAddressWhiteListSettingCommand, UpdateEmailAddressWhiteListSettingCommand>(
                    commandAction);
        }

        public ICommand<BouncePurgeSetting> UpdateBouncePurgeSetting(
            Action<IUpdateBouncePurgeSettingCommand> commandAction)
        {
            return _optionProcessor.Process<IUpdateBouncePurgeSettingCommand, UpdateBouncePurgeSettingCommand>(
                commandAction);
        }

        public IQuery<List<MailSetting>> MailSettings(Action<IMailSettingListQuery> queryAction = null)
        {
            return _optionProcessor.Process<IMailSettingListQuery, MailSettingListQuery>(queryAction);
        }

        public IQuery<BccSetting> BccSetting(Action<IBccSettingSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<IBccSettingSingleQuery, BccSettingSingleQuery>(queryAction);
        }

        public IQuery<TemplateSetting> TemplateSetting(Action<ITemplateSettingSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<ITemplateSettingSingleQuery, TemplateSettingSingleQuery>(queryAction);
        }

        public IQuery<SpamForwardingSetting> SpamForwardingSetting(
            Action<ISpamForwardingSettingSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<ISpamForwardingSettingSingleQuery, SpamForwardingSettingSingleQuery>(
                queryAction);
        }

        public IQuery<SpamCheckSetting> SpamCheckSetting(Action<ISpamCheckSettingSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<ISpamCheckSettingSingleQuery, SpamCheckSettingSingleQuery>(queryAction);
        }

        public IQuery<MailFooterSetting> MailFooterSetting(Action<IMailFooterSettingSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<IMailFooterSettingSingleQuery, MailFooterSettingSingleQuery>(queryAction);
        }

        public IQuery<BounceForwardSetting> BounceForwardSetting(
            Action<IBounceForwardSettingSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<IBounceForwardSettingSingleQuery, BounceForwardSettingSingleQuery>(
                queryAction);
        }

        public IQuery<BouncePurgeSetting> BouncePurgeSetting(Action<IBouncePurgeSettingSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<IBouncePurgeSettingSingleQuery, BouncePurgeSettingSingleQuery>(
                queryAction);
        }

        public IQuery<PlainContentSetting> PlainContentSetting(
            Action<IPlainContentSettingSingleQuery> queryAction = null)
        {
            return _optionProcessor.Process<IPlainContentSettingSingleQuery, PlainContentSettingSingleQuery>(
                queryAction);
        }

        public IQuery<EmailAddressWhiteListSetting> EmailAddressWhiteListSetting(
            Action<IEmailAddressWhiteListSettingSingleQuery> queryAction = null)
        {
            return _optionProcessor
                .Process<IEmailAddressWhiteListSettingSingleQuery, EmailAddressWhiteListSettingSingleQuery>(
                    queryAction);
        }

        #endregion
    }
}