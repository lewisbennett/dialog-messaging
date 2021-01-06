using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using AndroidX.AppCompat.App;
using Java.Lang;
using System.Collections.Generic;

namespace DialogMessaging.Infrastructure
{
    public class ActivityLifecycleCallbacks : Object, Application.IActivityLifecycleCallbacks
    {
        #region Event Handlers
        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CurrentActivity = activity as AppCompatActivity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
            if (SnackbarContainers.ContainsKey(activity))
                SnackbarContainers.Remove(activity);
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CurrentActivity = activity as AppCompatActivity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
        }

        public void OnActivityStopped(Activity activity)
        {
        }
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets the current activity.
        /// </summary>
        public static AppCompatActivity CurrentActivity { get; private set; }

        /// <summary>
        /// Gets the inflated Snackbar containers, if any.
        /// </summary>
        public static Dictionary<Context, View> SnackbarContainers { get; } = new Dictionary<Context, View>();
        #endregion

        #region Public Static Methods
        public static void Register(AppCompatActivity activity)
        {
            Register(activity.Application);

            CurrentActivity = activity;
        }

        public static void Register(Application application)
        {
            application.RegisterActivityLifecycleCallbacks(new ActivityLifecycleCallbacks());
        }
        #endregion
    }
}
