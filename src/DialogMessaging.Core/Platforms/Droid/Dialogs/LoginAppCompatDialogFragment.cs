using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using DialogMessaging.Core.Platforms.Droid.Dialogs.Base;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using Google.Android.Material.TextField;
using System;

namespace DialogMessaging.Core.Platforms.Droid.Dialogs
{
    public class LoginAppCompatDialogFragment : BaseAppCompatDialogFragment<ILoginConfig>
    {
        #region Fields
        private TextView _cancelButton, _loginButton;
        private EditText _passwordEditText, _usernameEditText;
        private TextInputLayout _passwordTextInputLayout, _usernameTextInputLayout;
        private CheckBox _passwordVisibilityCheckBox;
        #endregion

        #region Event Handlers
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Config.CancelButtonClickAction?.Invoke();

            Dismiss();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Config.EnteredPassword = _passwordEditText?.Text ?? string.Empty;
            Config.EnteredUsername = _usernameEditText?.Text ?? string.Empty;

            Config.LoginButtonClickAction?.Invoke(Config.EnteredUsername, Config.EnteredPassword);

            Dismiss();
        }

        private void PasswordVisibilityCheckBox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            SetPasswordVisibility();
        }
        #endregion
         
        #region Protected Methods
        protected override void ConfigureDialogBuilder(AlertDialog.Builder builder)
        {
            base.ConfigureDialogBuilder(builder);

            if (MessagingServiceCore.ViewManager.InflateView(Resource.Layout.dialog_default_login, null, false, ConfigureView) is View view)
                builder.SetView(view);

            if (!string.IsNullOrWhiteSpace(Config.CancelButtonText))
                builder.SetNegativeButton(Config.CancelButtonText, CancelButton_Click);

            if (!string.IsNullOrWhiteSpace(Config.LoginButtonText))
                builder.SetPositiveButton(Config.LoginButtonText, LoginButton_Click);
        }

        protected override void ConfigureView(View view, string dialogElement, bool autoHide)
        {
            base.ConfigureView(view, dialogElement, autoHide);

            switch (view, dialogElement)
            {
                // The Android Button inherits from TextView, and using TextView's for buttons is common.
                case (TextView button, DialogElement.ButtonPrimary):

                    if (string.IsNullOrWhiteSpace(Config.LoginButtonText) && autoHide)
                        button.Visibility = ViewStates.Gone;
                    else
                    {
                        _loginButton = button;

                        _loginButton.Text = Config.LoginButtonText;

                        _loginButton.Click += LoginButton_Click;
                    }

                    return;

                // The Android Button inherits from TextView, and using TextView's for buttons is common.
                case (TextView button, DialogElement.ButtonSecondary):

                    if (string.IsNullOrWhiteSpace(Config.CancelButtonText) && autoHide)
                        button.Visibility = ViewStates.Gone;
                    else
                    {
                        _cancelButton = button;

                        _cancelButton.Text = Config.CancelButtonText;

                        _cancelButton.Click += CancelButton_Click;
                    }

                    return;

                case (EditText editText, DialogElement.UsernameInputText):

                    _usernameEditText = editText;

                    _usernameEditText.Text = Config.EnteredUsername;
                    _usernameEditText.InputType = Config.UsernameInputType.ToInputTypes();

                    // Only set the hint on the EditText if it is not wrapped in a TextInputLayout.
                    if (_usernameTextInputLayout == null)
                        _usernameEditText.Hint = Config.UsernameHint;

                    _usernameEditText.SetCompoundDrawablesRelativeWithIntrinsicBounds(
                        Config.UsernameStartIconResID ?? 0,
                        Config.UsernameTopIconResID ?? 0,
                        Config.UsernameEndIconResID ?? 0,
                        Config.UsernameBottomIconResID ?? 0);

                    return;

                case (TextInputLayout textInputLayout, DialogElement.UsernameInputTextContainer):

                    _usernameTextInputLayout = textInputLayout;

                    // Set the hint on the TextInputLayout rather than the EditText inside to maintain the hint animation.
                    _usernameTextInputLayout.Hint = Config.UsernameHint;

                    return;

                case (EditText editText, DialogElement.PasswordInputText):

                    _passwordEditText = editText;

                    _passwordEditText.Text = Config.EnteredPassword;

                    // Only set the hint on the EditText if it is not wrapped in a TextInputLayout.
                    if (_passwordTextInputLayout == null)
                        _passwordEditText.Hint = Config.PasswordHint;

                    _passwordEditText.SetCompoundDrawablesRelativeWithIntrinsicBounds(
                        Config.PasswordStartIconResID ?? 0,
                        Config.PasswordTopIconResID ?? 0,
                        Config.PasswordEndIconResID ?? 0,
                        Config.PasswordBottomIconResID ?? 0);

                    return;

                case (TextInputLayout textInputLayout, DialogElement.PasswordInputTextContainer):

                    _passwordTextInputLayout = textInputLayout;

                    // Set the hint on the TextInputLayout rather than the EditText inside to maintain the hint animation.
                    _passwordTextInputLayout.Hint = Config.PasswordHint;

                    return;

                case (CheckBox checkBox, DialogElement.PasswordVisibilityToggle):

                    _passwordVisibilityCheckBox = checkBox;

                    _passwordVisibilityCheckBox.Checked = Config.ShowPassword;
                    _passwordVisibilityCheckBox.Text = Config.ShowPasswordHint;

                    SetPasswordVisibility();

                    _passwordVisibilityCheckBox.CheckedChange += PasswordVisibilityCheckBox_CheckedChange;

                    return;

                default:
                    return;
            }
        }
        #endregion

        #region Lifecycle
        public override void OnResume()
        {
            base.OnResume();

            Dialog?.Window.SetSoftInputMode(SoftInput.StateAlwaysVisible);

            // Focus on the username field if a username hasn't already been provided.
            if (string.IsNullOrWhiteSpace(Config.EnteredUsername))
                _usernameEditText?.RequestFocus();

            // Otherwise, focus on the password field.
            else
                _passwordEditText?.RequestFocus();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            if (_cancelButton != null)
                _cancelButton.Click -= CancelButton_Click;

            if (_loginButton != null)
                _loginButton.Click -= LoginButton_Click;

            if (_passwordVisibilityCheckBox != null)
                _passwordVisibilityCheckBox.CheckedChange -= PasswordVisibilityCheckBox_CheckedChange;
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
            if (_passwordEditText != null && _passwordVisibilityCheckBox != null)
            {
                Config.ShowPassword = _passwordVisibilityCheckBox.Checked;

                var typeface = _passwordEditText.Typeface;

                _passwordEditText.InputType = Config.ShowPassword ? InputTypes.ClassText : InputTypes.ClassText | InputTypes.TextVariationPassword;
                _passwordEditText.SetSelection(_passwordEditText.Text?.Length ?? 0);

                _passwordEditText.Typeface = typeface;
            }
        }
        #endregion
    }
}
