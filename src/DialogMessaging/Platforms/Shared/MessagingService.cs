using DialogMessaging.Infrastructure;

namespace DialogMessaging
{
    public static partial class MessagingService
    {
        #region Properties
        /// <summary>
        /// Gets or sets the messaging delegate, if any.
        /// </summary>
        public static IMessagingDelegate Delegate
        {
            get => MessagingServiceCore.Delegate;

            set => MessagingServiceCore.Delegate = value;
        }

        /// <summary>
        /// Gets the current messaging service instance, if any.
        /// </summary>
        public static IMessagingService Instance => MessagingServiceCore.Instance;

        /// <summary>
        /// Gets or sets whether to enable verbose logging.
        /// </summary>
        public static bool VerboseLogging
        {
            get => MessagingServiceCore.VerboseLogging;

            set => MessagingServiceCore.VerboseLogging = value;
        }
        #endregion
    }
}
