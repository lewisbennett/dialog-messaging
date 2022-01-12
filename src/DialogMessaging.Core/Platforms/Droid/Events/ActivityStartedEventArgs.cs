using System;
using Android.App;

namespace DialogMessaging.Core.Platforms.Droid.Events;

public class ActivityStartedEventArgs : EventArgs
{
    #region Constructors
    public ActivityStartedEventArgs(Activity activity)
    {
        Activity = activity;
    }
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the started activity.
    /// </summary>
    public Activity Activity { get; }
    #endregion
}