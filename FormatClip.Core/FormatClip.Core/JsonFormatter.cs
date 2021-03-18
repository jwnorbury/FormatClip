using Newtonsoft.Json;

namespace FormatClip.Core
{
    /// <summary>
    /// Formatter to process JSON string.
    /// </summary>
    public class JsonFormatter : FormatterBase
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public JsonFormatter(string input) : base(input)
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            };
        }

        /// <summary>
        /// Format JSON input string.
        /// </summary>
        /// <returns>Formatted JSON string.</returns>
        public override string Format()
        {
            object obj;
            try
            {
                obj = JsonConvert.DeserializeObject(Input);
            }
            catch
            {
                return Input;
            }

            return JsonConvert.SerializeObject(obj, _jsonSerializerSettings);
        }
    }
}
