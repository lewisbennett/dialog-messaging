using Android.App;
using System;

namespace DialogMessaging.Core.Platforms.Droid.Events
{
    public class ActivityStartedEventArgs : EventArgs
    {
        #region Properties
        /// <summary>
        ///     Gets the started activity.
        /// </summary>
        public Activity Activity { get; }
        #endregion

        #region Constructors
        public ActivityStartedEventArgs(Activity activity)
            : base()
        {
            Activity = activity;
        }
        #endregion
    }
}