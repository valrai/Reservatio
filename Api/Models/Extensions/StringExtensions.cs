using System.Text.RegularExpressions;

namespace Reservatio.Models.Extensions
{
    /// <summary>
    /// Useful extensions for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Remove all special characters from a string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The informed string without any character other than numbers and letters.</returns>
        public static string RemoveAllSpecialCharacters(this string value, string textToReplace = "")
        {
            return string.IsNullOrEmpty(value)
                ? string.Empty
                : Regex.Replace(value, "[^a-zA-Z0-9_. ]+", textToReplace, RegexOptions.Compiled);
        }
    }
}
