using System;
using UIKit;

namespace DialogMessaging.Interactions
{
    public partial interface ISnackbarConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action button title color.
        /// </summary>
        UIColor ActionButtonTitleColor { get; set; }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        UIColor BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the snackbar duration.
        /// </summary>
        TimeSpan? Duration { get; set; }

        /// <summary>
        /// Gets or sets the message font.
        /// </summary>
        UIFont MessageFont { get; set; }

        /// <summary>
        /// Gets or sets the message text color.
        /// </summary>
        UIColor MessageTextColor { get; set; }
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets or sets the default action button text color.
        /// </summary>
        public static UIColor DefaultActionButtonTextColor { get; set; }

        /// <summary>
        /// Gets or sets the default snackbar duration. Default value: Snackbar.LengthLong.
        /// </summary>
        public static TimeSpan? DefaultDuration { get; set; }

        /// <summary>
        /// Gets or sets the default background color.
        /// </summary>
        public static UIColor DefaultBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the default message text color.
        /// </summary>
        public static UIColor DefaultMessageTextColor { get; set; }

        /// <summary>
        /// Gets or sets the default message font.
        /// </summary>
        public static UIFont DefaultMessageFont { get; set; }
        #endregion
    }

    public partial class SnackbarConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action button title color.
        /// </summary>
        public UIColor ActionButtonTitleColor { get; set; }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        public UIColor BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the snackbar duration.
        /// </summary>
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Gets or sets the message font.
        /// </summary>
        public UIFont MessageFont { get; set; }

        /// <summary>
        /// Gets or sets the message text color.
        /// </summary>
        public UIColor MessageTextColor { get; set; }
        #endregion

        #region Constructors
        public SnackbarConfig()
        {
            ActionButtonTitleColor = ISnackbarConfig.DefaultActionButtonTextColor;
            BackgroundColor = ISnackbarConfig.DefaultBackgroundColor;
            Duration = ISnackbarConfig.DefaultDuration;
            MessageFont = ISnackbarConfig.DefaultMessageFont;
            MessageTextColor = ISnackbarConfig.DefaultMessageTextColor;
        }
        #endregion
    }
}
