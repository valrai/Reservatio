using System;
using System.ComponentModel;

namespace Reservatio.Models.Extensions
{
    /// <summary>
    /// Useful extensions for enumerations
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        ///  Get the description from a Enum.
        /// </summary>
        /// <typeparam name="TEnum">Enum type</typeparam>
        /// <param name="val">Enum option</param>
        /// <returns>The description of the informed Enum option</returns>

        public static string GetDescriptionString<TEnum>(this TEnum val)
            where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException($"{nameof(TEnum)} must be an enumerated type");

            var attributes = (DescriptionAttribute[])val
                .GetType()
                .GetField(val.ToString() ?? string.Empty)
                ?.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes != null && attributes.Length > 0
                ? attributes[0].Description
                : string.Empty;
        }
    }
}
