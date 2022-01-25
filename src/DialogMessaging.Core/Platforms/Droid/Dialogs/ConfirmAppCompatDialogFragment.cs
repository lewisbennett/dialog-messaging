using System;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using DialogMessaging.Core.Platforms.Droid.Dialogs.Base;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;

namespace DialogMessaging.Core.Platforms.Droid.Dialogs;

public class ConfirmAppCompatDialogFragment : BaseAppCompatDialogFragment<IConfirmConfig>
{
    #region Fields
    private TextView _cancelButton, _confirmButton;
    #endregion

    #region Event Handlers
    private void CancelButton_Click(object sender, EventArgs e)
    {
        Config.CancelButtonClickAction?.Invoke();

        Dismiss();
    }

    private void ConfirmButton_Click(object sender, EventArgs e)
    {
        Config.ConfirmButtonClickAction?.Invoke();

        Dismiss();
    }
    #endregion

    #region Protected Methods
    protected override void ConfigureDialogBuilder(AlertDialog.Builder builder)
    {
        base.ConfigureDialogBuilder(builder);

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

            default:

                return;
        }
    }
    #endregion

    #region Lifecycle
    public override void OnResume()
    {
        base.OnResume();

        if (_cancelButton != null)
            _cancelButton.Click += CancelButton_Click;

        if (_confirmButton != null)
            _confirmButton.Click += ConfirmButton_Click;
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
    public ConfirmAppCompatDialogFragment()
        : base()
    {
    }

    public ConfirmAppCompatDialogFragment(IConfirmConfig config)
        : base(config)
    {
    }

    public ConfirmAppCompatDialogFragment(IntPtr handle, JniHandleOwnership transfer)
        : base(handle, transfer)
    {
    }
    #endregion
}