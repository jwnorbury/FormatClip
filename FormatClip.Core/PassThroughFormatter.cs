namespace FormatClip.Core
{
    /// <summary>
    /// Formatter to handle invalid input.
    /// </summary>
    public class PassThroughFormatter : FormatterBase
    {
        public PassThroughFormatter(string input) : base(input)
        { }

        /// <summary>
        /// Return the input.
        /// </summary>
        /// <returns>Unmodified input.</returns>
        public override string Format() => Input;
    }
}
