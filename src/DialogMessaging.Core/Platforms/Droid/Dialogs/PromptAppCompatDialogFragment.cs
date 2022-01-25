using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using DialogMessaging.Core.Platforms.Droid.Dialogs.Base;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using Google.Android.Material.TextField;

namespace DialogMessaging.Core.Platforms.Droid.Dialogs;

public class PromptAppCompatDialogFragment : BaseAppCompatDialogFragment<IPromptConfig>
{
    #region Fields
    private TextView _cancelButton, _confirmButton;
    private EditText _editText;
    private string _enteredText;
    private TextInputLayout _textInputLayout;
    #endregion

    #region Event Handlers
    private void CancelButton_Click(object sender, EventArgs e)
    {
        Config.CancelButtonClickAction?.Invoke();

        Dismiss();
    }

    private void ConfirmButton_Click(object sender, EventArgs e)
    {
        Config.ConfirmButtonClickAction?.Invoke(_editText?.Text ?? string.Empty);

        Dismiss();
    }
    #endregion

    #region Protected Methods
    protected override void ConfigureDialogBuilder(AlertDialog.Builder builder)
    {
        base.ConfigureDialogBuilder(builder);

        if (MessagingServiceCore.ViewManager.InflateView(Resource.Layout.dialog_default_prompt, null, false, ConfigureView) is View view)
            builder.SetView(view);

        if (!string.IsNullOrWhiteSpace(Config.CancelButtonText))
            builder.SetNegativeButton(Config.CancelButtonText, CancelButton_Click);

        if (!string.IsNullOrWhiteSpace(Config.ConfirmButtonText))
            builder.SetPositiveButton(Config.ConfirmButtonText, ConfirmButton_Click);
    }

    protected override void ConfigureView(View view, string dialogElement, bool autoHide)
    {
        base.ConfigureView(view, dialogElement, autoHide);

        switch (view, dialogElement)
        {
            // The Android Button inherits from TextView, and using TextView's for buttons is common.
            case (TextView button, DialogElement.ButtonPrimary):

                _confirmButton = button;

                if (string.IsNullOrWhiteSpace(Config.ConfirmButtonText) && autoHide)
                    _confirmButton.Visibility = ViewStates.Gone;

                else
                    _confirmButton.Text = Config.ConfirmButtonText;

                return;

            // The Android Button inherits from TextView, and using TextView's for buttons is common.
            case (TextView button, DialogElement.ButtonSecondary):

                _cancelButton = button;

                if (string.IsNullOrWhiteSpace(Config.CancelButtonText) && autoHide)
                    _cancelButton.Visibility = ViewStates.Gone;

                else
                    _cancelButton.Text = Config.CancelButtonText;

                return;

            case (EditText editText, DialogElement.InputText):

                _editText = editText;

                // Set the EditText's text to the text provided in the config, if any, if previously entered text isn't available.
                if (string.IsNullOrWhiteSpace(_enteredText))
                    _editText.Text = Config.EnteredText;

                // Otherwise, use and nullify the previously entered text.
                else
                {
                    _editText.Text = _enteredText;

                    _enteredText = null;
                }

                _editText.InputType = Config.InputType.ToInputTypes();

                // Only set the hint on the EditText if it is not wrapped in a TextInputLayout.
                if (_textInputLayout == null)
                    _editText.Hint = Config.Hint;

                _editText.UpdateCompoundDrawables(Context, Config.LeftIconResID, Config.TopIconResID, Config.RightIconResID, Config.BottomIconResID);

                return;

            case (TextInputLayout textInputLayout, DialogElement.InputTextContainer):

                _textInputLayout = textInputLayout;

                // Set the hint on the TextInputLayout rather than the EditText inside to maintain the hint animation.
                _textInputLayout.Hint = Config.Hint;

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

        // Get the saved entered text, if any.
        _enteredText = savedInstanceState?.GetString(EnteredTextSaveID);
    }

    public override void OnResume()
    {
        base.OnResume();

        Dialog?.Window.SetSoftInputMode(SoftInput.StateAlwaysVisible);

        _editText?.RequestFocus();

        if (_cancelButton != null)
            _cancelButton.Click += CancelButton_Click;

        if (_confirmButton != null)
            _confirmButton.Click += ConfirmButton_Click;
    }

    public override void OnSaveInstanceState(Bundle outState)
    {
        base.OnSaveInstanceState(outState);

        // Save the entered text, if any, so it can be restored when the dialog re-appears.
        var enteredText = _editText?.Text;

        if (!string.IsNullOrWhiteSpace(enteredText))
            outState.PutString(EnteredTextSaveID, enteredText);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();

        if (_cancelButton != null)
            _cancelButton.Click -= CancelButton_Click;

        if (_confirmButton != null)
            _confirmButton.Click -= ConfirmButton_Click;
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

    #region Constant Values
    public const string EnteredTextSaveID = "entered_text";
    #endregion
}