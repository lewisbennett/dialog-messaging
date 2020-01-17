using Android.App;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;
using System.Collections.Generic;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public class PromptDialogFragment : AbstractDialogFragment<IPromptConfig>
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
        /// <param name="dialogElement">The dialog element extracted from the view.</param>
        public override void AssignValue(KeyValuePair<string, Tuple<View, bool>> dialogElement)
        {
            switch (dialogElement.Key)
            {
                case DialogElement.InputText:

                    if (!(dialogElement.Value.Item1 is EditText textField))
                        break;

                    _textField = textField;

                    _textField.Text = Config.InputText;
                    _textField.Hint = Config.Hint;
                    _textField.InputType = Config.InputType.ToInputTypes();

                    if (Config.IconResID != null)
                        _textField.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, (int)Config.IconResID, 0);

                    return;

                case DialogElement.ButtonPrimary:

                    if (!string.IsNullOrWhiteSpace(Config.ConfirmButtonText) && dialogElement.Value.Item1.TrySetText(Config.ConfirmButtonText))
                    {
                        RegisterForClickEvents(dialogElement.Key, dialogElement.Value.Item1);
                        return;
                    }

                    break;

                case DialogElement.ButtonSecondary:

                    if (!string.IsNullOrWhiteSpace(Config.CancelButtonText) && dialogElement.Value.Item1.TrySetText(Config.CancelButtonText))
                    {
                        RegisterForClickEvents(dialogElement.Key, dialogElement.Value.Item1);
                        return;
                    }

                    break;

                default:
                    base.AssignValue(dialogElement);
                    return;
            }

            dialogElement.HideElementIfNeeded();
        }

        /// <summary>
        /// Assigns configuration values to the dialog builder.
        /// </summary>
        public override void CreateDialog(AlertDialog.Builder builder)
        {
            base.CreateDialog(builder);

            var view = new CustomLayoutInflater(Context, this).Inflate(Resource.Layout.dialog_default_prompt, null, false);

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

            Dialog.Window.SetSoftInputMode(SoftInput.StateVisible);
            _textField.RequestFocus();
        }
        #endregion

        #region Constructors
        public PromptDialogFragment()
            : base()
        {
        }
        
        public PromptDialogFragment(IPromptConfig config)
            : base(config)
        {
        }

        public PromptDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion
    }
}
