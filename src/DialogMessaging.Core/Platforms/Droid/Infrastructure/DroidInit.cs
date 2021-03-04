using Android.App;
using DialogMessaging.Core.Platforms.Droid.Callbacks;
using DialogMessaging.Core.Platforms.Droid.ViewManager;
using DialogMessaging.Infrastructure;

namespace DialogMessaging.Core.Platforms.Droid.Infrastructure
{
    public static class DroidInit
    {
        #region Public Methods
        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="messagingService">The messaging service.</param>
        /// <param name="activityLifecycleCallbacks">The activity lifecycle callbacks to register.</param>
        /// <param name="viewManager">The view manager.</param>
        public static void Init(Application application, IMessagingService messagingService, IDialogMessagingActivityLifecycleCallbacks activityLifecycleCallbacks, IViewManager viewManager)
        {
            MessagingServiceCore.ActivityLifecycleCallbacks = activityLifecycleCallbacks;
            MessagingServiceCore.Instance = messagingService;
            MessagingServiceCore.ViewManager = viewManager;

            application.RegisterActivityLifecycleCallbacks(MessagingServiceCore.ActivityLifecycleCallbacks);
        }
        #endregion
    }
}
