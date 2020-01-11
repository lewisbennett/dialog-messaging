using System;

namespace DialogMessaging.Interactions
{
    public partial interface IAlertConfig : IBaseConfig
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the ok button is clicked.
        /// </summary>
        Action OkButtonClickAction { get; }

        /// <summary>
        /// Gets or sets the ok button text.
        /// </summary>
        string OkButtonText { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        string Title { get; set; }
        #endregion
    }

    public partial class AlertConfig : BaseConfig, IAlertConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action invoked when the ok button is clicked.
        /// </summary>
        public Action OkButtonClickAction { get; set; }

        /// <summary>
        /// Gets or sets the ok button text.
        /// </summary>
        public string OkButtonText { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        #endregion
    }

    public partial class AlertAsyncConfig : BaseAsyncConfig, IAlertConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action invoked when the ok button is clicked.
        /// </summary>
        public Action OkButtonClickAction { get; internal set; }

        /// <summary>
        /// Gets or sets the ok button text.
        /// </summary>
        public string OkButtonText { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        #endregion
    }
}
