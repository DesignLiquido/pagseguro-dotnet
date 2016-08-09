using System.Configuration;

namespace Uol.PagSeguro.Configuration
{
    public class PagSeguroConfigurationElement : ConfigurationElement
    {
        public const string LibVersionKey = "LibVersion";
        public const string FormUrlEncodedKey = "FormUrlEncoded";
        public const string EncodingKey = "Encoding";
        public const string RequestTimeoutKey = "RequestTimeout";
        public const string SandboxKey = "Sandbox";

        [ConfigurationProperty(LibVersionKey, IsRequired = true)]
        public TextElement LibVersion
        {
            get { return (TextElement)this[LibVersionKey]; }
            set { this[LibVersionKey] = value; }
        }

        [ConfigurationProperty(FormUrlEncodedKey, IsRequired = true)]
        public TextElement FormUrlEncoded
        {
            get { return (TextElement)this[FormUrlEncodedKey]; }
            set { this[FormUrlEncodedKey] = value; }
        }

        [ConfigurationProperty(EncodingKey, IsRequired = true)]
        public TextElement Encoding
        {
            get { return (TextElement)this[EncodingKey]; }
            set { this[EncodingKey] = value; }
        }

        [ConfigurationProperty(RequestTimeoutKey, IsRequired = true)]
        public TextElement RequestTimeout
        {
            get { return (TextElement)this[RequestTimeoutKey]; }
            set { this[RequestTimeoutKey] = value; }
        }

        /// <summary>
        /// Configure Sandbox TextElement
        /// </summary>
        [ConfigurationProperty(SandboxKey, IsRequired = true)]
        public TextElement Sandbox
        {
            get { return (TextElement)this[SandboxKey]; }
            set { this[SandboxKey] = value; }
        }
    }
}
