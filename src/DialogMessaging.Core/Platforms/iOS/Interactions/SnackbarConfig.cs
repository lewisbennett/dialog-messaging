using System;
using UIKit;

namespace DialogMessaging.Interactions
{
    public partial interface ISnackbarConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action button font.
        /// </summary>
        UIFont ActionButtonFont { get; set; }

        /// <summary>
        /// Gets or sets the action button text color.
        /// </summary>
        UIColor ActionButtonTextColor { get; set; }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        UIColor BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the duration of the Snackbar.
        /// </summary>
        TimeSpan? Duration { get; set; }

        /// <summary>
        /// Gets or sets the message text color.
        /// </summary>
        UIColor MessageTextColor { get; set; }

        /// <summary>
        /// Gets or sets the message font.
        /// </summary>
        UIFont MessageFont { get; set; }
        #endregion
    }

    public partial class SnackbarConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action button font.
        /// </summary>
        public UIFont ActionButtonFont { get; set; }

        /// <summary>
        /// Gets or sets the action button text color.
        /// </summary>
        public UIColor ActionButtonTextColor { get; set; }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        public UIColor BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the duration of the Snackbar.
        /// </summary>
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Gets or sets the message text color.
        /// </summary>
        public UIColor MessageTextColor { get; set; }

        /// <summary>
        /// Gets or sets the message font.
        /// </summary>
        public UIFont MessageFont { get; set; }
        #endregion
    }
}
