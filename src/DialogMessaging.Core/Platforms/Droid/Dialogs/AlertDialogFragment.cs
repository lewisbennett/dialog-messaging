using Android.App;
using Android.Runtime;
using Android.Views;
using DialogMessaging.Core.Platforms.Droid.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public class AlertDialogFragment : AbstractDialogFragment<IAlertConfig>
    {
        #region Event Handlers
        public override void OnRegisteredViewClick(string dialogElement, View view)
        {
            base.OnRegisteredViewClick(dialogElement, view);

            switch (dialogElement)
            {
                case DialogElement.ButtonPrimary:
                    Config.OkButtonClickAction?.Invoke();
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

                    if (string.IsNullOrWhiteSpace(Config.OkButtonText) || !viewConfig.View.TrySetText(Config.OkButtonText))
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

            builder.SetPositiveButton(Config.OkButtonText, (s, e) => Config.OkButtonClickAction?.Invoke());
        }
        #endregion

        #region Constructors
        public AlertDialogFragment()
            : base()
        {
        }

        public AlertDialogFragment(IAlertConfig config)
            : base(config)
        {
        }

        public AlertDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion
    }
}
