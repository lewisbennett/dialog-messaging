using DialogMessaging.Interactions.Base;
using System;

namespace DialogMessaging.Interactions
{
    public static partial class SnackbarConfigDefaults
    {
    }

    public partial interface ISnackbarConfig : IBaseInteraction
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the action button is clicked.
        /// </summary>
        Action ActionButtonClickAction { get; }

        /// <summary>
        /// Gets or sets the text displayed on the action button.
        /// </summary>
        string ActionButtonText { get; set; }
        #endregion
    }

    public partial class SnackbarConfig : BaseInteraction, ISnackbarConfig
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the action button is clicked.
        /// </summary>
        public Action ActionButtonClickAction { get; }

        /// <summary>
        /// Gets or sets the text displayed on the action button.
        /// </summary>
        public string ActionButtonText { get; set; }
        #endregion
    }
}
