using DialogMessaging.Schema;

namespace DialogMessaging.Infrastructure
{
    internal static class Log
    {
        #region Public Methods
        /// <summary>
        /// Writes a debugging message to the console.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="message">The message.</param>
        public static void Debug(string category, string message)
        {
            if (MessagingServiceCore.VerboseLogging)
                Write(category, message, LogLevel.Debug);
        }

        /// <summary>
        /// Writes an error to the console.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="message">The message.</param>
        public static void Error(string category, string message)
        {
            Write(category, message, LogLevel.Error);
        }

        /// <summary>
        /// Writes information to the console.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="message">The message.</param>
        public static void Info(string category, string message)
        {
            Write(category, message, LogLevel.Info);
        }

        /// <summary>
        /// Writes a warning to the console.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="message">The message.</param>
        public static void Warning(string category, string message)
        {
            Write(category, message, LogLevel.Warning);
        }

        /// <summary>
        /// Writes a message to the console.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="message">The message.</param>
        /// <param name="logLevel">The log level.</param>
        public static void Write(string category, string message, LogLevel logLevel)
        {
            System.Diagnostics.Debug.WriteLine($"[{logLevel}][{category}] {message}");
        }
        #endregion
    }
}
