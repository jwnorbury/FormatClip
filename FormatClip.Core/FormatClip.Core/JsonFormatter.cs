using System;

namespace FormatClip.Core
{
    /// <summary>
    /// Formatter to process JSON string.
    /// </summary>
    public class JsonFormatter : FormatterBase
    {
        public JsonFormatter(string input) : base(input)
        { }

        /// <summary>
        /// Format JSON input string.
        /// </summary>
        /// <returns>Formatted JSON string.</returns>
        public override string Format()
        {
            throw new NotImplementedException();
        }
    }
}
