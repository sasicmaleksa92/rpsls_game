using Newtonsoft.Json;

namespace RockPaperScissorsLizardSpock.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool TryParseJson<T>(this string? json, out T result) where T : class
        {
            try
            {
                result = JsonConvert.DeserializeObject<T>(json);
                return result != null;
            }
            catch (JsonException)
            {
                result = null;
                return false;
            }
        }

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

    }
}