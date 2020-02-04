using Android.App;
using Android.OS;
using Java.Lang;

namespace DialogMessaging.Infrastructure
{
    public class ActivityLifecycleCallbacks : Object, Application.IActivityLifecycleCallbacks
    {
        #region Event Handlers
        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CurrentActivity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CurrentActivity = activity;
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
        public static Activity CurrentActivity { get; private set; }
        #endregion

        #region Public Static Methods
        public static void Register(Activity activity)
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
