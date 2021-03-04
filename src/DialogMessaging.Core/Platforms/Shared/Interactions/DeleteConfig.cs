using DialogMessaging.Interactions.Base;
using System;

namespace DialogMessaging.Interactions
{
    public static partial class DeleteConfigDefaults
    {
    }

    public partial interface IDeleteConfig : IBaseDialogConfig
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the 'cancel' button is clicked.
        /// </summary>
        public Action CancelButtonClickAction { get; }

        /// <summary>
        /// Gets or sets the text displayed on the 'cancel' button.
        /// </summary>
        public string CancelButtonText { get; set; }

        /// <summary>
        /// Gets the action invoked when the 'delete' button is clicked.
        /// </summary>
        Action DeleteButtonClickAction { get; }

        /// <summary>
        /// Gets or sets the text displayed on the 'delete' button.
        /// </summary>
        string DeleteButtonText { get; set; }
        #endregion
    }

    public partial class DeleteConfig : BaseDialogConfig, IDeleteConfig
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
        /// Gets or sets the action invoked when the 'delete' button is clicked.
        /// </summary>
        public Action DeleteButtonClickAction { get; set; }

        /// <summary>
        /// Gets or sets the text displayed on the 'delete' button.
        /// </summary>
        public string DeleteButtonText { get; set; }
        #endregion
    }

    public partial class DeleteAsyncConfig : BaseDialogAsyncConfig, IDeleteConfig
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
        /// Gets or sets the action invoked when the 'delete' button is clicked.
        /// </summary>
        public Action DeleteButtonClickAction { get; internal set; }

        /// <summary>
        /// Gets or sets the text displayed on the 'delete' button.
        /// </summary>
        public string DeleteButtonText { get; set; }
        #endregion
    }
}
