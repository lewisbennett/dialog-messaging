namespace DialogMessaging.Infrastructure
{
    public static partial class MessagingServiceCore
    {
        #region Properties
        public static IMessagingDelegate Delegate { get; set; }

        public static IMessagingService Instance { get; private set; }

        public static bool VerboseLogging { get; set; }
        #endregion
    }
}
