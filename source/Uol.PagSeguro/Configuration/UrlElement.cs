using System;
using System.Configuration;

namespace Uol.PagSeguro.Configuration
{
    public class UrlElement : ConfigurationElement
    {
        public const string LinkKey = "Link";

        [ConfigurationProperty(LinkKey, IsRequired = true)]
        public TextElement Link
        {
            get { return (TextElement)this[LinkKey]; }
            set { this[LinkKey] = value; }
        }
    }
}
