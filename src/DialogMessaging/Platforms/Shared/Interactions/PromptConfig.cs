using DialogMessaging.Schema;
using System;

namespace DialogMessaging.Interactions
{
    public partial interface IPromptConfig : IBaseConfig
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
        /// Gets or sets the hint displayed in the text field.
        /// </summary>
        string Hint { get; set; }

        /// <summary>
        /// Gets or sets the input text.
        /// </summary>
        string InputText { get; set; }

        /// <summary>
        /// Gets or sets the input type.
        /// </summary>
        InputType InputType { get; set; }
        #endregion
    }

    public partial class PromptConfig : BaseConfig, IPromptConfig
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
        /// Gets or sets the hint displayed in the text field.
        /// </summary>
        public string Hint { get; set; }

        /// <summary>
        /// Gets or sets the input text.
        /// </summary>
        public string InputText { get; set; }

        /// <summary>
        /// Gets or sets the input type.
        /// </summary>
        public InputType InputType { get; set; }
        #endregion
    }

    public partial class PromptAsyncConfig : BaseAsyncConfig, IPromptConfig
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
        /// Gets or sets the hint displayed in the text field.
        /// </summary>
        public string Hint { get; set; }

        /// <summary>
        /// Gets or sets the input text.
        /// </summary>
        public string InputText { get; set; }

        /// <summary>
        /// Gets or sets the input type.
        /// </summary>
        public InputType InputType { get; set; }
        #endregion
    }
}
