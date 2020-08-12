using DialogMessaging.Infrastructure;

namespace DialogMessaging
{
    public static partial class MessagingService
    {
        #region Public Methods
        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        public static void Init()
            => MessagingServiceCore.Init(null);

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="messagingService">The IMessagingService to use.</param>
        public static void Init(IMessagingService messagingService)
            => MessagingServiceCore.Init(messagingService);
        #endregion
    }
}
