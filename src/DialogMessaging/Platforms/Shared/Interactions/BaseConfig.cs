using System;

namespace DialogMessaging.Interactions
{
    public partial interface IBaseConfig
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the dialog is dismissed.
        /// </summary>
        Action DismissedAction { get; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        string Message { get; set; }
        #endregion
    }

    public partial class BaseConfig : IBaseConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action invoked when the dialog is dismissed.
        /// </summary>
        public Action DismissedAction { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
        #endregion
    }

    public partial class BaseAsyncConfig : IBaseConfig
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the dialog is dismissed.
        /// </summary>
        public Action DismissedAction { get; internal set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
        #endregion
    }
}
