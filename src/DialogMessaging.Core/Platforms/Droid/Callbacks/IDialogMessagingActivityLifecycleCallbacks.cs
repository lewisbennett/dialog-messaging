using System;
using Android.App;
using DialogMessaging.Core.Platforms.Droid.Events;

namespace DialogMessaging.Core.Platforms.Droid.Callbacks;

public interface IDialogMessagingActivityLifecycleCallbacks : Application.IActivityLifecycleCallbacks
{
    #region Properties
    /// <summary>
    ///     Gets the current activity.
    /// </summary>
    public Activity CurrentActivity { get; }
    #endregion

    #region Events
    event EventHandler<ActivityCreatedEventArgs> ActivityCreated;
    event EventHandler<ActivityDestroyedEventArgs> ActivityDestroyed;
    event EventHandler<ActivityPausedEventArgs> ActivityPaused;
    event EventHandler<ActivityResumedEventArgs> ActivityResumed;
    event EventHandler<ActivitySavedInstanceStateEventArgs> ActivitySavedInstanceState;
    event EventHandler<ActivityStartedEventArgs> ActivityStarted;
    event EventHandler<ActivityStoppedEventArgs> ActivityStopped;
    #endregion
}