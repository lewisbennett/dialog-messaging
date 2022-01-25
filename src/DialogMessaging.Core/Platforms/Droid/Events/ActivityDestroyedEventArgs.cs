using Android.App;
using System;

namespace DialogMessaging.Core.Platforms.Droid.Events
{
    public class ActivityDestroyedEventArgs : EventArgs
    {
        #region Properties
        /// <summary>
        /// Gets the destroyed activity.
        /// </summary>
        public Activity Activity { get; }
        #endregion

        #region Constructors
        public ActivityDestroyedEventArgs(Activity activity)
            : base()
        {
            Activity = activity;
        }
        #endregion
    }
}
