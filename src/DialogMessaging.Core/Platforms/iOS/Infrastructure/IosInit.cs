using DialogMessaging.Infrastructure;

namespace DialogMessaging.Core.Platforms.iOS.Infrastructure
{
    public static class IosInit
    {
        #region Public Methods
        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="messagingService">The messaging service.</param>
        public static void Init(IMessagingService messagingService)
        {
            MessagingServiceCore.Instance = messagingService ?? new IosMessagingService();
        }
        #endregion
    }
}
