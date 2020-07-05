using System;

namespace FormatClip.Core
{
    public class FormatterFactory
    {
        /// <summary>
        /// Create instance of <see cref="FormatterBase"/> implementation.
        /// </summary>
        /// <param name="input">String to format.</param>
        /// <returns>Formatter capable of processing <see cref="input"/>.</returns>
        public static FormatterBase Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new PassThroughFormatter(input);
            }

            return input.AsSpan().TrimStart()[0] switch
            {
                '<' => new XmlFormatter(input),
                '{' => new JsonFormatter(input),
                '[' => new JsonFormatter(input),
                _ => new PassThroughFormatter(input)
            };
        }
    }
}
