using System;
using Android.App;

namespace DialogMessaging.Core.Platforms.Droid.Events;

public class ActivityPausedEventArgs : EventArgs
{
    #region Constructors
    public ActivityPausedEventArgs(Activity activity)
    {
        Activity = activity;
    }
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the paused activity.
    /// </summary>
    public Activity Activity { get; }
    #endregion
}