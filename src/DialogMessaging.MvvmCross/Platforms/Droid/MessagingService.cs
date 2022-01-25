using Android.App;
using AndroidX.AppCompat.App;
using DialogMessaging.Core.Platforms.Droid.Callbacks;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
using DialogMessaging.Core.Platforms.Droid.ViewManager;
using DialogMessaging.Infrastructure;
using DialogMessaging.MvvmCross.Platforms.Droid.ViewManager;

namespace DialogMessaging
{
    public static partial class MessagingService
    {
        #region Properties
        /// <summary>
        /// Gets the active <see cref="IDialogMessagingActivityLifecycleCallbacks" />.
        /// </summary>
        public static IDialogMessagingActivityLifecycleCallbacks ActivityLifecycleCallbacks => MessagingServiceCore.ActivityLifecycleCallbacks;

        /// <summary>
        /// Gets the active <see cref="IViewManager" />.
        /// </summary>
        public static IViewManager ViewManager => MessagingServiceCore.ViewManager;
        #endregion

        #region Public Methods
        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="activity">The current activity.</param>
        public static void Init(AppCompatActivity activity)
        {
            Init(activity.Application);
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="application">The application.</param>
        public static void Init(Application application)
        {
            Init(application, (IMessagingService)null);
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="activity">The current activity.</param>
        /// <param name="activityLifecycleCallbacks">Custom activity lifecycle callbacks.</param>
        public static void Init(AppCompatActivity activity, IDialogMessagingActivityLifecycleCallbacks activityLifecycleCallbacks)
        {
            Init(activity.Application, activityLifecycleCallbacks);
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="activityLifecycleCallbacks">Custom activity lifecycle callbacks.</param>
        public static void Init(Application application, IDialogMessagingActivityLifecycleCallbacks activityLifecycleCallbacks)
        {
            Init(application, null, activityLifecycleCallbacks);
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="activity">The current activity.</param>
        /// <param name="messagingService">A custom messaging service.</param>
        public static void Init(AppCompatActivity activity, IMessagingService messagingService)
        {
            Init(activity.Application, messagingService);
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="messagingService">A custom messaging service.</param>
        public static void Init(Application application, IMessagingService messagingService)
        {
            Init(application, messagingService, new DialogMessagingActivityLifecycleCallbacks());
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="activity">The current activity.</param>
        /// <param name="messagingService">A custom messaging service.</param>
        /// <param name="activityLifecycleCallbacks">Custom activity lifecycle callbacks.</param>
        public static void Init(AppCompatActivity activity, IMessagingService messagingService, IDialogMessagingActivityLifecycleCallbacks activityLifecycleCallbacks)
        {
            Init(activity.Application, messagingService, activityLifecycleCallbacks);
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="messagingService">A custom messaging service.</param>
        /// <param name="activityLifecycleCallbacks">Custom activity lifecycle callbacks.</param>
        public static void Init(Application application, IMessagingService messagingService, IDialogMessagingActivityLifecycleCallbacks activityLifecycleCallbacks)
        {
            DroidInit.Init(application, messagingService, activityLifecycleCallbacks, new MvvmCrossViewManager());
        }
        #endregion
    }
}
