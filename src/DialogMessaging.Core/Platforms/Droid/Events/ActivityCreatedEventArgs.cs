using System;
using Android.App;
using Android.OS;

namespace DialogMessaging.Core.Platforms.Droid.Events;

public class ActivityCreatedEventArgs : EventArgs
{
    #region Constructors
    public ActivityCreatedEventArgs(Activity activity, Bundle savedInstanceState)
    {
        Activity = activity;
        SavedInstanceState = savedInstanceState;
    }
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the created activity.
    /// </summary>
    public Activity Activity { get; }

    /// <summary>
    ///     Gets the activity's saved instance state, if any.
    /// </summary>
    public Bundle SavedInstanceState { get; }
    #endregion
}