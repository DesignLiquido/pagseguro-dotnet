using System;
using System.Configuration;

namespace Uol.PagSeguro.Configuration
{
    public class UrlsElement : ConfigurationElement
    {
        public const string PaymentKey = "Payment";
        public const string PaymentRedirectKey = "PaymentRedirect";
        public const string NotificationKey = "Notification";
        public const string SearchKey = "Search";
        public const string SearchAbandonedKey = "SearchAbandoned";
        public const string CancelKey = "Cancel";
        public const string RefundKey = "Refund";
        public const string PreApprovalKey = "PreApproval";
        public const string DirectPaymentKey = "DirectPayment";
        public const string AuthorizationKey = "Authorization";

        [ConfigurationProperty(PaymentKey, IsRequired = true)]
        public UrlElement Payment
        {
            get { return (UrlElement)this[PaymentKey]; }
            set { this[PaymentKey] = value; }
        }

        [ConfigurationProperty(PaymentRedirectKey, IsRequired = true)]
        public UrlElement PaymentRedirect
        {
            get { return (UrlElement)this[PaymentRedirectKey]; }
            set { this[PaymentRedirectKey] = value; }
        }

        [ConfigurationProperty(NotificationKey, IsRequired = true)]
        public UrlElement Notification
        {
            get { return (UrlElement)this[PaymentKey]; }
            set { this[PaymentKey] = value; }
        }

        [ConfigurationProperty(SearchKey, IsRequired = true)]
        public UrlElement Search
        {
            get { return (UrlElement)this[SearchKey]; }
            set { this[SearchKey] = value; }
        }

        [ConfigurationProperty(SearchAbandonedKey, IsRequired = true)]
        public UrlElement SearchAbandoned
        {
            get { return (UrlElement)this[SearchAbandonedKey]; }
            set { this[SearchAbandonedKey] = value; }
        }

        [ConfigurationProperty(CancelKey, IsRequired = true)]
        public UrlElement Cancel
        {
            get { return (UrlElement)this[CancelKey]; }
            set { this[CancelKey] = value; }
        }

        [ConfigurationProperty(RefundKey, IsRequired = true)]
        public UrlElement Refund
        {
            get { return (UrlElement)this[RefundKey]; }
            set { this[RefundKey] = value; }
        }

        [ConfigurationProperty(PreApprovalKey, IsRequired = true)]
        public PreApprovalElement PreApproval
        {
            get { return (PreApprovalElement)this[PreApprovalKey]; }
            set { this[PreApprovalKey] = value; }
        }

        [ConfigurationProperty(DirectPaymentKey, IsRequired = true)]
        public DirectPaymentElement DirectPayment
        {
            get { return (DirectPaymentElement)this[DirectPaymentKey]; }
            set { this[DirectPaymentKey] = value; }
        }

        [ConfigurationProperty(AuthorizationKey, IsRequired = true)]
        public AuthorizationElement Authorization
        {
            get { return (AuthorizationElement)this[AuthorizationKey]; }
            set { this[AuthorizationKey] = value; }
        }
    }
}
