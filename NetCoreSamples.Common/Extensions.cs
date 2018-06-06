using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreSamples.Common
{
    public static class Extensions
    {
        /// <summary>
        /// Retrieves all exceptions messages from an exception and its inner exceptions
        /// </summary>
        /// <param name="ex">The exception to retrieve messages</param>
        /// <param name="message">Optional information to add before the message</param>
        /// <returns>String with all exceptions messages from exception and its inner exceptions</returns>
        public static string AllExceptionMessages(this Exception ex, string message = "[Exception]: ")
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(message + ex.Message);

            if (ex.InnerException != null)
            {
                sb.Append(ex.InnerException.AllExceptionMessages(" [InnerException]: "));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Same as String.Contains but is case insensitive
        /// </summary>
        /// <param name="text">The string to be cheked</param>
        /// <param name="value">The pattern to be cheked</param>
        /// <returns>A boolean if the text contains the value ignoring case</returns>
        public static bool ContainsIgnoreCase(this string text, string value)
        {
            if (text.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                return true;
            }

            return false;
        }
    }
}
