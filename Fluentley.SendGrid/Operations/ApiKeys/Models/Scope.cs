using System.ComponentModel.DataAnnotations;

namespace Fluentley.SendGrid.Operations.ApiKeys.Models
{
    public enum Scope
    {
        [Display(Name = "")] Undefined,

        #region Credentials

        [Display(Name = "credentials.read")] CredentialsRead,
        [Display(Name = "credentials.create")] CredentialsCreate,
        [Display(Name = "credentials.update")] CredentialsUpdate,
        [Display(Name = "credentials.delete")] CredentialsDelete,

        #endregion

        #region User WebHooks  Settings

        [Display(Name = "user.webhooks.event.settings.read")]
        UserWebHooksEventSettingsRead,

        [Display(Name = "user.webhooks.event.settings.update")]
        UserWebHooksEventSettingsUpdate,

        [Display(Name = "user.webhooks.event.test.read")]
        UserWebHooksEventTestRead,

        [Display(Name = "user.webhooks.event.test.create")]
        UserWebHooksEventTestCreate,

        [Display(Name = "user.webhooks.event.test.update")]
        UserWebHooksEventTestUpdate,

        [Display(Name = "user.webhooks.parse.settings.create")]
        UserWebHooksParseSettingsCreate,

        [Display(Name = "user.webhooks.parse.settings.update")]
        UserWebHooksParseSettingsUpdate,

        [Display(Name = "user.webhooks.parse.settings.delete")]
        UserWebHooksParseSettingsDelete,

        [Display(Name = "user.webhooks.parse.settings.read")]
        UserWebHooksParseSettingsRead,

        [Display(Name = "user.webhooks.parse.stats.read")]
        UserWebHooksStatsRead,

        #endregion

        #region Messages

        [Display(Name = "messages.read")] MessagesRead,

        #endregion

        #region Alert

        [Display(Name = "alerts.read")] AlertRead,
        [Display(Name = "alerts.create")] AlertCreate,
        [Display(Name = "alerts.update")] AlertUpdate,
        [Display(Name = "alerts.delete")] AlertDelete,

        #endregion

        #region ApiKey

        [Display(Name = "api_keys.read")] ApiKeyRead,
        [Display(Name = "api_keys.create")] ApiKeyCreate,
        [Display(Name = "api_keys.update")] ApiKeyUpdate,
        [Display(Name = "api_keys.delete")] ApiKeyDelete,

        #endregion

        #region Asm Group

        [Display(Name = "asm.groups.read")] AsmGroupsRead,
        [Display(Name = "asm.groups.create")] AsmGroupsCreate,
        [Display(Name = "asm.groups.update")] AsmGroupsUpdate,
        [Display(Name = "asm.groups.delete")] AsmGroupsDelete,

        #endregion

        #region Billing

        [Display(Name = "billing.read")] BillingRead,
        [Display(Name = "billing.create")] BillingCreate,
        [Display(Name = "billing.update")] BillingUpdate,
        [Display(Name = "billing.delete")] BillingDelete,

        #endregion

        #region Category

        [Display(Name = "categories.read")] CategoryRead,
        [Display(Name = "categories.create")] CategoryCreate,
        [Display(Name = "categories.update")] CategoryUpdate,
        [Display(Name = "categories.delete")] CategoryDelete,

        [Display(Name = "categories.stats.read")]
        CategoryReadStatistics,

        [Display(Name = "categories.stats.sums.read")]
        CategoryReadSumOfStatistics,

        #endregion

        #region Statistics

        [Display(Name = "email_activity.read")]
        ReadEmailActivity,
        [Display(Name = "stats.read")] ReadStatistics,
        [Display(Name = "stats.global.read")] ReadGlobalStatistics,

        [Display(Name = "browsers.stats.read")]
        ReadBrowserStatistics,

        [Display(Name = "devices.stats.read")] ReadDeviceStatistics,
        [Display(Name = "geo.stats.read")] ReadGeoStatistics,

        [Display(Name = "mailbox_providers.stats.read")]
        ReadMailBoxStatistics,

        [Display(Name = "clients.desktop.stats.read")]
        ReadClientDesktopStatistics,

        [Display(Name = "clients.phone.stats.read")]
        ReadClientPhoneStatistics,
        [Display(Name = "clients.stats.read")] ReadClientStatistics,

        [Display(Name = "clients.tablet.stats.read")]
        ReadClientTabletStatistics,

        [Display(Name = "clients.webmail.stats.read")]
        ReadClientWebMailStatistics,

        #endregion

        #region Ip

        [Display(Name = "ips.assigned.read")] ReadAssignedIps,
        [Display(Name = "ips.read")] ReadIps,
        [Display(Name = "ips.pools.create")] CreateIpPools,
        [Display(Name = "ips.pools.update")] UpdateIpPools,
        [Display(Name = "ips.pools.delete")] DeleteIpPools,

        [Display(Name = "ips.pools.ips.create")]
        CreateIpPoolIps,

        [Display(Name = "ips.pools.ips.delete")]
        DeleteIpPoolIps,

        [Display(Name = "ips.pools.ips.update")]
        UpdateIpPoolIps,
        [Display(Name = "ips.pools.ips.read")] ReadIpPoolIps,
        [Display(Name = "ips.warmup.create")] CreateWarmupIps,
        [Display(Name = "ips.warmup.update")] UpdateWarmupIps,
        [Display(Name = "ips.warmup.delete")] DeleteWarmupIps,
        [Display(Name = "ips.warmup.read")] ReadWarmupIps,

        #endregion

        #region Mail Settings

        [Display(Name = "mail_settings.address_whitelist.read")]
        MailSettingsReadWhiteListAddress,

        [Display(Name = "mail_settings.address_whitelist.update")]
        MailSettingsUpdateWhiteListAddress,

        [Display(Name = "mail_settings.bcc.read")]
        MailSettingsReadBcc,

        [Display(Name = "mail_settings.bcc.update")]
        MailSettingsUpdateBcc,

        [Display(Name = "mail_settings.bounce_purge.read")]
        MailSettingsReadBouncePurge,

        [Display(Name = "mail_settings.bounce_purge.update")]
        MailSettingsUpdateBouncePurge,

        [Display(Name = "mail_settings.footer.update")]
        MailSettingsUpdateFooter,

        [Display(Name = "mail_settings.footer.read")]
        MailSettingsReadFooter,

        [Display(Name = "mail_settings.forward_bounce.update")]
        MailSettingsUpdateForwardBounce,

        [Display(Name = "mail_settings.forward_bounce.read")]
        MailSettingsReadForwardBounce,

        [Display(Name = "mail_settings.forward_spam.read")]
        MailSettingsReadForwardSpam,

        [Display(Name = "mail_settings.forward_spam.update")]
        MailSettingsUpdateForwardSpam,

        [Display(Name = "mail_settings.plain_content.read")]
        MailSettingsReadPlainContent,

        [Display(Name = "mail_settings.plain_content.update")]
        MailSettingsUpdatePlainContent,

        [Display(Name = "mail_settings.read")] MailSettingsRead,

        [Display(Name = "mail_settings.spam_check.read")]
        MailSettingsReadSpamCheck,

        [Display(Name = "mail_settings.spam_check.update")]
        MailSettingsUpdateSpamCheck,

        [Display(Name = "mail_settings.template.update")]
        MailSettingsUpdateTemplaet,

        [Display(Name = "mail_settings.template.read")]
        MailSettingsReadTemplaet,

        #endregion

        #region Mail

        [Display(Name = "mail.batch.create")] MailBatchCreateBatch,
        [Display(Name = "mail.batch.update")] MailBatchUpdateBatch,
        [Display(Name = "mail.batch.read")] MailBatchReadBatch,
        [Display(Name = "mail.batch.delete")] MailBatchDeleteBatch,
        [Display(Name = "mail.send")] MailSend,

        #endregion

        #region Marketing Campaign

        [Display(Name = "marketing_campaigns.create")]
        MarketingCampaignsCreate,

        [Display(Name = "marketing_campaigns.update")]
        MarketingCampaignsUdpate,

        [Display(Name = "marketing_campaigns.delete")]
        MarketingCampaignsDelete,

        [Display(Name = "marketing_campaigns.read")]
        MarketingCampaignsRead,

        #endregion

        #region News Letters

        [Display(Name = "newsletter.create")] NewsLetterCreate,
        [Display(Name = "newsletter.update")] NewsLetterUdpate,
        [Display(Name = "newsletter.delete")] NewsLetterDelete,
        [Display(Name = "newsletter.read")] NewsLetterRead,

        #endregion

        #region Partners

        [Display(Name = "partner_settings.new_relic.read")]
        PartnerSettingsReadNewRelic,

        [Display(Name = "partner_settings.new_relic.update")]
        PartnerSettingsUpdateNewRelic,

        [Display(Name = "partner_settings.sendwithus.update")]
        PartnerSettingsUpdateSendWithUs,

        [Display(Name = "partner_settings.sendwithus.read")]
        PartnerSettingsReadSendWithUs,

        [Display(Name = "partner_settings.read")]
        PartnerSettingsRead,

        #endregion

        #region Scheduled Sends

        [Display(Name = "scheduled_sends.create")]
        ScheduledSendCreate,

        [Display(Name = "scheduled_sends.update")]
        ScheduledSendUdpate,

        [Display(Name = "scheduled_sends.delete")]
        ScheduledSendDelete,

        [Display(Name = "scheduled_sends.read")]
        ScheduledSendRead,

        #endregion

        #region User Scheduled Sends

        [Display(Name = "user.scheduled_sends.create")]
        UserScheduledSendCreate,

        [Display(Name = "user.scheduled_sends.update")]
        UserScheduledSendUdpate,

        [Display(Name = "user.scheduled_sends.delete")]
        UserScheduledSendDelete,

        [Display(Name = "user.scheduled_sends.read")]
        UserScheduledSendRead,

        #endregion

        #region Sub User

        [Display(Name = "subusers.create")] SubUsersCreate,
        [Display(Name = "subusers.update")] SubUsersUdpate,
        [Display(Name = "subusers.delete")] SubUsersDelete,
        [Display(Name = "subusers.read")] SubUsersRead,

        [Display(Name = "subusers.credits.create")]
        SubUsersCreateCredit,

        [Display(Name = "subusers.credits.update")]
        SubUsersUpdateCredit,

        [Display(Name = "subusers.credits.delete")]
        SubUsersDeleteCredit,

        [Display(Name = "subusers.credits.read")]
        SubUsersReadCredit,

        [Display(Name = "subusers.credits.remaining.read")]
        SubUsersReadRemainingCredit,

        [Display(Name = "subusers.credits.remaining.update")]
        SubUsersUpdateRemainingCredit,

        [Display(Name = "subusers.credits.remaining.delete")]
        SubUsersDeleteRemainingCredit,

        [Display(Name = "subusers.credits.remaining.create")]
        SubUsersCreateRemainingCredit,

        [Display(Name = "subusers.monitor.create")]
        SubUsersCreateMonitor,

        [Display(Name = "subusers.monitor.update")]
        SubUsersUdpateMonitor,

        [Display(Name = "subusers.monitor.delete")]
        SubUsersDeleteMonitor,

        [Display(Name = "subusers.monitor.read")]
        SubUsersReadMonitor,

        [Display(Name = "subusers.reputations.read")]
        SubUsersReadReputation,

        [Display(Name = "subusers.stats.read")]
        SubUsersReadStatistics,

        [Display(Name = "subusers.stats.monthly.read")]
        SubUsersReadMonthlyStatistics,

        [Display(Name = "subusers.stats.sums.read")]
        SubUsersReadStatisticsSums,

        [Display(Name = "subusers.summary.read")]
        SubUsersReadSummary,

        #endregion

        #region Supression

        [Display(Name = "suppression.create")] SupressionCreate,
        [Display(Name = "suppression.update")] SupressionUdpate,
        [Display(Name = "suppression.delete")] SupressionDelete,
        [Display(Name = "suppression.read")] SupressionRead,

        [Display(Name = "suppression.bounces.create")]
        SupressionCreateBounces,

        [Display(Name = "suppression.bounces.update")]
        SupressionUdpateBounces,

        [Display(Name = "suppression.bounces.delete")]
        SupressionDeleteBounces,

        [Display(Name = "suppression.bounces.read")]
        SupressionReadBounces,

        [Display(Name = "suppression.invalid_emails.create")]
        SupressionCreateInvalidEmails,

        [Display(Name = "suppression.invalid_emails.update")]
        SupressionUdpateInvalidEmails,

        [Display(Name = "suppression.invalid_emails.delete")]
        SupressionDeleteInvalidEmails,

        [Display(Name = "suppression.invalid_emails.read")]
        SupressionReadInvalidEmails,

        [Display(Name = "suppression.spam_reports.create")]
        SupressionCreateSpamReports,

        [Display(Name = "suppression.spam_reports.update")]
        SupressionUdpateSpamReports,

        [Display(Name = "suppression.spam_reports.delete")]
        SupressionDeleteSpamReports,

        [Display(Name = "suppression.spam_reports.read")]
        SupressionReadSpamReports,

        [Display(Name = "suppression.unsubscribes.create")]
        SupressionCreateUnSubscribes,

        [Display(Name = "suppression.unsubscribes.update")]
        SupressionUdpateUnSubscribes,

        [Display(Name = "suppression.unsubscribes.delete")]
        SupressionDeleteUnSubscribes,

        [Display(Name = "suppression.unsubscribes.read")]
        SupressionReadUnSubscribes,

        #endregion

        #region Team Mate

        [Display(Name = "teammates.create")] TeamMateCreate,
        [Display(Name = "teammates.update")] TeamMateUdpate,
        [Display(Name = "teammates.delete")] TeamMateDelete,
        [Display(Name = "teammates.read")] TeamMateRead,

        #endregion

        #region Template

        [Display(Name = "templates.create")] TemplateCreate,
        [Display(Name = "templates.update")] TemplateUdpate,
        [Display(Name = "templates.delete")] TemplateDelete,
        [Display(Name = "templates.read")] TemplateRead,

        [Display(Name = "templates.versions.activate.create")]
        TemplateCreateVersionActivation,

        [Display(Name = "templates.versions.activate.update")]
        TemplateUdpateVersionActivation,

        [Display(Name = "templates.versions.activate.delete")]
        TemplateDeleteVersionActivation,

        [Display(Name = "templates.versions.activate.read")]
        TemplateReadVersionActivation,

        [Display(Name = "templates.versions.create")]
        TemplateCreateVersion,

        [Display(Name = "templates.versions.update")]
        TemplateUdpateVersion,

        [Display(Name = "templates.versions.delete")]
        TemplateDeleteVersion,

        [Display(Name = "templates.versions.read")]
        TemplateReadVersion,

        #endregion

        #region Tracking Settings

        [Display(Name = "tracking_settings.click.read")]
        TrackingSettingsReadClicks,

        [Display(Name = "tracking_settings.click.update")]
        TrackingSettingsUpdateClicks,

        [Display(Name = "tracking_settings.google_analytics.read")]
        TrackingSettingsReadGoogleAnalytics,

        [Display(Name = "tracking_settings.google_analytics.update")]
        TrackingSettingsUpdateGoogleAnalytics,

        [Display(Name = "tracking_settings.open.read")]
        TrackingSettingsReadOpens,

        [Display(Name = "tracking_settings.open.update")]
        TrackingSettingsUpdateOpens,

        [Display(Name = "tracking_settings.subscription.read")]
        TrackingSettingsReadSubscriptions,

        [Display(Name = "tracking_settings.subscription.update")]
        TrackingSettingsUpdateSubscriptions,

        [Display(Name = "tracking_settings.read")]
        TrackingSettingsRead,

        #endregion

        #region User Account Read

        [Display(Name = "user.account.read")] ReadUserAccount,
        [Display(Name = "user.credits.read")] ReadUserCredits,
        [Display(Name = "user.email.read")] ReadUserEmail,
        [Display(Name = "user.email.create")] CreateUserEmail,
        [Display(Name = "user.email.update")] UpdateUserEmail,
        [Display(Name = "user.email.delete")] DeleteUserEmail,

        [Display(Name = "user.multifactor_authentication.read")]
        ReadUserMultiFactorAuthentication,

        [Display(Name = "user.multifactor_authentication.create")]
        CreateUserMultiFactorAuthentication,

        [Display(Name = "user.multifactor_authentication.update")]
        UpdateUserMultiFactorAuthentication,

        [Display(Name = "user.multifactor_authentication.delete")]
        DeleteUserMultiFactorAuthentication,
        [Display(Name = "user.password.read")] ReadUserPassword,

        [Display(Name = "user.password.update")]
        UpdateUserPassword,
        [Display(Name = "user.profile.read")] ReadUserProfile,

        [Display(Name = "user.profile.update")]
        UpdateUserProfile,

        [Display(Name = "user.settings.enforced_tls.read")]
        ReadEnforcedTls,

        [Display(Name = "user.settings.enforced_tls.update")]
        UpdateEnforcedTls,
        [Display(Name = "user.timezone.read")] ReadUserTimeZone,

        [Display(Name = "user.timezone.create")]
        CreateUserTimeZone,

        [Display(Name = "user.timezone.update")]
        UpdateUserTimeZone,

        [Display(Name = "user.timezone.delete")]
        DeleteUserTimeZone,

        #endregion

        #region White Label

        [Display(Name = "whitelabel.read")] ReadWhiteLabel,
        [Display(Name = "whitelabel.create")] CreateWhiteLabel,
        [Display(Name = "whitelabel.update")] UpdateWhiteLabel,
        [Display(Name = "whitelabel.delete")] DeleteWhiteLabel,

        #endregion

        #region Access Setting

        [Display(Name = "access_settings.activity.read")]
        ReadAccessActivitySettings,

        [Display(Name = "access_settings.whitelist.read")]
        ReadWhiteList,

        [Display(Name = "access_settings.whitelist.create")]
        CreateWhiteList,

        [Display(Name = "access_settings.whitelist.update")]
        UpdateWhiteList,

        [Display(Name = "access_settings.whitelist.delete")]
        DeleteWhiteList

        #endregion
    }
}