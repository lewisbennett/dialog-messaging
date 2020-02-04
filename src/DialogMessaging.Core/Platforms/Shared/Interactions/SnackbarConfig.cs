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
        /// Gets or sets the message.
        /// </summary>
        string Message { get; set; }
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
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
        #endregion
    }
}
