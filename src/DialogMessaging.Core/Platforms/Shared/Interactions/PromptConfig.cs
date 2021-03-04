using DialogMessaging.Interactions.Base;
using DialogMessaging.Schema;
using System;

namespace DialogMessaging.Interactions
{
    public static partial class PromptConfigDefaults
    {
    }

    public partial interface IPromptConfig : IBaseDialogConfig
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
        Action<string> ConfirmButtonClickAction { get; }

        /// <summary>
        /// Gets or sets the text displayed on the 'confirm' button.
        /// </summary>
        string ConfirmButtonText { get; set; }

        /// <summary>
        /// Gets or sets the entered text.
        /// </summary>
        string EnteredText { get; set; }

        /// <summary>
        /// Gets or sets the hint displayed within the text field.
        /// </summary>
        string Hint { get; set; }

        /// <summary>
        /// Gets or sets the input type.
        /// </summary>
        InputType InputType { get; set; }
        #endregion
    }

    public partial class PromptConfig : BaseDialogConfig, IPromptConfig
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
        public Action<string> ConfirmButtonClickAction { get; set; }

        /// <summary>
        /// Gets or sets the text displayed on the 'confirm' button.
        /// </summary>
        public string ConfirmButtonText { get; set; }

        /// <summary>
        /// Gets or sets the entered text.
        /// </summary>
        public string EnteredText { get; set; }

        /// <summary>
        /// Gets or sets the hint displayed within the text field.
        /// </summary>
        public string Hint { get; set; }

        /// <summary>
        /// Gets or sets the input type.
        /// </summary>
        public InputType InputType { get; set; }
        #endregion
    }

    public partial class PromptAsyncConfig : BaseDialogAsyncConfig, IPromptConfig
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
        public Action<string> ConfirmButtonClickAction { get; internal set; }

        /// <summary>
        /// Gets or sets the text displayed on the 'confirm' button.
        /// </summary>
        public string ConfirmButtonText { get; set; }

        /// <summary>
        /// Gets or sets the entered text.
        /// </summary>
        public string EnteredText { get; set; }

        /// <summary>
        /// Gets or sets the hint displayed within the text field.
        /// </summary>
        public string Hint { get; set; }

        /// <summary>
        /// Gets or sets the input type.
        /// </summary>
        public InputType InputType { get; set; }
        #endregion
    }
}
