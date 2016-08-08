using System.Configuration;
using System.Xml;

namespace Uol.PagSeguro.Configuration
{
    public class ConfigurationTextElement<T> : PagSeguroConfigurationElement
    {
        private T _value;
        protected override void DeserializeElement(XmlReader reader,
                                bool serializeCollectionKey)
        {
            _value = (T)reader.ReadElementContentAs(typeof(T), null);
        }

        public T Value
        {
            get { return _value; }
        }
    }
}
