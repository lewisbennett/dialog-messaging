using System;
using Android.App;

namespace DialogMessaging.Core.Platforms.Droid.Events;

public class ActivityDestroyedEventArgs : EventArgs
{
    #region Constructors
    public ActivityDestroyedEventArgs(Activity activity)
    {
        Activity = activity;
    }
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the destroyed activity.
    /// </summary>
    public Activity Activity { get; }
    #endregion
}