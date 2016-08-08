using System.Configuration;

namespace Uol.PagSeguro.Configuration
{
    public class DirectPaymentElement : ConfigurationElement
    {
        public const string SessionKey = "Session";
        public const string InstallmentKey = "Installment";
        public const string TransactionsKey = "Transactions";

        [ConfigurationProperty(SessionKey, IsRequired = true)]
        public UrlElement Session
        {
            get { return (UrlElement)this[SessionKey]; }
            set { this[SessionKey] = value; }
        }

        [ConfigurationProperty(InstallmentKey, IsRequired = true)]
        public UrlElement Installment
        {
            get { return (UrlElement)this[InstallmentKey]; }
            set { this[InstallmentKey] = value; }
        }

        [ConfigurationProperty(TransactionsKey, IsRequired = true)]
        public UrlElement Transactions
        {
            get { return (UrlElement)this[TransactionsKey]; }
            set { this[TransactionsKey] = value; }
        }
    }
}
