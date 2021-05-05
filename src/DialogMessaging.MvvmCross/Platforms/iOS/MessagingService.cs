using DialogMessaging.Core.Platforms.iOS.Infrastructure;

namespace DialogMessaging.MvvmCross
{
    public static partial class MessagingService
    {
        #region Public Methods
        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        public static void Init()
        {
            Init(null);
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="messagingService">A custom messaging service.</param>
        public static void Init(IMessagingService messagingService)
        {
            IosInit.Init(messagingService);
        }
        #endregion
    }
}
