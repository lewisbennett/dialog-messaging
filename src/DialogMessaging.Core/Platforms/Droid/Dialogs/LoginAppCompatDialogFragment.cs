using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using DialogMessaging.Core;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using Google.Android.Material.TextField;
using System;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public class LoginAppCompatDialogFragment : AbstractAppCompatDialogFragment<ILoginConfig>
    {
        #region Fields
        private EditText _passwordTextField, _usernameTextField;
        private TextInputLayout _passwordTextInputLayout, _usernameTextInputLayout;
        private CheckBox _passwordVisibilityToggle;
        #endregion

        #region Event Handlers
        public override void OnRegisteredViewClick(string dialogElement, View view)
        {
            base.OnRegisteredViewClick(dialogElement, view);

            switch (dialogElement)
            {
                case DialogElement.ButtonPrimary:

                    Config.Username = _usernameTextField?.Text ?? string.Empty;
                    Config.Password = _passwordTextField?.Text ?? string.Empty;

                    Config.LoginButtonClickAction?.Invoke(Config.Username, Config.Password);

                    break;

                case DialogElement.ButtonSecondary:
                    Config.CancelButtonClickAction?.Invoke();
                    break;
            }

            Dismiss();
        }

        private void PasswordVisibilityToggle_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            SetPasswordVisibility();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Assigns configuration values to UI elements.
        /// </summary>
        /// <param name="viewConfig">The view configuration.</param>
        public override void AssignValue(ViewConfig viewConfig)
        {
            switch (viewConfig.DialogElement)
            {
                case DialogElement.UsernameInputText:

                    if (!(viewConfig.View is EditText usernameTextField))
                        break;

                    _usernameTextField = usernameTextField;

                    _usernameTextField.Text = Config.Username;
                    _usernameTextField.InputType = Config.UsernameInputType.ToInputTypes();

                    if (_usernameTextInputLayout == null)
                        _usernameTextField.Hint = Config.UsernameHint;

                    if (Config.UsernameIconResID != null)
                        _usernameTextField.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, (int)Config.UsernameIconResID, 0);

                    break;

                case DialogElement.UsernameInputTextContainer:

                    if (viewConfig.View is TextInputLayout usernameTextInputLayout)
                    {
                        _usernameTextInputLayout = usernameTextInputLayout;

                        _usernameTextInputLayout.Hint = Config.UsernameHint;
                    }

                    break;

                case DialogElement.PasswordInputText:

                    if (!(viewConfig.View is EditText passwordTextField))
                        break;

                    _passwordTextField = passwordTextField;

                    _passwordTextField.Text = Config.Password;
                    _passwordTextField.InputType = Config.UsernameInputType.ToInputTypes();

                    if (_passwordTextInputLayout == null)
                        _passwordTextField.Hint = Config.PasswordHint;

                    if (Config.PasswordIconResID != null)
                        _passwordTextField.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, (int)Config.PasswordIconResID, 0);

                    break;

                case DialogElement.PasswordInputTextContainer:

                    if (viewConfig.View is TextInputLayout passwordTextInputLayout)
                    {
                        _passwordTextInputLayout = passwordTextInputLayout;

                        _passwordTextInputLayout.Hint = Config.PasswordHint;
                    }

                    break;

                case DialogElement.PasswordVisibilityToggle:

                    if (!(viewConfig.View is CheckBox checkBox))
                        break;

                    _passwordVisibilityToggle = checkBox;

                    _passwordVisibilityToggle.Checked = Config.ShowPassword;
                    _passwordVisibilityToggle.Text = Config.ShowPasswordHint;

                    break;

                case DialogElement.ButtonPrimary:

                    if (string.IsNullOrWhiteSpace(Config.LoginButtonText) || !viewConfig.View.TrySetText(Config.LoginButtonText))
                        viewConfig.HideElementIfNeeded();
                    else
                        RegisterForClickEvents(viewConfig.DialogElement, viewConfig.View);

                    break;

                case DialogElement.ButtonSecondary:

                    if (string.IsNullOrWhiteSpace(Config.CancelButtonText) || !viewConfig.View.TrySetText(Config.CancelButtonText))
                        viewConfig.HideElementIfNeeded();
                    else
                        RegisterForClickEvents(viewConfig.DialogElement, viewConfig.View);

                    break;
            }

            base.AssignValue(viewConfig);
        }

        /// <summary>
        /// Assigns configuration values to the dialog builder.
        /// </summary>
        public override void CreateDialog(AlertDialog.Builder builder)
        {
            base.CreateDialog(builder);

            var view = MessagingServiceCore.ViewCreator.CreateView(this, Resource.Layout.dialog_default_login, null, false);

            if (view != null)
                builder.SetView(view);

            builder.SetPositiveButton(Config.LoginButtonText, (s, e) => OnRegisteredViewClick(DialogElement.ButtonPrimary, s as View));
            builder.SetNegativeButton(Config.CancelButtonText, (s, e) => OnRegisteredViewClick(DialogElement.ButtonSecondary, s as View));
        }
        #endregion

        #region Lifecycle
        public override void OnResume()
        {
            base.OnResume();

            if (Dialog != null)
                Dialog.Window.SetSoftInputMode(SoftInput.StateAlwaysVisible);

            if (_usernameTextField != null)
                _usernameTextField.RequestFocus();

            if (_passwordVisibilityToggle != null)
                _passwordVisibilityToggle.CheckedChange += PasswordVisibilityToggle_CheckedChange;

            SetPasswordVisibility();
        }

        public override void OnPause()
        {
            base.OnPause();

            if (_passwordVisibilityToggle != null)
                _passwordVisibilityToggle.CheckedChange -= PasswordVisibilityToggle_CheckedChange;
        }
        #endregion

        #region Constructors
        public LoginAppCompatDialogFragment()
            : base()
        {
        }

        public LoginAppCompatDialogFragment(ILoginConfig config)
            : base(config)
        {
        }

        public LoginAppCompatDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion

        #region Private Methods
        private void SetPasswordVisibility()
        {
            if (_passwordTextField == null || _passwordVisibilityToggle == null)
                return;

            Config.ShowPassword = _passwordVisibilityToggle.Checked;

            var typeface = _passwordTextField.Typeface;

            _passwordTextField.InputType = _passwordVisibilityToggle.Checked ? InputTypes.ClassText : InputTypes.ClassText | InputTypes.TextVariationPassword;
            _passwordTextField.SetSelection(_passwordTextField.Text?.Length ?? 0);

            _passwordTextField.Typeface = typeface;
        }
        #endregion
    }
}
