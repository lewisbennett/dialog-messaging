using Android.App;
using DialogMessaging.Infrastructure;
using DialogMessaging.Platforms.Droid.Infrastructure;
using ViewPump;

namespace DialogMessaging
{
    public static partial class MessagingService
    {
        #region Public Methods
        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="activity">The presumed top level Activity.</param>
        public static void Init(Activity activity)
        {
            MessagingServiceCore.Init(activity, null, null);

            AddInterceptor();
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="application">The presumed top level Application.</param>
        public static void Init(Application application)
        {
            MessagingServiceCore.Init(application, null, null);

            AddInterceptor();
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="activity">The presumed top level Activity.</param>
        /// <param name="messagingService">The IMessagingService to use.</param>
        public static void Init(Activity activity, IMessagingService messagingService)
        {
            MessagingServiceCore.Init(activity, messagingService, null);

            AddInterceptor();
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="application">The presumed top level Application.</param>
        /// <param name="messagingService">The IMessagingService to use.</param>
        public static void Init(Application application, IMessagingService messagingService)
        {
            MessagingServiceCore.Init(application, messagingService, null);

            AddInterceptor();
        }
        #endregion

        #region Private Methods
        private static void AddInterceptor()
        {
            if (ViewPumpService.Instance != null)
                ViewPumpService.Instance.AddInterceptor(new DialogMessagingInterceptor());
        }
        #endregion
    }
}
