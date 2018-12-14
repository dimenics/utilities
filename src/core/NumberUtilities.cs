﻿using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Dime.Utilities
{
    /// <summary>
    /// Utilities that extend the capabilities of working with numbers
    /// </summary>
    public static class NumberUtilities
    {
        /// <summary>
        /// Returns null if the value equals or is smaller than zero
        /// </summary>
        /// <param name="value">The nullable integer to inspect</param>
        /// <returns>The same value if it is larger than zero, null if not</returns>
        public static int? NullIfNegative(this int? value) 
            => value.GetValueOrDefault() <= 0 ? null : value;

        /// <summary>
        /// Returns null if the value equals or is smaller than zero
        /// </summary>
        /// <param name="value">The nullable long to inspect</param>
        /// <returns>The same value if it is larger than zero, null if not</returns>
        public static long? NullIfNegative(this long? value) 
            => value.GetValueOrDefault() <= 0 ? null : value;

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int? ToNullableInt(this string s) 
            => int.TryParse(s, out int i) ? (int?) i : null;

        /// <summary>
        ///
        /// </summary>
        /// <param name="s">The string to parse</param>
        /// <returns></returns>
        public static long? ToNullableLong(this string s)
            => long.TryParse(s, out long i) ? (long?) i : null;

        /// <summary>
        /// Returns null if the value is zero.
        /// <para>This is a utility that is useful when inserting FK properties into SQL databases, where the default int value raises exceptions</para>
        /// </summary>
        /// <param name="number">The number to inspect</param>
        /// <returns>The original number if the value doesn't equal zero</returns>
        public static int? GetNullIfZero(this int? number) 
            => number.GetValueOrDefault() == default(int) ? null : number;

        /// <summary>
        /// Returns null if the value is zero.
        /// <para>This is a utility that is useful when inserting FK properties into SQL databases, where the default long value raises exceptions</para>
        /// </summary>
        /// <param name="number">The number to inspect</param>
        /// <returns>The original number if the value doesn't equal zero</returns>
        public static long? GetNullIfZero(this long? number) 
            => number.GetValueOrDefault() == default(int) ? null : number;

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Format<T>(this int input, string property)
        {
            PropertyInfo prop = typeof(T).GetProperty(property, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            DisplayFormatAttribute displayFormatAttribute = (DisplayFormatAttribute)prop.GetCustomAttributes(typeof(DisplayFormatAttribute), true).FirstOrDefault();

            return string.Format(displayFormatAttribute.DataFormatString, input);
        }
    }
}