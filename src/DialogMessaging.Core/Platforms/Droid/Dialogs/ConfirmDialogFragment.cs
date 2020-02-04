using Android.App;
using Android.Runtime;
using Android.Views;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public class ConfirmDialogFragment : AbstractDialogFragment<IConfirmConfig>
    {
        #region Event Handlers
        public override void OnRegisteredViewClick(string dialogElement, View view)
        {
            switch (dialogElement)
            {
                case DialogElement.ButtonPrimary:
                    Config.ConfirmButtonClickAction?.Invoke();
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

            builder.SetPositiveButton(Config.ConfirmButtonText, (s, e) => OnRegisteredViewClick(DialogElement.ButtonPrimary, s as View));
            builder.SetNegativeButton(Config.CancelButtonText, (s, e) => OnRegisteredViewClick(DialogElement.ButtonSecondary, s as View));
        }
        #endregion

        #region Constructors
        public ConfirmDialogFragment()
            : base()
        {
        }

        public ConfirmDialogFragment(IConfirmConfig config)
            : base(config)
        {
        }

        public ConfirmDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion
    }
}
