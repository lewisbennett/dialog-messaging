using DialogMessaging.Interactions.Base;
using System;

namespace DialogMessaging.Interactions
{
    public static partial class ConfirmConfigDefaults
    {
    }

    public partial interface IConfirmConfig : IBaseDialogConfig
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the 'cancel' button is clicked.
        /// </summary>
        Action CancelButtonClickAction { get; }

        /// <summary>
        /// Gets or sets the text displayed on the 'cancel' button.
        /// </summary>
        string CancelButtonText { get; set; }

        /// <summary>
        /// Gets the action invoked when the 'confirm' button is clicked.
        /// </summary>
        Action ConfirmButtonClickAction { get; }

        /// <summary>
        /// Gets or sets the text displayed on the 'confirm' button.
        /// </summary>
        string ConfirmButtonText { get; set; }
        #endregion
    }

    public partial class ConfirmConfig : BaseDialogConfig, IConfirmConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action invoked when the 'cancel' button is clicked.
        /// </summary>
        public Action CancelButtonClickAction { get; set; }

        /// <summary>
        /// Gets or sets the text displayed on the 'cancel' button.
        /// </summary>
        public string CancelButtonText { get; set; }

        /// <summary>
        /// Gets or sets the action invoked when the 'confirm' button is clicked.
        /// </summary>
        public Action ConfirmButtonClickAction { get; set; }

        /// <summary>
        /// Gets or sets the text displayed on the 'confirm' button.
        /// </summary>
        public string ConfirmButtonText { get; set; }
        #endregion
    }

    public partial class ConfirmAsyncConfig : BaseDialogAsyncConfig, IConfirmConfig
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the 'cancel' button is clicked.
        /// </summary>
        public Action CancelButtonClickAction { get; internal set; }

        /// <summary>
        /// Gets or sets the text displayed on the 'cancel' button.
        /// </summary>
        public string CancelButtonText { get; set; }

        /// <summary>
        /// Gets or sets the action invoked when the 'confirm' button is clicked.
        /// </summary>
        public Action ConfirmButtonClickAction { get; internal set; }

        /// <summary>
        /// Gets or sets the text displayed on the 'confirm' button.
        /// </summary>
        public string ConfirmButtonText { get; set; }
        #endregion
    }
}
