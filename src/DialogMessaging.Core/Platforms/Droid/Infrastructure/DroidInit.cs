using Android.App;
using DialogMessaging.Core.Platforms.Droid.Callbacks;
using DialogMessaging.Core.Platforms.Droid.ViewManager;
using DialogMessaging.Infrastructure;

namespace DialogMessaging.Core.Platforms.Droid.Infrastructure;

public static class DroidInit
{
    #region Public Methods
    /// <summary>
    ///     Initialize the messaging service.
    /// </summary>
    /// <param name="application">The application.</param>
    /// <param name="messagingService">The messaging service.</param>
    /// <param name="activityLifecycleCallbacks">The activity lifecycle callbacks to register.</param>
    /// <param name="viewManager">The view manager, or null to use default.</param>
    public static void Init(Application application, IMessagingService messagingService, IDialogMessagingActivityLifecycleCallbacks activityLifecycleCallbacks, IViewManager viewManager = null)
    {
        MessagingServiceCore.ActivityLifecycleCallbacks = activityLifecycleCallbacks;
        MessagingServiceCore.Instance = messagingService ?? new DroidMessagingService();

        MessagingServiceCore.ViewManager = viewManager ?? new DialogMessagingViewManager();

        application.RegisterActivityLifecycleCallbacks(MessagingServiceCore.ActivityLifecycleCallbacks);
    }
    #endregion
}