using Android.App;
using Android.OS;
using DialogMessaging.Core.Platforms.Droid.Events;
using DialogMessaging.Infrastructure;
using System;
using System.Linq;

namespace DialogMessaging.Core.Platforms.Droid.Callbacks
{
    public class DialogMessagingActivityLifecycleCallbacks : Java.Lang.Object, IDialogMessagingActivityLifecycleCallbacks
    {
        #region Events
        public event EventHandler<ActivityCreatedEventArgs> ActivityCreated;
        public event EventHandler<ActivityDestroyedEventArgs> ActivityDestroyed;
        public event EventHandler<ActivityPausedEventArgs> ActivityPaused;
        public event EventHandler<ActivityResumedEventArgs> ActivityResumed;
        public event EventHandler<ActivitySavedInstanceStateEventArgs> ActivitySavedInstanceState;
        public event EventHandler<ActivityStartedEventArgs> ActivityStarted;
        public event EventHandler<ActivityStoppedEventArgs> ActivityStopped;
        #endregion

        #region Properties
        /// <summary>
        ///     Gets the current activity.
        /// </summary>
        public Activity CurrentActivity { get; private set; }
        #endregion

        #region Event Handlers
        /// <summary>
        ///     Called when an activity is created.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <param name="savedInstanceState">The activity's saved instance state, if any.</param>
        public virtual void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CurrentActivity = activity;

            ActivityCreated?.Invoke(this, new ActivityCreatedEventArgs(activity, savedInstanceState));
        }

        /// <summary>
        ///     Called when an activity is destroyed.
        /// </summary>
        /// <param name="activity">The activity.</param>
        public virtual void OnActivityDestroyed(Activity activity)
        {
            ActivityDestroyed?.Invoke(this, new ActivityDestroyedEventArgs(activity));

            // Remove all views from the destroyed activity from the view cache.
            var viewCacheRemovals = MessagingServiceCore.ViewManager.ViewCache.Where(v => v.Key.Context == activity).ToArray();

            foreach (var removal in viewCacheRemovals)
                MessagingServiceCore.ViewManager.ViewCache.Remove(removal.Key);

            if (MessagingServiceCore.ViewManager.SnackbarAnchorViews.ContainsKey(activity))
                MessagingServiceCore.ViewManager.SnackbarAnchorViews.Remove(activity);

            if (MessagingServiceCore.ViewManager.SnackbarContainers.ContainsKey(activity))
                MessagingServiceCore.ViewManager.SnackbarContainers.Remove(activity);
        }

        /// <summary>
        ///     Called when an activity is paused.
        /// </summary>
        /// <param name="activity">The activity.</param>
        public virtual void OnActivityPaused(Activity activity)
        {
            ActivityPaused?.Invoke(this, new ActivityPausedEventArgs(activity));
        }

        /// <summary>
        ///     Called when an activity is resumed.
        /// </summary>
        /// <param name="activity">The activity.</param>
        public virtual void OnActivityResumed(Activity activity)
        {
            CurrentActivity = activity;

            ActivityResumed?.Invoke(this, new ActivityResumedEventArgs(activity));
        }

        /// <summary>
        ///     Called when an activity saves its instance.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <param name="outState">The saved instance.</param>
        public virtual void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
            ActivitySavedInstanceState?.Invoke(this, new ActivitySavedInstanceStateEventArgs(activity, outState));
        }

        /// <summary>
        ///     Called when an activity is started.
        /// </summary>
        /// <param name="activity">The activity.</param>
        public virtual void OnActivityStarted(Activity activity)
        {
            ActivityStarted?.Invoke(this, new ActivityStartedEventArgs(activity));
        }

        /// <summary>
        ///     Called when an activity is stopped.
        /// </summary>
        /// <param name="activity">The activity.</param>
        public virtual void OnActivityStopped(Activity activity)
        {
            ActivityStopped?.Invoke(this, new ActivityStoppedEventArgs(activity));
        }
        #endregion
    }
}