using DialogMessaging.Platforms.iOS;

namespace DialogMessaging
{
    public static partial class MessagingService
    {
        #region Initialization
        public static void Init()
        {
            Instance = new MessagingServiceImpl();
        }

        public static void Init(IMessagingService messagingService)
        {
            Instance = messagingService;
        }
        #endregion
    }
}
