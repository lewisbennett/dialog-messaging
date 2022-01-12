using System;
using Android.App;

namespace DialogMessaging.Core.Platforms.Droid.Events;

public class ActivityStoppedEventArgs : EventArgs
{
    #region Constructors
    public ActivityStoppedEventArgs(Activity activity)
    {
        Activity = activity;
    }
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the stopped activity.
    /// </summary>
    public Activity Activity { get; }
    #endregion
}