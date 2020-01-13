using System;

namespace DialogMessaging.Interactions
{
    public partial interface ISnackbarConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action invoked when the action button is clicked.
        /// </summary>
        Action ActionButtonClickAction { get; set; }

        /// <summary>
        /// Gets or sets the action button text.
        /// </summary>
        string ActionButtonText { get; set; }

        /// <summary>
        /// Gets or sets the action button text color.
        /// </summary>
        string ActionButtonTextColor { get; set; }

        /// <summary>
        /// Gets or sets the function to calculate the action button text color.
        /// </summary>
        Func<string> ActionButtonTextColorCalculator { get; set; }

        /// <summary>
        /// Gets or sets the snackbar background color (hex).
        /// </summary>
        string BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the function to calculate the background color.
        /// </summary>
        Func<string> BackgroundColorCalculator { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets the snackbar text color.
        /// </summary>
        string TextColor { get; set; }

        /// <summary>
        /// Gets or sets the function to calculate the text color.
        /// </summary>
        Func<string> TextColorCalculator { get; set; }
        #endregion
    }

    public partial class SnackbarConfig : ISnackbarConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action invoked when the action button is clicked.
        /// </summary>
        public Action ActionButtonClickAction { get; set; }

        /// <summary>
        /// Gets or sets the action button text.
        /// </summary>
        public string ActionButtonText { get; set; }

        /// <summary>
        /// Gets or sets the action button text color.
        /// </summary>
        public string ActionButtonTextColor { get; set; }

        /// <summary>
        /// Gets or sets the function to calculate the action button text color.
        /// </summary>
        public Func<string> ActionButtonTextColorCalculator { get; set; }

        /// <summary>
        /// Gets or sets the snackbar background color (hex).
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the function to calculate the background color.
        /// </summary>
        public Func<string> BackgroundColorCalculator { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the snackbar text color.
        /// </summary>
        public string TextColor { get; set; }

        /// <summary>
        /// Gets or sets the function to calculate the text color.
        /// </summary>
        public Func<string> TextColorCalculator { get; set; }
        #endregion
    }
}
