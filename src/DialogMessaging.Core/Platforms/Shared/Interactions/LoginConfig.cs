using DialogMessaging.Schema;
using System;

namespace DialogMessaging.Interactions
{
    public partial interface ILoginConfig : IBaseConfig
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
        /// Gets the action invoked when the login button is clicked.
        /// </summary>
        Action<string, string> LoginButtonClickAction { get; }

        /// <summary>
        /// Gets or sets the login button text.
        /// </summary>
        string LoginButtonText { get; set; }

        /// <summary>
        /// Gets or sets the entered password.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets the hint displayed in the password text field.
        /// </summary>
        string PasswordHint { get; set; }

        /// <summary>
        /// Gets or sets whether the password should be shown.
        /// </summary>
        bool ShowPassword { get; set; }

        /// <summary>
        /// Gets or sets the hint displayed along with the show password toggle.
        /// </summary>
        string ShowPasswordHint { get; set; }

        /// <summary>
        /// Gets or sets the entered username.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Gets or sets the hint displayed in the username text field.
        /// </summary>
        string UsernameHint { get; set; }

        /// <summary>
        /// Gets or sets the username input type.
        /// </summary>
        InputType UsernameInputType { get; set; }
        #endregion
    }

    public partial class LoginConfig : BaseConfig, ILoginConfig
    {
        #region Properties
        /// <summary>
        /// Gets the action invoked when the cancel button is clicked.
        /// </summary>
        public Action CancelButtonClickAction { get; set; }

        /// <summary>
        /// Gets or sets the cancel button text.
        /// </summary>
        public string CancelButtonText { get; set; }

        /// <summary>
        /// Gets or sets the input type.
        /// </summary>
        public InputType UsernameInputType { get; set; }

        /// <summary>
        /// Gets the action invoked when the login button is clicked.
        /// </summary>
        public Action<string, string> LoginButtonClickAction { get; set; }

        /// <summary>
        /// Gets or sets the login button text.
        /// </summary>
        public string LoginButtonText { get; set; }

        /// <summary>
        /// Gets or sets the entered password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the hint displayed in the password text field.
        /// </summary>
        public string PasswordHint { get; set; }

        /// <summary>
        /// Gets or sets whether the password should be shown.
        /// </summary>
        public bool ShowPassword { get; set; }

        /// <summary>
        /// Gets or sets the hint to display along with the show password toggle.
        /// </summary>
        public string ShowPasswordHint { get; set; }

        /// <summary>
        /// Gets or sets the entered username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the hint displayed in the username text field.
        /// </summary>
        public string UsernameHint { get; set; }
        #endregion
    }

    public partial class LoginAsyncConfig : BaseAsyncConfig, ILoginConfig
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
        /// Gets or sets the input type.
        /// </summary>
        public InputType UsernameInputType { get; set; }

        /// <summary>
        /// Gets the action invoked when the login button is clicked.
        /// </summary>
        public Action<string, string> LoginButtonClickAction { get; internal set; }

        /// <summary>
        /// Gets or sets the login button text.
        /// </summary>
        public string LoginButtonText { get; set; }

        /// <summary>
        /// Gets or sets the entered password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the hint displayed in the password text field.
        /// </summary>
        public string PasswordHint { get; set; }

        /// <summary>
        /// Gets or sets whether the password should be shown.
        /// </summary>
        public bool ShowPassword { get; set; }

        /// <summary>
        /// Gets or sets the hint to display along with the show password toggle.
        /// </summary>
        public string ShowPasswordHint { get; set; }

        /// <summary>
        /// Gets or sets the entered username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the hint displayed in the username text field.
        /// </summary>
        public string UsernameHint { get; set; }
        #endregion
    }
}
