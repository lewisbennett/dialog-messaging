using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;
using System.Collections.Generic;

namespace DialogMessaging.Platforms.Droid.DialogFragments
{
    public class ConfirmAppCompatDialogFragment : AbstractAppCompatDialogFragment<IConfirmConfig>
    {
        #region Event Handlers
        public override void OnRegisteredViewClick(string dialogElement, View view)
        {
            if (dialogElement.Equals(DialogElement.ButtonPrimary))
                Config.ConfirmButtonClickAction?.Invoke();

            if (dialogElement.Equals(DialogElement.ButtonSecondary))
                Config.CancelButtonClickAction?.Invoke();

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
            if (dialogElement.Key.Equals(DialogElement.Title))
            {
                if (!string.IsNullOrWhiteSpace(Config.Title) && dialogElement.Value.Item1.TrySetText(Config.Title))
                    return;

                dialogElement.HideElementIfNeeded();

                return;
            }

            if (dialogElement.Key.Equals(DialogElement.ButtonPrimary))
            {
                if (!string.IsNullOrWhiteSpace(Config.ConfirmButtonText) && dialogElement.Value.Item1.TrySetText(Config.ConfirmButtonText))
                {
                    RegisterForClickEvents(dialogElement.Key, dialogElement.Value.Item1);
                    return;
                }

                dialogElement.HideElementIfNeeded();

                return;
            }

            if (dialogElement.Key.Equals(DialogElement.ButtonSecondary))
            {
                if (!string.IsNullOrWhiteSpace(Config.CancelButtonText) && dialogElement.Value.Item1.TrySetText(Config.CancelButtonText))
                {
                    RegisterForClickEvents(dialogElement.Key, dialogElement.Value.Item1);
                    return;
                }

                dialogElement.HideElementIfNeeded();

                return;
            }

            base.AssignValue(dialogElement);
        }

        /// <summary>
        /// Assigns configuration values to the dialog builder.
        /// </summary>
        public override void CreateDialog(AlertDialog.Builder builder)
        {
            base.CreateDialog(builder);

            builder.SetTitle(Config.Title);
            builder.SetPositiveButton(Config.ConfirmButtonText, (s, e) => Config.ConfirmButtonClickAction?.Invoke());
            builder.SetNegativeButton(Config.CancelButtonText, (s, e) => Config.CancelButtonClickAction?.Invoke());
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
}
