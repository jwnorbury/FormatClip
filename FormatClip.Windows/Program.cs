using FormatClip.Core;
using System;
using System.Windows;

namespace FormatClip.Windows
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var input = GetInput(args);
            var writer = FormatterFactory.Create(input);
            var result = writer.Format();
            if (!string.IsNullOrWhiteSpace(result) && !result.Equals(input))
            {
                Clipboard.SetText(result);
            }
        }

        private static string GetInput(string[] args)
        {
            if (args.Length > 0)
            {
                return args[0];
            }

            return Clipboard.GetText();
        }
    }
}
