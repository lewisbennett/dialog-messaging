using System;
using Android.App;

namespace DialogMessaging.Core.Platforms.Droid.Events;

public class ActivityResumedEventArgs : EventArgs
{
    #region Constructors
    public ActivityResumedEventArgs(Activity activity)
    {
        Activity = activity;
    }
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the resumed activity.
    /// </summary>
    public Activity Activity { get; }
    #endregion
}