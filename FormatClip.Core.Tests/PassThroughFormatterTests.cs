using Xunit;

namespace FormatClip.Core.Tests
{
    public class PassThroughFormatterTests
    {
        [Fact]
        public void InputString_SameStringReturned()
        {
            var input = "asdf";
            var formatter = new PassThroughFormatter(input);
            var result = formatter.Format();
            Assert.Equal(input, result);
        }

        [Fact]
        public void NullInput_NullReturned()
        {
            var formatter = new PassThroughFormatter(null);
            var result = formatter.Format();
            Assert.Null(result);
        }

    }
}
