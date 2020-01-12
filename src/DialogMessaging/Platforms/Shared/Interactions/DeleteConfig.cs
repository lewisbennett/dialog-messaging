using System;

namespace DialogMessaging.Interactions
{
    public partial interface IDeleteConfig : IBaseConfig
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
        /// Gets the action invoked when the delete button is clicked.
        /// </summary>
        Action DeleteButtonClickAction { get; }

        /// <summary>
        /// Gets or sets the delete button text.
        /// </summary>
        string DeleteButtonText { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        string Title { get; set; }
        #endregion
    }

    public partial class DeleteConfig : BaseConfig, IDeleteConfig
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
        /// Gets or sets the action invoked when the delete button is clicked.
        /// </summary>
        public Action DeleteButtonClickAction { get; set; }

        /// <summary>
        /// Gets or sets the delete button text.
        /// </summary>
        public string DeleteButtonText { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        #endregion
    }

    public partial class DeleteAsyncConfig : BaseAsyncConfig, IDeleteConfig
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
        /// Gets the action invoked when the delete button is clicked.
        /// </summary>
        public Action DeleteButtonClickAction { get; internal set; }

        /// <summary>
        /// Gets or sets the delete button text.
        /// </summary>
        public string DeleteButtonText { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        #endregion
    }
}
