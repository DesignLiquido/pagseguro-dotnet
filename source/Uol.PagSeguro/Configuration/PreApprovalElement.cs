using System.Configuration;

namespace Uol.PagSeguro.Configuration
{
    public class PreApprovalElement : ConfigurationElement
    {
        public const string LinkKey = "Link";
        public const string PreApprovalRequestKey = "PreApprovalRequest";
        public const string PreApprovalRedirectKey = "PreApprovalRedirect";
        public const string PreApprovalNotificationKey = "PreApprovalNotification";
        public const string PreApprovalSearchKey = "PreApprovalSearch";
        public const string PreApprovalCancelKey = "PreApprovalCancelKey";
        public const string PreApprovalPaymentKey = "PreApprovalPaymentKey";

        [ConfigurationProperty(LinkKey, IsRequired = true)]
        public TextElement Link
        {
            get { return (TextElement)this[LinkKey]; }
            set { this[LinkKey] = value; }
        }

        [ConfigurationProperty(PreApprovalRequestKey, IsRequired = true)]
        public UrlElement PreApprovalRequest
        {
            get { return (UrlElement)this[PreApprovalRequestKey]; }
            set { this[PreApprovalRequestKey] = value; }
        }

        [ConfigurationProperty(PreApprovalRedirectKey, IsRequired = true)]
        public UrlElement PreApprovalRedirect
        {
            get { return (UrlElement)this[PreApprovalRedirectKey]; }
            set { this[PreApprovalRedirectKey] = value; }
        }

        [ConfigurationProperty(PreApprovalNotificationKey, IsRequired = true)]
        public UrlElement PreApprovalNotification
        {
            get { return (UrlElement)this[PreApprovalNotificationKey]; }
            set { this[PreApprovalNotificationKey] = value; }
        }

        [ConfigurationProperty(PreApprovalSearchKey, IsRequired = true)]
        public UrlElement PreApprovalSearch
        {
            get { return (UrlElement)this[PreApprovalSearchKey]; }
            set { this[PreApprovalSearchKey] = value; }
        }

        [ConfigurationProperty(PreApprovalCancelKey, IsRequired = true)]
        public UrlElement PreApprovalCancel
        {
            get { return (UrlElement)this[PreApprovalCancelKey]; }
            set { this[PreApprovalCancelKey] = value; }
        }

        [ConfigurationProperty(PreApprovalPaymentKey, IsRequired = true)]
        public UrlElement PreApprovalPayment
        {
            get { return (UrlElement)this[PreApprovalPaymentKey]; }
            set { this[PreApprovalPaymentKey] = value; }
        }
    }
}
