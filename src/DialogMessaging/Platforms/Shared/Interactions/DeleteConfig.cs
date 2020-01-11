using System;

namespace DialogMessaging.Interactions
{
    public partial class DeleteConfig
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
        /// Gets or sets the action invoked when the alert is dismissed.
        /// </summary>
        public Action DismissedAction { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        #endregion
    }
}
