using System;

namespace DialogMessaging.Interactions.Base
{
    public partial interface IBaseDialogConfig : IBaseInteraction
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the dialog is dismissed.
        /// </summary>
        Action DismissedAction { get; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        string Title { get; set; }
        #endregion
    }

    public partial class BaseDialogConfig : BaseInteraction, IBaseDialogConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action invoked when the dialog is dismissed.
        /// </summary>
        public Action DismissedAction { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        #endregion
    }

    public partial class BaseDialogAsyncConfig : BaseAsyncInteraction, IBaseDialogConfig
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the dialog is dismissed.
        /// </summary>
        public Action DismissedAction { get; internal set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        #endregion
    }
}
