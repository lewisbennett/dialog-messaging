using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;
using System.Collections.Generic;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public class AlertAppCompatDialogFragment : AbstractAppCompatDialogFragment<IAlertConfig>
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
        /// <param name="dialogElement">The dialog element extracted from the view.</param>
        public override void AssignValue(KeyValuePair<string, Tuple<View, bool>> dialogElement)
        {
            switch (dialogElement.Key)
            {
                case DialogElement.ButtonPrimary:

                    if (!string.IsNullOrWhiteSpace(Config.OkButtonText) && dialogElement.Value.Item1.TrySetText(Config.OkButtonText))
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

            builder.SetPositiveButton(Config.OkButtonText, (s, e) => OnRegisteredViewClick(DialogElement.ButtonPrimary, s as View));
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
