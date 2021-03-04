using DialogMessaging.Interactions.Base;
using DialogMessaging.Schema;
using System;

namespace DialogMessaging.Interactions
{
    public static partial class LoginConfigDefaults
    {
    }

    public partial interface ILoginConfig : IBaseDialogConfig
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
        /// Gets or sets the entered password.
        /// </summary>
        string EnteredPassword { get; set; }

        /// <summary>
        /// Gets or sets the entered text.
        /// </summary>
        string EnteredUsername { get; set; }

        /// <summary>
        /// Gets the action invoked when the 'login' button is clicked.
        /// </summary>
        Action<string, string> LoginButtonClickAction { get; }

        /// <summary>
        /// Gets or sets the text displayed on the 'login' button.
        /// </summary>
        string LoginButtonText { get; set; }

        /// <summary>
        /// Gets or sets the hint for the password field.
        /// </summary>
        string PasswordHint { get; set; }

        /// <summary>
        /// Gets or sets whether to show the password.
        /// </summary>
        bool ShowPassword { get; set; }

        /// <summary>
        /// Gets or sets the hint for the show password toggle.
        /// </summary>
        string ShowPasswordHint { get; set; }

        /// <summary>
        /// Gets or sets the hint for the username field.
        /// </summary>
        string UsernameHint { get; set; }

        /// <summary>
        /// Gets or sets the input type for the username field.
        /// </summary>
        InputType UsernameInputType { get; set; }
        #endregion
    }

    public partial class LoginConfig : BaseDialogConfig, ILoginConfig
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
        /// Gets or sets the entered password.
        /// </summary>
        public string EnteredPassword { get; set; }

        /// <summary>
        /// Gets or sets the entered text.
        /// </summary>
        public string EnteredUsername { get; set; }

        /// <summary>
        /// Gets or sets the action invoked when the 'login' button is clicked.
        /// </summary>
        public Action<string, string> LoginButtonClickAction { get; set; }

        /// <summary>
        /// Gets or sets the text displayed on the 'login' button.
        /// </summary>
        public string LoginButtonText { get; set; }

        /// <summary>
        /// Gets or sets the hint for the password field.
        /// </summary>
        public string PasswordHint { get; set; }

        /// <summary>
        /// Gets or sets whether to show the password.
        /// </summary>
        public bool ShowPassword { get; set; }

        /// <summary>
        /// Gets or sets the hint for the show password toggle.
        /// </summary>
        public string ShowPasswordHint { get; set; }

        /// <summary>
        /// Gets or sets the hint for the username field.
        /// </summary>
        public string UsernameHint { get; set; }

        /// <summary>
        /// Gets or sets the input type for the username field.
        /// </summary>
        public InputType UsernameInputType { get; set; }
        #endregion
    }

    public partial class LoginAsyncConfig : BaseDialogAsyncConfig, ILoginConfig
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
        /// Gets or sets the entered password.
        /// </summary>
        public string EnteredPassword { get; set; }

        /// <summary>
        /// Gets or sets the entered text.
        /// </summary>
        public string EnteredUsername { get; set; }

        /// <summary>
        /// Gets the action invoked when the 'login' button is clicked.
        /// </summary>
        public Action<string, string> LoginButtonClickAction { get; internal set; }

        /// <summary>
        /// Gets or sets the text displayed on the 'login' button.
        /// </summary>
        public string LoginButtonText { get; set; }

        /// <summary>
        /// Gets or sets the hint for the password field.
        /// </summary>
        public string PasswordHint { get; set; }

        /// <summary>
        /// Gets or sets whether to show the password.
        /// </summary>
        public bool ShowPassword { get; set; }

        /// <summary>
        /// Gets or sets the hint for the show password toggle.
        /// </summary>
        public string ShowPasswordHint { get; set; }

        /// <summary>
        /// Gets or sets the hint for the username field.
        /// </summary>
        public string UsernameHint { get; set; }

        /// <summary>
        /// Gets or sets the input type for the username field.
        /// </summary>
        public InputType UsernameInputType { get; set; }
        #endregion
    }
}
