using Android.App;
using System;

namespace DialogMessaging.Core.Platforms.Droid.Events
{
    public class ActivityResumedEventArgs : EventArgs
    {
        #region Properties
        /// <summary>
        /// Gets the resumed activity.
        /// </summary>
        public Activity Activity { get; }
        #endregion

        #region Constructors
        public ActivityResumedEventArgs(Activity activity)
            : base()
        {
            Activity = activity;
        }
        #endregion
    }
}
