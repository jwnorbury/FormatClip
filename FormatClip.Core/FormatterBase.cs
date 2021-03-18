namespace FormatClip.Core
{
    public abstract class FormatterBase
    {
        protected string Input { get; }

        protected FormatterBase(string input)
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
