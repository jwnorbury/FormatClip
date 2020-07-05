namespace FormatClip.Core
{
    /// <summary>
    /// Formatter to handle invalid input.
    /// </summary>
    public class EmptyFormatter : FormatterBase
    {
        public EmptyFormatter() : base(string.Empty)
        { }

        /// <summary>
        /// Return an empty string.
        /// </summary>
        /// <returns>string.Empty</returns>
        public override string Format() => Input;
    }
}
