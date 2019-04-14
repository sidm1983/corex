﻿using System;
using System.Collections.Generic;
[assembly: CLSCompliant(true)]
namespace corex.@string.extensions
{
    /// <summary>
    /// A class containing extension methods that convert a string into other types.
    /// </summary>
    public static class StringConversion
    {
        /// <summary>
        /// This extension method converts a string to a Common Language Runtime (CLR) type that has an equivalent value.
        /// </summary>
        /// <param name="input">The string to convert</param>
        /// <typeparam name="T">The CLR type into which the input string will be converted</typeparam>
        /// <returns>An instance of the CLR type that has an equivalent value to the input string</returns>
        public static T To<T>(this string input) => (T) Convert.ChangeType(input, typeof(T));

        /// <summary>
        /// This extension method converts a string to a Common Language Runtime (CLR) type that has an equivalent value.
        /// Additionally, this method also accepts a default value which is returned if the string cannot be converted to the specified type.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T To<T>(this string input, T defaultValue)
        {
            try
            {
                var output = To<T>(input);

                if (output != null)
                {
                    return output;
                }
            }
            catch {} //Intentionally ignoring any exceptions as we just want it to return the default value that was passed in if an exception does occur.

            return defaultValue;
        }
    }
}
