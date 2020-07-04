namespace FormatClip.Core
{
    public abstract class FormatterBase
    {
        internal string Input { get; }

        public FormatterBase(string input)
        {
            Input = input;
        }

        /// <summary>
        /// Format <see cref="Input"/>.
        /// </summary>
        /// <returns>Formatted <see cref="Input"/>.</returns>
        public abstract string Format();
    }
}
