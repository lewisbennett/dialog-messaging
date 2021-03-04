using Android.App;
using System;

namespace DialogMessaging.Core.Platforms.Droid.Events
{
    public class ActivityPausedEventArgs : EventArgs
    {
        #region Properties
        /// <summary>
        /// Gets the paused activity.
        /// </summary>
        public Activity Activity { get; }
        #endregion

        #region Constructors
        public ActivityPausedEventArgs(Activity activity)
            : base()
        {
            Activity = activity;
        }
        #endregion
    }
}
