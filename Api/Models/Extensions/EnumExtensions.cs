using System;
using System.ComponentModel;

namespace Reservatio.Models.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescriptionString<TEnum>(this TEnum val)
            where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException($"{nameof(TEnum)} must be an enumerated type");

            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
                .GetType()
                .GetField(val.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
