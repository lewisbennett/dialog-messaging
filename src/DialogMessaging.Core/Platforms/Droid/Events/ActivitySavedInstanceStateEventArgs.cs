using System;
using Android.App;
using Android.OS;

namespace DialogMessaging.Core.Platforms.Droid.Events;

public class ActivitySavedInstanceStateEventArgs : EventArgs
{
    #region Constructors
    public ActivitySavedInstanceStateEventArgs(Activity activity, Bundle outState)
    {
        Activity = activity;
        OutState = outState;
    }
    #endregion

    #region Properties
    /// <summary>
    ///     Gets the activity that has saved its instance state.
    /// </summary>
    public Activity Activity { get; }

    /// <summary>
    ///     Gets the saved instance state.
    /// </summary>
    public Bundle OutState { get; }
    #endregion
}