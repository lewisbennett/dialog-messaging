using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using DialogMessaging.Core.Platforms.Droid.Dialogs.Base;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;

namespace DialogMessaging.Core.Platforms.Droid.Dialogs
{
    public class DeleteAppCompatDialogFragment : BaseAppCompatDialogFragment<IDeleteConfig>
    {
        #region Fields
        private TextView _cancelButton, _deleteButton;
        #endregion

        #region Event Handlers
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Config.CancelButtonClickAction?.Invoke();

            Dismiss();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Config.DeleteButtonClickAction?.Invoke();

            Dismiss();
        }
        #endregion

        #region Protected Methods
        protected override void ConfigureDialogBuilder(AlertDialog.Builder builder)
        {
            base.ConfigureDialogBuilder(builder);

            if (!string.IsNullOrWhiteSpace(Config.CancelButtonText))
                builder.SetNegativeButton(Config.CancelButtonText, CancelButton_Click);

            if (!string.IsNullOrWhiteSpace(Config.DeleteButtonText))
                builder.SetPositiveButton(Config.DeleteButtonText, DeleteButton_Click);
        }

        protected override void ConfigureView(View view, string dialogElement, bool autoHide)
        {
            base.ConfigureView(view, dialogElement, autoHide);

            switch (view, dialogElement)
            {
                // The Android Button inherits from TextView, and using TextView's for buttons is common.
                case (TextView button, DialogElement.ButtonPrimary):

                    if (string.IsNullOrWhiteSpace(Config.DeleteButtonText) && autoHide)
                        button.Visibility = ViewStates.Gone;
                    else
                    {
                        _deleteButton = button;

                        _deleteButton.Text = Config.DeleteButtonText;

                        _deleteButton.Click += DeleteButton_Click;
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

                default:
                    return;
            }
        }
        #endregion

        #region Lifecycle
        public override void OnDestroy()
        {
            base.OnDestroy();

            if (_cancelButton != null)
                _cancelButton.Click -= CancelButton_Click;

            if (_deleteButton != null)
                _deleteButton.Click -= DeleteButton_Click;
        }
        #endregion

        #region Constructors
        public DeleteAppCompatDialogFragment()
            : base()
        {
        }

        public DeleteAppCompatDialogFragment(IDeleteConfig config)
            : base(config)
        {
        }

        public DeleteAppCompatDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion
    }
}
