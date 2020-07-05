using Xunit;

namespace FormatClip.Core.Tests
{
    public class FormatterFactoryTests
    {
        [Fact]
        public void InputXml_ReturnXmlFormatter()
        {
            var xml = "<note><to>Tove</to><from>Jani</from><heading>"
                + "Reminder</heading><body>Don't forget me this weekend!</body></note>";
            var formatter = FormatterFactory.Create(xml);
            Assert.IsType<XmlFormatter>(formatter);
        }

        [Fact]
        public void InputJsonObject_ReturnJsonFormatter()
        {
            var json = "{ \"name\": \"Bob\" }";
            var formatter = FormatterFactory.Create(json);
            Assert.IsType<JsonFormatter>(formatter);
        }

        [Fact]
        public void InputJsonArray_ReturnJsonFormatter()
        {
            var json = "[ 1, 2, 3, 4 ]";
            var formatter = FormatterFactory.Create(json);
            Assert.IsType<JsonFormatter>(formatter);
        }

        [Fact]
        public void InputJsonBlankSpace_ReturnJsonFormatter()
        {
            var json = "\n[ 1, 2, 3, 4 ]";
            var formatter = FormatterFactory.Create(json);
            Assert.IsType<JsonFormatter>(formatter);
        }

        [Fact]
        public void EmptyInput_ReturnEmptyFormatter()
        {
            var formatter = FormatterFactory.Create(string.Empty);
            Assert.IsType<PassThroughFormatter>(formatter);
        }

        [Fact]
        public void NullInput_ReturnEmptyFormatter()
        {
            var formatter = FormatterFactory.Create(null);
            Assert.IsType<PassThroughFormatter>(formatter);
        }

        [Fact]
        public void InvalidInput_ReturnEmptyFormatter()
        {
            var input = "0d599f0ec05c3bda8c3b8a68c32a1b47";
            var formatter = FormatterFactory.Create(input);
            Assert.IsType<PassThroughFormatter>(formatter);
        }
    }
}
