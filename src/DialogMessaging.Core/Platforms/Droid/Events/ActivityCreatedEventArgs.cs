using Android.App;
using Android.OS;
using System;

namespace DialogMessaging.Core.Platforms.Droid.Events
{
    public class ActivityCreatedEventArgs : EventArgs
    {
        #region Properties
        /// <summary>
        /// Gets the created activity.
        /// </summary>
        public Activity Activity { get; }

        /// <summary>
        /// Gets the activity's saved instance state, if any.
        /// </summary>
        public Bundle SavedInstanceState { get; }
        #endregion

        #region Constructors
        public ActivityCreatedEventArgs(Activity activity, Bundle savedInstanceState)
            : base()
        {
            Activity = activity;
            SavedInstanceState = savedInstanceState;
        }
        #endregion
    }
}
