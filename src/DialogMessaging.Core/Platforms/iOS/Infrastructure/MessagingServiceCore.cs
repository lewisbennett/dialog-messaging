using DialogMessaging.Platforms.iOS;

namespace DialogMessaging.Infrastructure
{
    public static partial class MessagingServiceCore
    {
        #region Public Methods
        public static void Init(IMessagingService messagingService)
        {
            Instance = messagingService ?? new MessagingServiceImpl();
        }
        #endregion
    }
}
