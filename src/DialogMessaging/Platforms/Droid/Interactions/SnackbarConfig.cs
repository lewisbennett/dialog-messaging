using Android.Support.Design.Widget;
using System;

namespace DialogMessaging.Interactions
{
    public partial interface ISnackbarConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the snackbar duration.
        /// </summary>
        int Duration { get; set; }
        #endregion

        #region Static Properties
        /// <summary>
        /// Gets or sets the default action button text color.
        /// </summary>
        public static string DefaultActionButtonTextColor { get; set; }

        /// <summary>
        /// Gets or sets the function to calculate the default action button text color.
        /// </summary>
        public static Func<string> DefaultActionButtonTextColorCalculator { get; set; }

        /// <summary>
        /// Gets or sets the default snackbar duration. Default value: Snackbar.LengthLong.
        /// </summary>
        public static int DefaultDuration { get; set; } = Snackbar.LengthLong;

        /// <summary>
        /// Gets or sets the default snackbar background color.
        /// </summary>
        public static string DefaultBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the function to calculate the default background color.
        /// </summary>
        public static Func<string> DefaultBackgroundColorCalculator { get; set; }

        /// <summary>
        /// Gets or sets the default snackbar text color.
        /// </summary>
        public static string DefaultTextColor { get; set; }

        /// <summary>
        /// Gets or sets the function to calculate the default text color.
        /// </summary>
        public static Func<string> DefaultTextColorCalculator { get; set; }
        #endregion
    }

    public partial class SnackbarConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the snackbar duration.
        /// </summary>
        public int Duration { get; set; }
        #endregion

        #region Constructors
        public SnackbarConfig()
        {
            ActionButtonTextColor = ISnackbarConfig.DefaultActionButtonTextColor;
            ActionButtonTextColorCalculator = ISnackbarConfig.DefaultActionButtonTextColorCalculator;
            BackgroundColor = ISnackbarConfig.DefaultBackgroundColor;
            BackgroundColorCalculator = ISnackbarConfig.DefaultBackgroundColorCalculator;
            Duration = ISnackbarConfig.DefaultDuration;
            TextColor = ISnackbarConfig.DefaultTextColor;
            TextColorCalculator = ISnackbarConfig.DefaultTextColorCalculator;
        }
        #endregion
    }
}
