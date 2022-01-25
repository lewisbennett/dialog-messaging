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
    public class AlertAppCompatDialogFragment : BaseAppCompatDialogFragment<IAlertConfig>
    {
        #region Fields
        private TextView _okButton;
        #endregion

        #region Event Handlers
        private void OkButton_Click(object sender, EventArgs e)
        {
            Config.OkButtonClickAction?.Invoke();

            Dismiss();
        }
        #endregion

        #region Protected Methods
        protected override void ConfigureDialogBuilder(AlertDialog.Builder builder)
        {
            base.ConfigureDialogBuilder(builder);

            if (!string.IsNullOrWhiteSpace(Config.OkButtonText))
                builder.SetPositiveButton(Config.OkButtonText, OkButton_Click);
        }

        protected override void ConfigureView(View view, string dialogElement, bool autoHide)
        {
            base.ConfigureView(view, dialogElement, autoHide);

            switch (view, dialogElement)
            {
                // The Android Button inherits from TextView, and using TextView's for buttons is common.
                case (TextView button, DialogElement.ButtonPrimary):

                    _okButton = button;

                    if (string.IsNullOrWhiteSpace(Config.OkButtonText) && autoHide)
                        _okButton.Visibility = ViewStates.Gone;

                    else
                        _okButton.Text = Config.OkButtonText;

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

            if (_okButton != null)
                _okButton.Click += OkButton_Click;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            if (_okButton != null)
                _okButton.Click -= OkButton_Click;
        }
        #endregion

        #region Constructors
        public AlertAppCompatDialogFragment()
            : base()
        {
        }

        public AlertAppCompatDialogFragment(IAlertConfig config)
            : base(config)
        {
        }

        public AlertAppCompatDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion
    }
}