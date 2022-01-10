using DialogMessaging.Infrastructure;
using System;
using UIKit;

namespace DialogMessaging.Interactions
{
    public static partial class SnackbarConfigDefaults
    {
        #region Properties
        /// <summary>
        ///     Gets or sets the default value for the action button font.
        /// </summary>
        public static UIFont ActionButtonFont { get; set; }

        /// <summary>
        ///     Gets or sets the default value for the action button text color.
        /// </summary>
        public static UIColor ActionButtonTextColor { get; set; }

        /// <summary>
        ///     Gets or sets the default value for the background color.
        /// </summary>
        public static UIColor BackgroundColor { get; set; }

        /// <summary>
        ///     Gets or sets the default <see cref="Type" /> of the custom view to use for the dialog, if any.
        /// </summary>
        public static Type CustomViewType { get; set; }

        /// <summary>
        ///     Gets or sets the default value for the Snackbar duration.
        /// </summary>
        public static TimeSpan? Duration { get; set; }

        /// <summary>
        ///     Gets or sets the default value for the message text color.
        /// </summary>
        public static UIColor MessageTextColor { get; set; }

        /// <summary>
        ///     Gets or sets the default value for the message typeface.
        /// </summary>
        public static UIFont MessageFont { get; set; }
        #endregion
    }

    public partial interface ISnackbarConfig
    {
        #region Properties
        /// <summary>
        ///     Gets or sets the action button font.
        /// </summary>
        UIFont ActionButtonFont { get; set; }

        /// <summary>
        ///     Gets or sets the action button text color.
        /// </summary>
        UIColor ActionButtonTextColor { get; set; }

        /// <summary>
        ///     Gets or sets the background color.
        /// </summary>
        UIColor BackgroundColor { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="UIView" /> that the Snackbar should be contained within.
        ///     Please note that the Snackbar view isn't added to this view as a subview. This view should be used a reference for
        ///     where to position the Snackbar on the screen.
        /// </summary>
        UIView ContainerView { get; set; }

        /// <summary>
        ///     Gets or sets the duration of the Snackbar.
        /// </summary>
        TimeSpan? Duration { get; set; }

        /// <summary>
        ///     Gets or sets the message text color.
        /// </summary>
        UIColor MessageTextColor { get; set; }

        /// <summary>
        ///     Gets or sets the message font.
        /// </summary>
        UIFont MessageFont { get; set; }
        #endregion
    }

    public partial class SnackbarConfig
    {
        #region Constructors
        public SnackbarConfig()
            : base()
        {
            ActionButtonFont = SnackbarConfigDefaults.ActionButtonFont;
            ActionButtonTextColor = SnackbarConfigDefaults.ActionButtonTextColor;
            BackgroundColor = SnackbarConfigDefaults.BackgroundColor;
            CustomViewType = SnackbarConfigDefaults.CustomViewType;
            Duration = SnackbarConfigDefaults.Duration;
            MessageTextColor = SnackbarConfigDefaults.MessageTextColor;
            MessageFont = SnackbarConfigDefaults.MessageFont;

            ContainerView = MessagingServiceCore.Window;
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets or sets the action button font.
        /// </summary>
        public UIFont ActionButtonFont { get; set; }

        /// <summary>
        ///     Gets or sets the action button text color.
        /// </summary>
        public UIColor ActionButtonTextColor { get; set; }

        /// <summary>
        ///     Gets or sets the background color.
        /// </summary>
        public UIColor BackgroundColor { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="UIView" /> that the Snackbar should be contained within.
        ///     Please note that the Snackbar view isn't added to this view as a subview. This view should be used a reference for
        ///     where to position the Snackbar on the screen.
        /// </summary>
        public UIView ContainerView { get; set; }

        /// <summary>
        ///     Gets or sets the duration of the Snackbar.
        /// </summary>
        public TimeSpan? Duration { get; set; }

        /// <summary>
        ///     Gets or sets the message text color.
        /// </summary>
        public UIColor MessageTextColor { get; set; }

        /// <summary>
        ///     Gets or sets the message font.
        /// </summary>
        public UIFont MessageFont { get; set; }
        #endregion
    }
}