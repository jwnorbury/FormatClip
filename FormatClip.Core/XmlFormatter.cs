using System.Text;
using System.Xml;

namespace FormatClip.Core
{
    /// <summary>
    /// Formatter to process JSON string.
    /// </summary>
    public class XmlFormatter : FormatterBase
    {
        public XmlFormatter(string input) : base(input)
        { }

        /// <summary>
        /// Format XML input string.
        /// </summary>
        /// <returns>Formatted XML string.</returns>
        public override string Format()
        {
            var xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.LoadXml(Input);
            }
            catch 
            {
                return Input;
            }

            return Format(xmlDocument);
        }

        private string Format(XmlDocument xmlDocument)
        {
            var xmlWritterSettings = new XmlWriterSettings()
            {
                Indent = true,
                OmitXmlDeclaration = true,
                Encoding = Encoding.UTF8
            };
            var sb = new StringBuilder();
            using var xmlWriter = XmlWriter.Create(sb, xmlWritterSettings);
            xmlDocument.WriteContentTo(xmlWriter);
            xmlWriter.Flush();
            return sb.ToString();
        }
    }
}
