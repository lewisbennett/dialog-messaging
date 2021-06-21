using Android.OS;
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
        private string _enteredPassword, _enteredUsername;
        private EditText _passwordEditText, _usernameEditText;
        private TextInputLayout _passwordTextInputLayout, _usernameTextInputLayout;
        private CheckBox _passwordVisibilityCheckBox;
        private bool? _showPassword;
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

                    _loginButton = button;

                    if (string.IsNullOrWhiteSpace(Config.LoginButtonText) && autoHide)
                        _loginButton.Visibility = ViewStates.Gone;
                    else
                        _loginButton.Text = Config.LoginButtonText;

                    return;

                // The Android Button inherits from TextView, and using TextView's for buttons is common.
                case (TextView button, DialogElement.ButtonSecondary):

                    _cancelButton = button;

                    if (string.IsNullOrWhiteSpace(Config.CancelButtonText) && autoHide)
                        _cancelButton.Visibility = ViewStates.Gone;
                    else
                        _cancelButton.Text = Config.CancelButtonText;

                    return;

                case (EditText editText, DialogElement.UsernameInputText):

                    _usernameEditText = editText;

                    // Set the EditText's text to the username provided in the config, if any, if a previously entered username isn't available.
                    if (string.IsNullOrWhiteSpace(_enteredUsername))
                        _usernameEditText.Text = Config.EnteredUsername;

                    // Otherwise, use and nullify the previously entered username.
                    else
                    {
                        _usernameEditText.Text = _enteredUsername;

                        _enteredUsername = null;
                    }

                    _usernameEditText.InputType = Config.UsernameInputType.ToInputTypes();

                    // Only set the hint on the EditText if it is not wrapped in a TextInputLayout.
                    if (_usernameTextInputLayout == null)
                        _usernameEditText.Hint = Config.UsernameHint;

                    _usernameEditText.UpdateCompoundDrawables(Context, Config.UsernameLeftIconResID, Config.UsernameTopIconResID, Config.UsernameRightIconResID, Config.UsernameBottomIconResID);

                    return;

                case (TextInputLayout textInputLayout, DialogElement.UsernameInputTextContainer):

                    _usernameTextInputLayout = textInputLayout;

                    // Set the hint on the TextInputLayout rather than the EditText inside to maintain the hint animation.
                    _usernameTextInputLayout.Hint = Config.UsernameHint;

                    return;

                case (EditText editText, DialogElement.PasswordInputText):

                    _passwordEditText = editText;

                    // Set the EditText's text to the password provided in the config, if any, if a previously entered password isn't available.
                    if (string.IsNullOrWhiteSpace(_enteredPassword))
                        _passwordEditText.Text = Config.EnteredPassword;

                    // Otherwise, use and nullify the previously entered password.
                    else
                    {
                        _passwordEditText.Text = _enteredPassword;

                        _enteredPassword = null;
                    }

                    // Only set the hint on the EditText if it is not wrapped in a TextInputLayout.
                    if (_passwordTextInputLayout == null)
                        _passwordEditText.Hint = Config.PasswordHint;

                    _passwordEditText.UpdateCompoundDrawables(Context, Config.PasswordLeftIconResID, Config.PasswordTopIconResID, Config.PasswordRightIconResID, Config.PasswordBottomIconResID);

                    SetPasswordVisibility();

                    return;

                case (TextInputLayout textInputLayout, DialogElement.PasswordInputTextContainer):

                    _passwordTextInputLayout = textInputLayout;

                    // Set the hint on the TextInputLayout rather than the EditText inside to maintain the hint animation.
                    _passwordTextInputLayout.Hint = Config.PasswordHint;

                    return;

                case (CheckBox checkBox, DialogElement.PasswordVisibilityToggle):

                    _passwordVisibilityCheckBox = checkBox;

                    if (string.IsNullOrEmpty(Config.ShowPasswordHint) && autoHide)
                        _passwordVisibilityCheckBox.Visibility = ViewStates.Gone;

                    else
                    {
                        // Restore the CheckBox' checked state, if available, then nullify.
                        if (_showPassword.HasValue)
                        {
                            _passwordVisibilityCheckBox.Checked = _showPassword.Value;

                            _showPassword = null;
                        }
                        // Otherwise, use the state provided by the config.
                        else
                            _passwordVisibilityCheckBox.Checked = Config.ShowPassword;

                        _passwordVisibilityCheckBox.Text = Config.ShowPasswordHint;
                    }

                    SetPasswordVisibility();

                    return;

                default:
                    return;
            }
        }
        #endregion

        #region Lifecycle
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Get the saved entered username and password, if any.
            if (savedInstanceState != null)
            {
                _enteredPassword = savedInstanceState.GetString(EnteredPasswordSaveID);
                _enteredUsername = savedInstanceState.GetString(EnteredUsernameSaveID);

                _showPassword = savedInstanceState.GetBoolean(ShowPasswordSaveID);
            }
        }

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

            if (_cancelButton != null)
                _cancelButton.Click += CancelButton_Click;

            if (_loginButton != null)
                _loginButton.Click += LoginButton_Click;

            if (_passwordVisibilityCheckBox != null)
                _passwordVisibilityCheckBox.CheckedChange += PasswordVisibilityCheckBox_CheckedChange;
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);

            // Save the entered username and password, if any, so it can be restored when the dialog reappears.
            var enteredPassword = _passwordEditText?.Text;
            var enteredUsername = _usernameEditText?.Text;

            if (!string.IsNullOrWhiteSpace(enteredPassword))
                outState.PutString(EnteredPasswordSaveID, enteredPassword);

            if (!string.IsNullOrWhiteSpace(enteredUsername))
                outState.PutString(EnteredUsernameSaveID, enteredUsername);

            // Save the current 'show password' state, so it can be restored when the dialog reappears.
            if (_passwordVisibilityCheckBox != null)
                outState.PutBoolean(ShowPasswordSaveID, _passwordVisibilityCheckBox.Checked);
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

        #region Constant Values
        public const string EnteredPasswordSaveID = "entered_password";
        public const string EnteredUsernameSaveID = "entered_username";
        public const string ShowPasswordSaveID = "show_password";
        #endregion
    }
}
