using Android.App;
using AndroidX.AppCompat.App;
using DialogMessaging.Core.Platforms.Droid;
using DialogMessaging.Core.Platforms.Droid.Callbacks;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
using DialogMessaging.Core.Platforms.Droid.ViewManager;
using DialogMessaging.Infrastructure;
using DialogMessaging.MvvmCross.Platforms.Droid.ViewManager;
using System;
using ViewPump;
using ViewPump.Base;
using ViewPump.Events;

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

        #region Event Handlers
        private static void InterceptingService_ViewInflated(object sender, ViewInflatedEventArgs e)
        {
            ViewManager.OnViewInflated(e.View, e.Attrs);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="activity">The current activity.</param>
        /// <param name="initViewPump">Whether or not to initialize ViewPump, if it hasn't been already. You should disable this if you plan to use your own <see cref="IInterceptingService" />, and use <see cref="InterceptingService.Init(IInterceptingService)" /> before calling <see cref="Init(AppCompatActivity, bool)" />.</param>
        public static void Init(AppCompatActivity activity, bool initViewPump = true)
        {
            Init(activity.Application, initViewPump);
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="initViewPump">Whether or not to initialize ViewPump, if it hasn't been already. You should disable this if you plan to use your own <see cref="IInterceptingService" />, and use <see cref="InterceptingService.Init(IInterceptingService)" /> before calling <see cref="Init(Application, bool)" />.</param>
        public static void Init(Application application, bool initViewPump = true)
        {
            Init(application, new DroidMessagingService(), initViewPump);
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="activity">The current activity.</param>
        /// <param name="activityLifecycleCallbacks">Custom activity lifecycle callbacks.</param>
        /// <param name="initViewPump">Whether or not to initialize ViewPump, if it hasn't been already. You should disable this if you plan to use your own <see cref="IInterceptingService" />, and use <see cref="InterceptingService.Init(IInterceptingService)" /> before calling <see cref="Init(AppCompatActivity, IDialogMessagingActivityLifecycleCallbacks, bool)" />.</param>
        public static void Init(AppCompatActivity activity, IDialogMessagingActivityLifecycleCallbacks activityLifecycleCallbacks, bool initViewPump = true)
        {
            Init(activity.Application, activityLifecycleCallbacks, initViewPump);
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="activityLifecycleCallbacks">Custom activity lifecycle callbacks.</param>
        /// <param name="initViewPump">Whether or not to initialize ViewPump, if it hasn't been already. You should disable this if you plan to use your own <see cref="IInterceptingService" />, and use <see cref="InterceptingService.Init(IInterceptingService)" /> before calling <see cref="Init(Application, IDialogMessagingActivityLifecycleCallbacks, bool)" />.</param>
        public static void Init(Application application, IDialogMessagingActivityLifecycleCallbacks activityLifecycleCallbacks, bool initViewPump = true)
        {
            Init(application, new DroidMessagingService(), activityLifecycleCallbacks, initViewPump);
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="activity">The current activity.</param>
        /// <param name="messagingService">A custom messaging service.</param>
        /// <param name="initViewPump">Whether or not to initialize ViewPump, if it hasn't been already. You should disable this if you plan to use your own <see cref="IInterceptingService" />, and use <see cref="InterceptingService.Init(IInterceptingService)" /> before calling <see cref="Init(AppCompatActivity, IMessagingService, bool)" />.</param>
        public static void Init(AppCompatActivity activity, IMessagingService messagingService, bool initViewPump = true)
        {
            Init(activity.Application, messagingService, initViewPump);
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="messagingService">A custom messaging service.</param>
        /// <param name="initViewPump">Whether or not to initialize ViewPump, if it hasn't been already. You should disable this if you plan to use your own <see cref="IInterceptingService" />, and use <see cref="InterceptingService.Init(IInterceptingService)" /> before calling <see cref="Init(Application, IMessagingService, bool)" />.</param>
        public static void Init(Application application, IMessagingService messagingService, bool initViewPump = true)
        {
            Init(application, messagingService, new DialogMessagingActivityLifecycleCallbacks(), initViewPump);
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="activity">The current activity.</param>
        /// <param name="messagingService">A custom messaging service.</param>
        /// <param name="activityLifecycleCallbacks">Custom activity lifecycle callbacks.</param>
        /// <param name="initViewPump">Whether or not to initialize ViewPump, if it hasn't been already. You should disable this if you plan to use your own <see cref="IInterceptingService" />, and use <see cref="InterceptingService.Init(IInterceptingService)" /> before calling <see cref="Init(AppCompatActivity, IMessagingService, IDialogMessagingActivityLifecycleCallbacks, bool)" />.</param>
        public static void Init(AppCompatActivity activity, IMessagingService messagingService, IDialogMessagingActivityLifecycleCallbacks activityLifecycleCallbacks, bool initViewPump = true)
        {
            Init(activity.Application, messagingService, activityLifecycleCallbacks, initViewPump);
        }

        /// <summary>
        /// Initialize the messaging service.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="messagingService">A custom messaging service.</param>
        /// <param name="activityLifecycleCallbacks">Custom activity lifecycle callbacks.</param>
        /// <param name="initViewPump">Whether or not to initialize ViewPump, if it hasn't been already. You should disable this if you plan to use your own <see cref="IInterceptingService" />, and use <see cref="InterceptingService.Init(IInterceptingService)" /> before calling <see cref="Init(Application, IMessagingService, IDialogMessagingActivityLifecycleCallbacks, bool)" />.</param>
        public static void Init(Application application, IMessagingService messagingService, IDialogMessagingActivityLifecycleCallbacks activityLifecycleCallbacks, bool initViewPump = true)
        {
            if (InterceptingService.Instance == null)
            {
                if (initViewPump)
                    InterceptingService.Init();

                else
                    throw new InvalidOperationException("ViewPump has not been initialized.");
            }

            // Register an event handler so that we can notify the messaging service about inflated views.
            InterceptingService.Instance.ViewInflated += InterceptingService_ViewInflated;

            DroidInit.Init(application, messagingService, activityLifecycleCallbacks, new ViewPumpViewManager());
        }
        #endregion
    }
}
