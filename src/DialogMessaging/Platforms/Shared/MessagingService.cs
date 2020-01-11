namespace DialogMessaging
{
    public static partial class MessagingService
    {
        #region Static Properties
        /// <summary>
        /// Gets the current MessagingService instance, if any.
        /// </summary>
        public static IMessagingService Instance { get; private set; }

        /// <summary>
        /// Gets or sets whether to enable verbose logging.
        /// </summary>
        public static bool VerboseLogging { get; set; }
        #endregion
    }
}
