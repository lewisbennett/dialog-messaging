using DialogMessaging.Interactions.Base;
using System;

namespace DialogMessaging.Interactions
{
    public static partial class AlertConfigDefaults
    {
    }

    public partial interface IAlertConfig : IBaseDialogConfig
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the 'ok' button is clicked.
        /// </summary>
        Action OkButtonClickAction { get; }

        /// <summary>
        /// Gets or sets the text displayed on the 'ok' button.
        /// </summary>
        string OkButtonText { get; set; }
        #endregion
    }

    public partial class AlertConfig : BaseDialogConfig, IAlertConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action invoked when the 'ok' button is clicked.
        /// </summary>
        public Action OkButtonClickAction { get; set; }

        /// <summary>
        /// Gets or sets the text displayed on the 'ok' button.
        /// </summary>
        public string OkButtonText { get; set; }
        #endregion
    }

    public partial class AlertAsyncConfig : BaseDialogAsyncConfig, IAlertConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action invoked when the 'ok' button is clicked.
        /// </summary>
        public Action OkButtonClickAction { get; internal set; }

        /// <summary>
        /// Gets or sets the text displayed on the 'ok' button.
        /// </summary>
        public string OkButtonText { get; set; }
        #endregion
    }
}
