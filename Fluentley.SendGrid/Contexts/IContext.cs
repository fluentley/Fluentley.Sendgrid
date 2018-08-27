using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Operations.Alerts.Commands;
using Fluentley.SendGrid.Operations.Alerts.Models;
using Fluentley.SendGrid.Operations.ApiKeys.Commands;
using Fluentley.SendGrid.Operations.ApiKeys.Models;
using Fluentley.SendGrid.Operations.BlockedEmailAddresses.Commands;
using Fluentley.SendGrid.Operations.BouncedEmailAddresses.Commands;
using Fluentley.SendGrid.Operations.Campaigns.Commands;
using Fluentley.SendGrid.Operations.Campaigns.Models;
using Fluentley.SendGrid.Operations.CampaignSchedules.Commands;
using Fluentley.SendGrid.Operations.CampaignSchedules.Models;
using Fluentley.SendGrid.Operations.Categories.Models;
using Fluentley.SendGrid.Operations.DomainAuthentications.Commands;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;
using Fluentley.SendGrid.Operations.EmailCNameRecords.Commands;
using Fluentley.SendGrid.Operations.EmailCNameRecords.Models;
using Fluentley.SendGrid.Operations.EmailOperations;
using Fluentley.SendGrid.Operations.InvalidEmailAddresses.Commands;
using Fluentley.SendGrid.Operations.IpAccessManagements.Commands;
using Fluentley.SendGrid.Operations.IpAccessManagements.Models;
using Fluentley.SendGrid.Operations.IpAddresses.Commands;
using Fluentley.SendGrid.Operations.IpAddresses.Models;
using Fluentley.SendGrid.Operations.IpPools.Commands;
using Fluentley.SendGrid.Operations.IpPools.Models;
using Fluentley.SendGrid.Operations.IpWarmups.Commands;
using Fluentley.SendGrid.Operations.IpWarmups.Models;
using Fluentley.SendGrid.Operations.LinkBrandings.Commands;
using Fluentley.SendGrid.Operations.LinkBrandings.Models;
using Fluentley.SendGrid.Operations.MonitorSettings.Commands;
using Fluentley.SendGrid.Operations.MonitorSettings.Models;
using Fluentley.SendGrid.Operations.Reputations.Models;
using Fluentley.SendGrid.Operations.ReverseDnses.Commands;
using Fluentley.SendGrid.Operations.ReverseDnses.Models;
using Fluentley.SendGrid.Operations.SenderIdentities.Commands;
using Fluentley.SendGrid.Operations.SenderIdentities.Models;
using Fluentley.SendGrid.Operations.SettingEnforcedTls.Commands;
using Fluentley.SendGrid.Operations.SettingEnforcedTls.Models;
using Fluentley.SendGrid.Operations.SettingInboundParse.Commands;
using Fluentley.SendGrid.Operations.SettingInboundParse.Models;
using Fluentley.SendGrid.Operations.SettingMail.Commands;
using Fluentley.SendGrid.Operations.SettingMail.Models;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Commands;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Models;
using Fluentley.SendGrid.Operations.Statistics.Models;
using Fluentley.SendGrid.Operations.SubUsers.Commands;
using Fluentley.SendGrid.Operations.SubUsers.Models;
using Fluentley.SendGrid.Operations.Teammates.Commands;
using Fluentley.SendGrid.Operations.Teammates.Models;
using Fluentley.SendGrid.Operations.Users.Commands;
using Fluentley.SendGrid.Operations.Users.Models;
using Fluentley.SendGrid.Operations.Webhooks.Commands;
using Fluentley.SendGrid.Operations.Webhooks.Models;
using RestEase;
using User = Fluentley.SendGrid.Operations.Users.Models.User;

[assembly: InternalsVisibleTo(RestClient.FactoryAssemblyName)]

namespace Fluentley.SendGrid.Contexts
{
    internal interface IContext
    {
        [Header("Content-Type")]
        string ContentType { get; set; }

        [Header("Authorization")]
        string ApiKey { get; set; }

        [Header("on-behalf-of")]
        string OnBehalfOf { get; set; }

        #region Send Email 

        [Post("/mail/send")]
        Task<Response<string>> SendEmail([Body] SendEmailCommand command);

        #endregion

        #region Reputation

        [Get("/subusers/reputations")]
        Task<Response<List<Reputation>>> SubuserReputations([Query("usernames")] params string[] subUsers);

        #endregion

        #region Categories

        [Get("categories")]
        Task<Response<List<Category>>> Categories([Query] int? limit = null, [Query] int? offset = null,
            [Query("category")] string categoryName = null);

        #endregion

        [Delete("/ips/warmup/{ipAddress}")]
        Task<Response<string>> DeleteIpWarmup([Path] string ipAddress);

        [Post("/ips")]
        Task<Response<AddIpResult>> AddIpAddress([Body] AddIpAddressCommand command);

        [Post("/whitelabel/dns/email")]
        Task<Response<SendDnsInformationResult>> SendGeneratedDnsInformation(
            [Body] SendGeneratedDnsInformationCommand command);

        [Get("/whitelabel/ips")]
        Task<Response<List<ReverseDns>>> ReverseDnses([Query("offset")] int? queryPageIndex,
            [Query("limit")] int? queryPageSize, [Query("ip")] string queryIpAddress);

        [Get("/whitelabel/ips/{id}")]
        Task<Response<ReverseDns>> ReverserDnsById([Path] string id);

        [Post("/whitelabel/ips")]
        Task<Response<ReverseDns>> SetupReverseDns([Body] SetupReverseDnsCommand command);

        [Delete("/whitelabel/ips/{id}")]
        Task<Response<string>> DeleteReverseDns([Path] string id);

        [Post("/whitelabel/ips/{id}/validate")]
        Task<Response<ReverseDnsValidationResult>> ValidateReverseDnsById([Path] string id);

        [Get("/teammates/{username}")]
        Task<Response<Teammate>> TeammateByUserName([Path] string username);

        [Delete("/teammates/{username}")]
        Task<Response<string>> DeleteTeammateByUserName([Path] string username);

        [Patch("/teammates/{username}")]
        Task<Response<TeammateWithScope>> UpdateTeammateByUserName([Path] string username,
            [Body] UpdateTeammateCommand command);

        [Get("/user/settings/enforced_tls")]
        Task<Response<EnforcedTls>> EnforcedTls();

        [Patch("/user/settings/enforced_tls")]
        Task<Response<EnforcedTls>> UpdateEnforcedTls([Body] UpdateEnforcedTlsCommand command);

        [Get("/user/webhooks/parse/settings/{hostName}")]
        Task<Response<ParseSetting>> ParseSettingByHostName([Path] string hostName);

        #region User

        [Patch("/user/profile")]
        Task<Response<UserProfile>> UpdateUserProfile([Body] UpdateUserProfileCommand command);

        [Put("/user/email")]
        Task<Response<UserEmailAddress>> UpdateUserEmailAddress([Body] UpdateUserEmailAddressCommand command);

        [Put("/user/username")]
        Task<Response<User>> UpdateUserName([Body] UpdateUserNameCommand command);

        [Put("/user/password")]
        Task<Response<string>> UpdateUserPassword(UpdateUserPasswordCommand command);

        #endregion

        #region Senders

        [Post("senders")]
        Task<Response<SenderIdentity>> CreateSenderIdentity([Body] CreateSenderIdentityCommand command);

        [Patch("senders/{id}")]
        Task<Response<SenderIdentity>> UpdateSenderIdentity([Path] string id,
            [Body] UpdateSenderIdentityCommand command);

        [Delete("senders/{id}")]
        Task<Response<string>> DeleteSenderIdentity([Path] string id);

        [Post("senders/{id}/resend_verification")]
        Task<Response<string>> ResendVerificationSenderIdentityById([Path] string id);

        #endregion

        #region Ip Pools

        [Get("/ips/pools/{name}")]
        Task<Response<IpPool>> IpPoolByName([Path] string name);

        [Get("/ips/pools")]
        Task<Response<List<IpPool>>> IpPools();

        [Post("/ips/pools")]
        Task<Response<IpPool>> CreateIpPool([Body] CreateIpPoolCommand command);

        [Put("/ips/pools/{name}")]
        Task<Response<IpPool>> UpdateIpPool([Path] string name, [Body] UpdateIpPoolCommand command);

        [Delete("/ips/pools/{name}")]
        Task<Response<string>> DeleteIpPoolByName([Path] string name);

        [Post("/ips/pools/{name}/ips")]
        Task<Response<IpAddress>>
            AddIpAddressToPool([Path] string name, [Body] AddIpAddressToPoolCommand command);

        [Delete("/ips/pools/{ipPoolName}/ips/{ip}")]
        Task<Response<string>>
            RemoveIpAddressFromPool([Path] string ipPoolName, [Path] string ip);

        #endregion

        #region Webhook Settings

        [Patch("/user/webhooks/event/settings")]
        Task<Response<WebhookSettings>> UpdateWebhookSettings([Body] UpdateWebHookSettingsCommand command);

        [Post("/user/webhooks/event/test")]
        Task<Response<string>> SendTestWebhookEvent([Body] SendTestWebhookEventCommand command);

        [Get("/user/webhooks/event/settings")]
        Task<Response<WebhookSettings>> WebhookSettings();

        [Get("/user/webhooks/parse/settings")]
        Task<Response<SendGridResult<List<WebhookParseSettings>>>> WebhookParseSettings();

        [Get("/user/webhooks/parse/stats")]
        Task<Response<List<WebhookParseStatistics>>> WebhookParseStatistics([Query("limit")] int? pageSize = null,
            [Query("offset")] int? pageIndex = null, [Query("start_date")] string startDate = null,
            [Query("end_date")] string endDate = null, string aggregatedby = null);

        #endregion

        #region Email Statistics

        [Get("/subusers/stats")]
        Task<Response<List<EmailStatistic>>> EmailStatisticsForSubUsers([Query] int? limit = null,
            [Query] int? offset = null,
            [Query("aggregated_by")] string aggregatedby = null, [Query] Dictionary<string, string> subusers = null,
            [Query("start_date")] string startDate = null, [Query] string endDate = null);

        [Get("/cateogry/stats")]
        Task<Response<List<EmailStatistic>>> EmailStatisticsForCategories([Query] int? limit = null,
            [Query] int? offset = null,
            [Query("aggregated_by")] string aggregatedby = null, [Query] Dictionary<string, string> subusers = null,
            [Query("start_date")] string startDate = null, [Query] string endDate = null);

        #endregion

        #region Alert

        [Get("/alerts")]
        Task<Response<List<Alert>>> Alerts();

        [Get("/alerts/{id}")]
        Task<Response<Alert>> AlertById([Path] string id);

        [Post("/alerts")]
        Task<Response<Alert>> CreateAlert([Body] CreateAlertCommand command);

        [Patch("/alerts/{id}")]
        Task<Response<Alert>> UpdateAlert([Path] string id, [Body] UpdateAlertCommand command);

        [Delete("/alerts/{id}")]
        Task<Response<string>> DeleteAlertById([Path] string id);

        #endregion

        #region Api Keys

        [Get("/api_keys")]
        Task<Response<SendGridResult<List<ApiKey>>>> ApiKeys([Query("limit")] int? limit = null);

        [Get("/api_keys/{id}")]
        Task<Response<ApiKey>> ApiKeyById([Path] string id);

        [Post("/api_keys")]
        Task<Response<ApiKey>> CreateApiKey([Body] CreateApiKeyCommand command);

        [Patch("/api_keys/{id}")]
        Task<Response<ApiKey>> UpdateApiKey([Path] string id, [Body] UpdateApiKeyCommand command);

        [Put("/api_keys/{id}")]
        Task<Response<ApiKey>> UpdateApiKeyWithScopes([Path] string id, [Body] UpdateApiKeyCommand command);

        [Delete("/api_keys/{id}")]
        Task<Response<string>> DeleteApiKey([Path] string id);

        #endregion

        #region Blocked EmailAddress

        [Get("/suppression/blocks")]
        Task<Response<List<EmailReport>>> BlockedEmailAddresses([Query("limit")] int? limit = null,
            [Query("offset")] int? offset = null, [Query("start_time")] long? startTime = null,
            [Query("end_time")] long? endTime = null);

        [Get("/suppression/blocks/{emailAddress}")]
        Task<Response<EmailReport>> BlockedEmailAddressByEmailAddress([Path] string emailAddress);

        [Delete("/suppression/blocks")]
        Task<Response<string>> DeleteBlockedEmailAddressByEmailAddress([Body] DeleteBlockedEmailAddressCommand command);

        #endregion

        #region Bounced EmailAddress

        [Get("/suppression/bounces")]
        Task<Response<List<EmailReport>>> BouncedEmailAddresses([Query("start_time")] long? startTime = null,
            [Query("end_time")] long? endTime = null);

        [Get("/suppression/bounces/{emailAddress}")]
        Task<Response<EmailReport>> BouncedEmailAddressByEmailAddress([Path] string emailAddress);

        [Delete("/suppression/bounces")]
        Task<Response<string>> DeleteBouncedEmailAddressByEmailAddress([Body] DeleteBouncedEmailAddressCommand command);

        #endregion

        #region Invalid EmailAddress

        [Get("/suppression/invalid_emails")]
        Task<Response<List<EmailReport>>> InvalidEmailAddresses([Query("limit")] int? limit = null,
            [Query("offset")] int? offset = null, [Query("start_time")] long? startTime = null,
            [Query("end_time")] long? endTime = null);

        [Get("/suppression/invalid_emails/{emailAddress}")]
        Task<Response<EmailReport>> InvalidEmailAddressByEmailAddress([Path] string emailAddress);

        [Delete("/suppression/invalid_emails")]
        Task<Response<string>> DeleteInvalidEmailAddressByEmailAddress(
            [Body] DeleteInvalidEmailAddressCommand command);

        #endregion

        #region SpamReported EmailAddress

        [Get("/suppression/spam_reports")]
        Task<Response<List<SpamReportedEmailAddress>>> SpamReportedEmailAddresses([Query("limit")] int? limit = null,
            [Query("offset")] int? offset = null, [Query("start_time")] long? startTime = null,
            [Query("end_time")] long? endTime = null);

        [Get("/suppression/spam_reports/{emailAddress}")]
        Task<Response<SpamReportedEmailAddress>> SpamReportedEmailAddressByEmailAddress([Path] string emailAddress);

        [Delete("/suppression/spam_reports")]
        Task<Response<string>> DeleteSpamReportedEmailAddressByEmailAddress(
            [Body] DeleteSpamReportedEmailAddressCommand command);

        #endregion

        #region Monitor

        [Get("/subusers/{subUserName}/monitor")]
        Task<Response<MonitorSetting>> MonitorSettingBySubUserName([Path] string subUserName);

        [Put("/subusers/{subUserName}/monitor")]
        Task<Response<MonitorSetting>> UpdateMonitorSettingBySubUserName([Path] string subUserName,
            [Body] UpdateMonitorSettingCommand monitorSetting);

        [Delete("/subusers/{subUserName}/monitor")]
        Task<Response<string>> DeleteMonitorSettingByUserName([Path] string subUserName);

        #endregion

        #region SubUsers

        [Patch("/subusers/{subUserName}")]
        Task<Response<string>> EnableOrDisableSubUser([Path] string subUserName, [Body] dynamic disabled);

        [Get("/subusers")]
        Task<Response<List<SubUser>>> SubUsers([Query("limit")] int? limit = null,
            [Query("offset")] int? offset = null, [Query] string subUserName = null);

        [Get("/subusers/{id}")]
        Task<Response<SubUser>> SubUserById([Path] string id);

        [Post("/subusers")]
        Task<Response<SubUser>> CreateSubUser([Body] CreateSubUserCommand command);

        [Patch("/subusers/{id}")]
        Task<Response<SubUser>> UpdateSubUser([Path] string id, [Body] SubUser command);

        [Delete("/subusers/{id}")]
        Task<Response<string>> DeleteSubUserById([Path] string id);

        #endregion

        #region Campaigns

        [Post("/campaigns")]
        Task<Response<Campaign>> CreateCampaign([Body] CreateCampaignCommand command);

        [Patch("/campaigns/{campaignId}")]
        Task<Response<Campaign>> UpdateCampaign([Path] string campaignId, [Body] UpdateCampaignCommand command);

        [Get("/campaigns/{campaignId}")]
        Task<Response<Campaign>> CampaignById([Path] string campaignId);

        [Delete("/campaigns/{campaignId}")]
        Task<Response<string>> DeleteCampaignById([Path] string campaignId);

        [Get("/campaigns")]
        Task<Response<SendGridResult<List<Campaign>>>> Campaigns([Query("limit")] int? limit = null,
            [Query("offset")] int? offset = null);

        [Post("/campaigns/{campaignId}/schedules/now")]
        Task<Response<CampaignSchedule>> SendCampaignById([Path] string campaignId);

        [Post("/campaigns/{campaignId}/schedules/test")]
        Task<Response<CampaignSchedule>> SendSchedulesTest([Path] string campaignId,
            [Body] CampaignSendCommand command);

        #endregion

        #region Campaign Schedule

        [Post("/campaigns/{campaignId}/schedules")]
        Task<Response<CampaignSchedule>> CreateCampaignSchedule([Path] string campaignId,
            [Body] CreateCampaignScheduleCommand createCampaignScheduleCommand);

        [Delete("/campaigns/{campaignId}/schedules")]
        Task<Response<string>> DeleteScheduleCampaignById([Path] string campaignId);

        [Patch("/campaigns/{campaignId}/schedules")]
        Task<Response<CampaignSchedule>> UpdateScheduleCampaignById([Path] string campaignId,
            [Body] UpdateCampaignScheduleCommand command);

        [Get("/campaigns/{campaignId}/schedules")]
        Task<Response<CampaignSchedule>> CampaignScheduleByCampaignId([Path] string campaignId);

        #endregion

        #region User Profile

        [Get("/user/profile")]
        Task<Response<UserProfile>> UserProfile();

        [Get("/user/account")]
        Task<Response<UserAccount>> UserAccount();

        [Get("/user/email")]
        Task<Response<UserEmailAddress>> UserEmailAddress();

        [Get("/user/username")]
        Task<Response<User>> User();

        [Get("/user/credits")]
        Task<Response<UserCredit>> UserCredit();

        #endregion

        #region Sender Identities

        [Get("senders")]
        Task<Response<SendGridResult<List<SenderIdentity>>>> SenderIdentities();

        [Get("senders/{id}")]
        Task<Response<SenderIdentity>> SenderIdentityById([Path] string id);

        #endregion

        #region Ip Warmups

        [Get("/ips/warmup/{ipAddress}")]
        Task<Response<IpWarmup>> IpWarmupByIpAddress([Path] string ipAddress);

        [Get("/ips/warmup")]
        Task<Response<List<IpWarmup>>> IpWarmups();

        [Post("/ips/warmup")]
        Task<Response<IpWarmup>> CreateIpWarmup([Body] CreateIpWarmupCommand command);

        #endregion

        #region Ip Addresses

        [Get("/ips/remaining")]
        Task<Response<SendGridResult<List<RemainingIpAddress>>>> RemainingIpAddresses();

        [Get("ips")]
        Task<Response<List<IpAddress>>> IpAddresses([Query("offset")] int? pageIndex = null,
            [Query("limit")] int? pageSize = null, [Query("sort_by_direction")] string sortDirection = null,
            [Query("exclude_whitelabels")] bool? excludeWhiteLables = null, [Query("ip")] string queryIpAddress = null,
            [Query("subuser")] string querySubUser = null);

        [Get("/ips/{ipAddress}")]
        Task<Response<IpAddress>> IpAddressByIpAddress([Path] string ipAddress);

        [Get("/ips/assigned")]
        Task<Response<List<AssignedIpAddress>>> AssignedIpAddresses();

        #endregion

        #region Ip Mangement Settings

        [Get("/access_settings/activity")]
        Task<Response<SendGridResult<List<IpAccessManagementSettingActivity>>>> IpAccessManagementSettingActivities(
            [Query("limit")] int? limit = null);

        [Get("/access_settings/whitelist")]
        Task<Response<SendGridResult<List<WhiteListedIpAddress>>>> WhiteListedIpAddresses();

        [Get("/access_settings/whitelist/{id}")]
        Task<Response<WhiteListedIpAddress>> WhiteListedIpAddressById([Path] string id);

        [Post("/access_settings/whitelist")]
        Task<Response<List<WhiteListedIpAddress>>> AddWhiteListedIpAddress(
            [Body] AddWhiteListedIpAddressCommand command);

        [Delete("/access_settings/whitelist")]
        Task<Response<string>> RemoveWhiteListedIpAddress([Body] RemoveWhiteListedIpAddressCommand command);

        #endregion

        #region Branded Links

        [Get("/whitelabel/links")]
        Task<Response<List<BrandedLink>>> BrandedLinks([Query("limit")] int? limit = null);

        [Get("/whitelabel/links/{id}")]
        Task<Response<BrandedLink>> BrandedLinkById([Path] string id);

        [Get("/whitelabel/links/default")]
        Task<Response<BrandedLink>> DefaultBrandedLink([Query("domain")] string domainUrl = null);

        [Post("/whitelabel/links")]
        Task<Response<BrandedLink>> CreateBrandedLink([Body] CreateBrandedLinkCommand command);

        [Patch("/whitelabel/links/{id}")]
        Task<Response<BrandedLink>> UpdateBrandedLink([Path] string id, [Body] UpdateBrandedLinkCommand isDefault);

        [Delete("/whitelabel/links/{id}")]
        Task<Response<string>> DeleteBrandedLink([Path] string id);

        [Post("/whitelabel/links/{id}/validate")]
        Task<Response<BrandedLinkValidationResult>> ValidateBrandedLinkById([Path] string id);

        [Get("/whitelabel/links/subuser")]
        Task<Response<BrandedLink>> BrandedlinksForSubuser([Query("username")] string subUser);

        [Delete("/whitelabel/links/subuser")]
        Task<Response<string>> DisassociateBrandedForSubUser([Query("username")] string userName);

        [Post("/whitelabel/links/{id}/subuser")]
        Task<Response<string>> AssociateBrandedForSubUser([Path] string id,
            [Body] AssociateBrandedForSubUserCommand command);

        #endregion

        #region Authenticated Domains

        [Get("/whitelabel/domains")]
        Task<Response<List<AuthenticatedDomain>>> AuthtenticatedDomains([Query("offset")] int? pageIndex,
            [Query("limit")] int? pageSize, [Query("domain")] string domain,
            [Query("exclude_subusers")] bool? excludeUsers, [Query("username")] string userName);

        [Post("/whitelabel/domains")]
        Task<Response<AuthenticatedDomain>> AuthenticateToDomain([Body] DomainAuthenticate model);

        [Get("/whitelabel/domains/{id}")]
        Task<Response<AuthenticatedDomain>> AuthtenticatedDomainById([Path] string id);

        [Patch("/whitelabel/domains/{id}")]
        Task<Response<AuthenticatedDomainSetting>> UpdateAuthenticatedDomainSetting([Path] string id,
            [Body] UpdateAuthenticatedDomainSettingCommand command);

        [Delete("/whitelabel/domains/{id}")]
        Task<Response<string>> DeleteAuthenticatedDomainById([Path] string id);

        [Get("/whitelabel/domains/default")]
        Task<Response<AuthenticatedDomain>> DefaultAuthenticatedDomainByDomain();

        [Post("/whitelabel/domains/{id}/ips")]
        Task<Response<AuthenticatedDomain>> AddIpAddressToAuthenticatedDomain([Path] string id,
            [Body] AddIpAddressToAuthenticatedDomainCommand command);

        [Delete("/whitelabel/domains/{id}/ips/{ip}")]
        Task<Response<AuthenticatedDomain>> RemoveIpAddressFromAuthenticatedDomain([Path] string id, [Path] string ip);

        [Post("/whitelabel/domains/{id}/validate")]
        Task<Response<AuthenticatedDomainValidation>> ValidateAuthenticatedDomainById([Path] string id);

        [Get("/whitelabel/domains/subuser")]
        Task<Response<List<AuthenticatedDomain>>> AuthenticatedDomainsForSubUser();

        [Delete("/whitelabel/domains/subuser")]
        Task<Response<string>> DisassociateSubuserFromAuthenticatedDomain();

        [Post("/whitelabel/domains/{id}/subuser")]
        Task<Response<AuthenticatedDomain>> AssociateSubuserToAuthenticatedDomain([Path] string id,
            [Body] AssociateSubuserToAuthenticatedDomainCommand command);

        #endregion

        #region Team Mate

        [Get("/scopes/requests")]
        Task<Response<List<TeammateAccessRequest>>> TeammateAccessRequests([Query("limit")] int? queryPageSize = null,
            [Query("offset")] int? queryPageIndex = null);

        [Delete("/scopes/requests/{id}")]
        Task<Response<string>> DenyTeammateAccessRequestById([Path] string id);

        [Patch("/scopes/requests/{id}/approve")]
        Task<Response<ApproveTeammateRequestResult>> ApproveTeammateAccessRequestById([Path] string id);

        [Post("/teammates/pending/{token}/resend")]
        Task<Response<TeammateInviteResult>> ResendTeammateInviteByToken([Path] string token);

        [Get("/teammates/pending")]
        Task<Response<SendGridResult<List<PendingTeammateInvitation>>>> PendingTeammateInvitations();

        [Delete("/teammates/pending/{token}")]
        Task<Response<string>> DeletePendingTeammateInviteByToken([Path] string token);

        [Post("/teammates")]
        Task<Response<TeammateInviteResult>> InviteTeammate([Body] InviteTeammateCommand command);

        [Get("/teammates")]
        Task<Response<List<Teammate>>> Teammates([Query("limit")] int? queryPageSize = null,
            [Query("offset")] int? queryPageIndex = null);

        #endregion

        #region Parse Settings

        [Post("/user/webhooks/parse/settings")]
        Task<Response<ParseSetting>> CreateParseSetting([Body] CreateParseSettingCommand command);

        [Get("/user/webhooks/parse/settings")]
        Task<Response<SendGridResult<List<ParseSetting>>>> ParseSettings();

        [Patch("/user/webhooks/parse/settings/{hostName}")]
        Task<Response<ParseSetting>> UpdateParseSetting([Path] string hostName,
            [Body] UpdateParseSettingCommand command);

        [Delete("/user/webhooks/parse/settings/{hostName}")]
        Task<Response<string>> DeleteParseSetting([Path] string hostName);

        #endregion

        #region Mail Settings

        [Get("/mail_settings")]
        Task<Response<SendGridResult<List<MailSetting>>>> MailSettings([Query("offset")] int? queryPageIndex,
            [Query("limit")] int? queryPageSize);

        [Get("/mail_settings/bcc")]
        Task<Response<BccSetting>> BccSetting();

        [Get("/mail_settings/address_whitelist")]
        Task<Response<EmailAddressWhiteListSetting>> EmailAddressWhiteListSetting();

        [Get("/mail_settings/footer")]
        Task<Response<MailFooterSetting>> MailFooterSetting();

        [Get("/mail_settings/forward_spam")]
        Task<Response<SpamForwardingSetting>> SpamForwardingSetting();

        [Get("/mail_settings/spam_check")]
        Task<Response<SpamCheckSetting>> SpamCheckSetting();

        [Get("/mail_settings/plain_content")]
        Task<Response<PlainContentSetting>> PlainContentSetting();

        [Get("/mail_settings/template")]
        Task<Response<TemplateSetting>> TemplateSetting();

        [Get("/mail_settings/bounce_purge")]
        Task<Response<BouncePurgeSetting>> BouncePurgeSetting();

        [Get("/mail_settings/forward_bounce")]
        Task<Response<BounceForwardSetting>> BounceForwardSetting();

        [Patch("/mail_settings/bcc")]
        Task<Response<BccSetting>> UpdateBccSetting([Body] UpdateBccSettingCommand command);

        [Patch("/mail_settings/address_whitelist")]
        Task<Response<EmailAddressWhiteListSetting>> UpdateEmailAddressWhiteListSetting(
            [Body] UpdateEmailAddressWhiteListSettingCommand command);

        [Patch("/mail_settings/footer")]
        Task<Response<MailFooterSetting>> UpdateMailFooterSetting([Body] UpdateMailFooterSettingCommand command);

        [Patch("/mail_settings/forward_spam")]
        Task<Response<SpamForwardingSetting>> UpdateSpamForwardingSetting(
            [Body] UpdateSpamForwardingSettingCommand command);

        [Patch("/mail_settings/plain_content")]
        Task<Response<PlainContentSetting>> UpdatePlainContentSetting([Body] UpdatePlainContentSettingCommand command);

        [Patch("/mail_settings/spam_check")]
        Task<Response<SpamCheckSetting>> UpdateSpamCheckSetting([Body] UpdateSpamCheckSettingCommand command);

        [Patch("/mail_settings/template")]
        Task<Response<TemplateSetting>> UpdateTemplateSetting([Body] UpdateTemplateSettingCommand command);

        [Patch("/mail_settings/bounce_purge")]
        Task<Response<BouncePurgeSetting>> UpdateBouncePurgeSetting([Body] UpdateBouncePurgeSettingCommand command);

        [Patch("/mail_settings/forward_bounce")]
        Task<Response<BounceForwardSetting>> UpdateBounceForwardSetting(
            [Body] UpdateBounceForwardSettingCommand command);

        #endregion
    }
}