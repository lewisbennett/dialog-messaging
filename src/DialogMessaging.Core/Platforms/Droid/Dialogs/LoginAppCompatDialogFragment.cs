using Android.Runtime;
using Android.Support.V7.App;
using Android.Text;
using Android.Views;
using Android.Widget;
using DialogMessaging.Core;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public class LoginAppCompatDialogFragment : AbstractAppCompatDialogFragment<ILoginConfig>
    {
        #region Fields
        private EditText _passwordTextField, _usernameTextField;
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

                    Config.LoginButtonClickAction?.Invoke((Config.Username, Config.Password));

                    break;

                case DialogElement.ButtonSecondary:
                    Config.CancelButtonClickAction?.Invoke();
                    break;
            }

            Dismiss();
        }

        private void PasswordVisibilityToggle_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (_passwordTextField == null)
                return;

            Config.ShowPassword = e.IsChecked;

            var typeface = _passwordTextField.Typeface;

            _passwordTextField.InputType = e.IsChecked ? InputTypes.ClassText : InputTypes.ClassText | InputTypes.TextVariationPassword;

            _passwordTextField.Typeface = typeface;
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
                    _usernameTextField.Hint = Config.UsernameHint;

                    _usernameTextField.InputType = Config.UsernameInputType.ToInputTypes();

                    if (Config.UsernameIconResID != null)
                        _usernameTextField.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, (int)Config.UsernameIconResID, 0);

                    break;

                case DialogElement.PasswordInputText:

                    if (!(viewConfig.View is EditText passwordTextField))
                        break;

                    _passwordTextField = passwordTextField;

                    _passwordTextField.Text = Config.Password;
                    _passwordTextField.Hint = Config.PasswordHint;

                    _passwordTextField.InputType = Config.UsernameInputType.ToInputTypes();

                    if (Config.PasswordIconResID != null)
                        _passwordTextField.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, (int)Config.PasswordIconResID, 0);

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

            var view = MessagingService.ViewCreator.CreateView(this, Resource.Layout.dialog_default_login, null, false);

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
    }
}
