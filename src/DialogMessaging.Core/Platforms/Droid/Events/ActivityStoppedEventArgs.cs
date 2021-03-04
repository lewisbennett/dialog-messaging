using Android.App;
using System;

namespace DialogMessaging.Core.Platforms.Droid.Events
{
    public class ActivityStoppedEventArgs : EventArgs
    {
        #region Properties
        /// <summary>
        /// Gets the stopped activity.
        /// </summary>
        public Activity Activity { get; }
        #endregion

        #region Constructors
        public ActivityStoppedEventArgs(Activity activity)
            : base()
        {
            Activity = activity;
        }
        #endregion
    }
}
