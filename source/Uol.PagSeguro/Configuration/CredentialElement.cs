using System.Configuration;

namespace Uol.PagSeguro.Configuration
{
    public class CredentialElement : ConfigurationElement
    {
        public const string EmailKey = "Email";
        public const string TokenKey = "Token";
        public const string SandboxEmailKey = "SandboxEmail";
        public const string SandboxTokenKey = "SandboxToken";
        public const string AppIdKey = "AppIdKey";
        public const string AppKeyKey = "AppKey";
        public const string SandboxAppIdKey = "SandboxAppId";
        public const string SandboxAppKeyKey = "SandboxAppKey";

        [ConfigurationProperty(EmailKey, IsRequired = true)]
        public TextElement Email
        {
            get { return (TextElement)this[EmailKey]; }
            set { this[EmailKey] = value; }
        }

        [ConfigurationProperty(TokenKey, IsRequired = true)]
        public TextElement Token
        {
            get { return (TextElement)this[TokenKey]; }
            set { this[TokenKey] = value; }
        }

        [ConfigurationProperty(SandboxEmailKey, IsRequired = true)]
        public TextElement SandboxEmail
        {
            get { return (TextElement)this[SandboxEmailKey]; }
            set { this[SandboxEmailKey] = value; }
        }

        [ConfigurationProperty(SandboxTokenKey, IsRequired = true)]
        public TextElement SandboxToken
        {
            get { return (TextElement)this[SandboxTokenKey]; }
            set { this[SandboxTokenKey] = value; }
        }

        [ConfigurationProperty(AppIdKey, IsRequired = true)]
        public TextElement AppId
        {
            get { return (TextElement)this[AppIdKey]; }
            set { this[AppIdKey] = value; }
        }

        [ConfigurationProperty(AppKeyKey, IsRequired = true)]
        public TextElement AppKey
        {
            get { return (TextElement)this[AppKeyKey]; }
            set { this[AppKeyKey] = value; }
        }

        [ConfigurationProperty(SandboxAppIdKey, IsRequired = true)]
        public TextElement SandboxAppId
        {
            get { return (TextElement)this[SandboxAppIdKey]; }
            set { this[SandboxAppIdKey] = value; }
        }

        [ConfigurationProperty(SandboxAppKeyKey, IsRequired = true)]
        public TextElement SandboxAppKey
        {
            get { return (TextElement)this[SandboxAppKeyKey]; }
            set { this[SandboxAppKeyKey] = value; }
        }
    }
}
