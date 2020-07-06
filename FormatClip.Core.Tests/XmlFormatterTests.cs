using System;
using System.IO;
using Xunit;

namespace FormatClip.Core.Tests
{
    public class XmlFormatterTests
    {
        [Fact]
        public void BasicXmlInput_FormattedOutput()
        {
            var input = "<foo><bar/></foo>";
            var xmlFormatter = new XmlFormatter(input);
            var actual = xmlFormatter.Format();
            var expected = $"<foo>{Environment.NewLine} <bar />{Environment.NewLine}</foo>";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LargeXmlInput_FormattedOutput()
        {
            using var inputStream = this.GetType().Assembly.GetManifestResourceStream("FormatClip.Core.Tests.UnformattedXml.xml");
            using var inputReader = new StreamReader(inputStream);
            var input = inputReader.ReadToEnd();
            var xmlFormatter = new XmlFormatter(input);
            var actual = xmlFormatter.Format();

            using var resultStream = this.GetType().Assembly.GetManifestResourceStream("FormatClip.Core.Tests.ResultXml.xml");
            var resultReader = new StreamReader(resultStream);
            var expected = resultReader.ReadToEnd().Trim();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InvalidXmlInput_SameOutput()
        {
            var invalidXml = "invalid xml";
            var xmlFormatter = new XmlFormatter(invalidXml);
            var result = xmlFormatter.Format();
            Assert.Equal(invalidXml, result);
        }

        [Fact]
        public void NullInput_NullOutput()
        {
            var xmlFormatter = new XmlFormatter(null);
            var result = xmlFormatter.Format();
            Assert.Null(result);
        }

    }
}
