using Android.App;
using Android.OS;
using System;

namespace DialogMessaging.Core.Platforms.Droid.Events
{
    public class ActivitySavedInstanceStateEventArgs : EventArgs
    {
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

        #region Constructors
        public ActivitySavedInstanceStateEventArgs(Activity activity, Bundle outState)
            : base()
        {
            Activity = activity;
            OutState = outState;
        }
        #endregion
    }
}