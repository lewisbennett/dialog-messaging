using Android.App;
using Android.OS;
using AndroidX.AppCompat.App;
using Java.Lang;

namespace DialogMessaging.Infrastructure
{
    internal class ActivityLifecycleCallbacks : Object, Application.IActivityLifecycleCallbacks
    {
        #region Event Handlers
        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CurrentActivity = activity as AppCompatActivity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
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
        public static AppCompatActivity CurrentActivity { get; private set; }
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
