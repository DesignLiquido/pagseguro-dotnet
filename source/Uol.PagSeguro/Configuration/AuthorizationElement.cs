using System.Configuration;

namespace Uol.PagSeguro.Configuration
{
    public class AuthorizationElement : ConfigurationElement
    {
        public const string AuthorizationRequestKey = "AuthorizationRequest";
        public const string AuthorizationURLKey = "AuthorizationURL";
        public const string AuthorizationSearchKey = "AuthorizationSearch";
        public const string AuthorizationNotificationKey = "AuthorizationNotification";

        [ConfigurationProperty(AuthorizationRequestKey, IsRequired = true)]
        public UrlElement AuthorizationRequest
        {
            get { return (UrlElement)this[AuthorizationRequestKey]; }
            set { this[AuthorizationRequestKey] = value; }
        }

        [ConfigurationProperty(AuthorizationURLKey, IsRequired = true)]
        public UrlElement AuthorizationURL
        {
            get { return (UrlElement)this[AuthorizationURLKey]; }
            set { this[AuthorizationURLKey] = value; }
        }

        [ConfigurationProperty(AuthorizationSearchKey, IsRequired = true)]
        public UrlElement AuthorizationSearch
        {
            get { return (UrlElement)this[AuthorizationSearchKey]; }
            set { this[AuthorizationSearchKey] = value; }
        }

        [ConfigurationProperty(AuthorizationNotificationKey, IsRequired = true)]
        public UrlElement AuthorizationNotification
        {
            get { return (UrlElement)this[AuthorizationNotificationKey]; }
            set { this[AuthorizationNotificationKey] = value; }
        }
    }
}
