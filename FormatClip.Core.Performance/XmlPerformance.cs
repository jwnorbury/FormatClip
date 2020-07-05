using BenchmarkDotNet.Attributes;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace FormatClip.Core.Performance
{
    public class XmlPerformance
    {
        private string _xmlString;
        private XmlWriterSettings _xmlWriterSettings;

        [GlobalSetup]
        public void LoadXmlResource()
        {
            using var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("FormatClip.Core.Performance.SampleXml.xml");
            using var sr = new StreamReader(resource);
            _xmlString = sr.ReadToEnd();
            _xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true,
                OmitXmlDeclaration = true,
                Encoding = Encoding.UTF8
            };
        }

        [GlobalCleanup]
        public void ClearXml()
        {
            _xmlString = null;
        }

        [Benchmark(Baseline = true)]
        public string XmlDocumentStringBuilder()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(_xmlString);

            var sb = new StringBuilder();
            using var xmlWriter = XmlWriter.Create(sb, _xmlWriterSettings);
            xmlDocument.WriteContentTo(xmlWriter);
            xmlWriter.Flush();

            return sb.ToString();
        }

        [Benchmark]
        public string XmlDocumentStringWriter()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(_xmlString);

            using var sw = new StringWriter();
            using var xmlWriter = XmlWriter.Create(sw, _xmlWriterSettings);
            xmlDocument.WriteContentTo(xmlWriter);
            xmlWriter.Flush();

            return sw.ToString();
        }

        [Benchmark]
        public string XDocumentStringBuilder()
        {
            var xDocument = XDocument.Parse(_xmlString);

            var sb = new StringBuilder();
            using var xmlWriter = XmlWriter.Create(sb, _xmlWriterSettings);
            xDocument.WriteTo(xmlWriter);
            xmlWriter.Flush();

            return sb.ToString();
        }

        [Benchmark]
        public string XDocumentStringWriter()
        {
            var xDocument = XDocument.Parse(_xmlString);

            using var sw = new StringWriter();
            using var xmlWriter = XmlWriter.Create(sw, _xmlWriterSettings);
            xDocument.WriteTo(xmlWriter);
            xmlWriter.Flush();

            return sw.ToString();
        }
    }
}
