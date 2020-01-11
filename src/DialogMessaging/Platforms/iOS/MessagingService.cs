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
        #endregion
    }
}
