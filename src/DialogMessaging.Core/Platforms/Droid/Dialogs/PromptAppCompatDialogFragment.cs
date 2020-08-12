using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using DialogMessaging.Core;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public class PromptAppCompatDialogFragment : AbstractAppCompatDialogFragment<IPromptConfig>
    {
        #region Fields
        private EditText _textField;
        #endregion

        #region Event Handlers
        public override void OnRegisteredViewClick(string dialogElement, View view)
        {
            base.OnRegisteredViewClick(dialogElement, view);

            switch (dialogElement)
            {
                case DialogElement.ButtonPrimary:

                    Config.InputText = _textField?.Text ?? string.Empty;
                    Config.ConfirmButtonClickAction?.Invoke(Config.InputText);

                    break;

                case DialogElement.ButtonSecondary:
                    Config.CancelButtonClickAction?.Invoke();
                    break;
            }

            Dismiss();
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
                case DialogElement.InputText:

                    if (!(viewConfig.View is EditText textField))
                        break;

                    _textField = textField;

                    _textField.Text = Config.InputText;
                    _textField.Hint = Config.Hint;
                    _textField.InputType = Config.InputType.ToInputTypes();

                    if (Config.IconResID != null)
                        _textField.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, (int)Config.IconResID, 0);

                    break;

                case DialogElement.ButtonPrimary:

                    if (string.IsNullOrWhiteSpace(Config.ConfirmButtonText) || !viewConfig.View.TrySetText(Config.ConfirmButtonText))
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

            var view = MessagingServiceCore.ViewCreator.CreateView(this, Resource.Layout.dialog_default_prompt, null, false);

            if (view != null)
                builder.SetView(view);

            builder.SetPositiveButton(Config.ConfirmButtonText, (s, e) => OnRegisteredViewClick(DialogElement.ButtonPrimary, s as View));
            builder.SetNegativeButton(Config.CancelButtonText, (s, e) => OnRegisteredViewClick(DialogElement.ButtonSecondary, s as View));
        }
        #endregion

        #region Lifecycle
        public override void OnResume()
        {
            base.OnResume();

            if (Dialog == null || _textField == null)
                return;

            Dialog.Window.SetSoftInputMode(SoftInput.StateAlwaysVisible);
            _textField.RequestFocus();
        }
        #endregion

        #region Constructors
        public PromptAppCompatDialogFragment()
            : base()
        {
        }

        public PromptAppCompatDialogFragment(IPromptConfig config)
            : base(config)
        {
        }

        public PromptAppCompatDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion
    }
}
