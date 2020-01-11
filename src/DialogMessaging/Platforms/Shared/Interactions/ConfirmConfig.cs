using System;

namespace DialogMessaging.Interactions
{
    public partial interface IConfirmConfig : IBaseConfig
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the cancel button is clicked.
        /// </summary>
        Action CancelButtonClickAction { get; }

        /// <summary>
        /// Gets or sets the cancel button text.
        /// </summary>
        string CancelButtonText { get; set; }

        /// <summary>
        /// Gets the action invoked when the confirm button is clicked.
        /// </summary>
        Action ConfirmButtonClickAction { get; }

        /// <summary>
        /// Gets or sets the confirm button text.
        /// </summary>
        string ConfirmButtonText { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        string Title { get; set; }
        #endregion
    }

    public partial class ConfirmConfig : BaseConfig, IConfirmConfig
    {
        #region Properties
        /// <summary>
        /// Gets or sets the action invoked when the cancel button is clicked.
        /// </summary>
        public Action CancelButtonClickAction { get; set; }

        /// <summary>
        /// Gets or sets the cancel button text.
        /// </summary>
        public string CancelButtonText { get; set; }

        /// <summary>
        /// Gets or sets the action invoked when the confirm button is clicked.
        /// </summary>
        public Action ConfirmButtonClickAction { get; set; }

        /// <summary>
        /// Gets or sets the confirm button text.
        /// </summary>
        public string ConfirmButtonText { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        #endregion
    }

    public partial class ConfirmAsyncConfig : BaseAsyncConfig, IConfirmConfig
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the cancel button is clicked.
        /// </summary>
        public Action CancelButtonClickAction { get; internal set; }

        /// <summary>
        /// Gets or sets the cancel button text.
        /// </summary>
        public string CancelButtonText { get; set; }

        /// <summary>
        /// Gets the action invoked when the confirm button is clicked.
        /// </summary>
        public Action ConfirmButtonClickAction { get; internal set; }

        /// <summary>
        /// Gets or sets the confirm button text.
        /// </summary>
        public string ConfirmButtonText { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        #endregion
    }
}
