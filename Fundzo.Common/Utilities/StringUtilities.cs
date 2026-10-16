using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;


namespace Fundzo.Common.Utilities
{
    public static class StringUtilities
    {
        /// <summary>
        /// A basic check for whether the string is an email address.
        /// </summary>
        public static bool IsEmailAddress(string text)
        {
            return text != null && text.IndexOf('@') != -1;
        }

        /// <summary>
        /// Removes all characters apart from numbers in the given string.
        /// </summary>
        public static string StripAllButNumbers(string data)
        {
            string numbersOnly = Regex.Replace(data, "[^0-9.]", "");
            return numbersOnly;
        }

        /// <summary>
        /// Removes all characters apart from alpha in the given string.
        /// </summary>
        public static string StripAllButAlpha(string data)
        {
            string alphaOnly = Regex.Replace(data, "[^a-zA-Z']", "");
            return alphaOnly;
        }

        /// <summary>
        /// Removes the following characters from a string (. , ' - \).
        /// </summary>
        public static string CleanString(string s)
        {
            string cleanString = s;
            cleanString = cleanString.Replace(".", "");
            cleanString = cleanString.Replace(",", "");
            cleanString = cleanString.Replace("'", "");
            cleanString = cleanString.Replace("-", "");
            cleanString = cleanString.Replace(".\"", "");
            return cleanString;
        }

        /// <summary>
        /// Removes the specified characters from the specified string.
        /// </summary>
        public static string CleanString(string s, char[] chars)
        {
            string cleanString = s;

            foreach (var c in chars)
                cleanString = cleanString.Replace(c.ToString(), "");

            return cleanString;
        }

        private static Random random = new Random();
        /// <summary>
        /// Returns a randomly generated string of the specified length
        /// (UC, LC and Numbers only).
        /// </summary>
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// Converts the string to it's Base64 equivalent.
        /// </summary>
        public static string ToBase64(this string input)
        {
            // Base 64 string.
            string base64 = string.Empty;

            //create memory stream
            byte[] byteArray = Encoding.ASCII.GetBytes(input);
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                // Convert to base 64.
                stream.Position = 0;
                var bytes = stream.ToArray();
                base64 = Convert.ToBase64String(bytes);
            }

            // Return the base 64 string.
            return base64;
        }

        /// <summary>
        /// Checks if the string is a valid email address.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidEmailAddress(this string input)
        {
            try
            {
                var mailAddress = new MailAddress(input).Address;
                return true;
            }
            catch
            { 
                return false; 
            }
        }

        /// <summary>
        /// Generates a random string of the specified length with the specified options.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Random(this string input, int length, StringRandomOptions options = StringRandomOptions.Default, char[] special = null)
        {
            var random = new Random();

            var characters = new StringBuilder();

            var numbers = "0123456789";
            var uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var lowers = "abcdefghijklmnopqrstuvwxyz";
            var specials = "";
            if (special != null)
                specials = string.Join(' ', special).Replace(" ", "");

            if (options.HasFlag(StringRandomOptions.IncludeLower))
                characters.Append(lowers);
            if (options.HasFlag(StringRandomOptions.IncludeUpper))
                characters.Append(uppers);
            if (options.HasFlag(StringRandomOptions.IncludeNumbers))
                characters.Append(numbers);
            if (options.HasFlag(StringRandomOptions.IncludeSpecial))
                characters.Append(specials);

            return new string(Enumerable.Repeat(characters.ToString(), length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Flags]
        public enum StringRandomOptions
        {
            [Description("Include numbers, uppercase characters and lowercase characters")]
            Default = IncludeNumbers | IncludeUpper | IncludeLower,
            [Description("Include numbers")]
            IncludeNumbers = 1,
            [Description("Include uppercase characters")]
            IncludeUpper = 2,
            [Description("Include lowercase characters")]
            IncludeLower = 4,
            [Description("Include special characters defined within the special characters array")]
            IncludeSpecial = 8
        }

        /// <summary>
        /// Checks if the specified string only contains digits.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsOnlyDigits(this string input)
        {
            foreach (char c in input)
                if (c < '0' || c > '9')
                    return false;

            return true;
        }

        /// <summary>
        /// A string extension method that truncates.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <returns>A string.</returns>
        public static string Truncate(this string @this, int maxLength)
        {
            const string suffix = "...";

            if (@this == null || @this.Length <= maxLength)
            {
                return @this;
            }

            var strLength = maxLength - suffix.Length;
            return @this.Substring(0, strLength) + suffix;
        }

        /// <summary>
        /// A string extension method that truncates.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="suffix">The suffix.</param>
        /// <returns>A string.</returns>
        public static string Truncate(this string @this, int maxLength, string suffix)
        {
            if (@this == null || @this.Length <= maxLength)
            {
                return @this;
            }

            var strLength = maxLength - suffix.Length;
            return @this.Substring(0, strLength) + suffix;
        }
    }
}
