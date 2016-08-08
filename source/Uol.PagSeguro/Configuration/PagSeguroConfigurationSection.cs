using System.Configuration;

namespace Uol.PagSeguro.Configuration
{
    public class PagSeguroConfigurationSection : ConfigurationSection
    {
        public const string UrlsKey = "Urls";        
        public const string CredentialKey = "Credential";
        public const string ConfigurationKey = "Configuration";

        //public static PagSeguroConfigurationSection GetConfiguration()
        //{
        //    return (PagSeguroConfigurationSection)ConfigurationManager.GetSection("PagSeguro") ?? new PagSeguroConfigurationSection();
        //}

        [ConfigurationProperty(UrlsKey, IsRequired = true)]
        public UrlsElement Urls
        {
            get { return (UrlsElement)this[UrlsKey]; }
            set { this[UrlsKey] = value; }
        }

        [ConfigurationProperty(CredentialKey, IsRequired = true)]
        public CredentialElement Credential
        {
            get { return (CredentialElement)this[CredentialKey]; }
            set { this[CredentialKey] = value; }
        }

        [ConfigurationProperty(ConfigurationKey, IsRequired = true)]
        public PagSeguroConfigurationElement Configuration
        {
            get { return (PagSeguroConfigurationElement)this[ConfigurationKey]; }
            set { this[ConfigurationKey] = value; }
        }
    }
}
