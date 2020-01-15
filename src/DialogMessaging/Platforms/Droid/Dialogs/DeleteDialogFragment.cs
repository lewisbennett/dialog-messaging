﻿using Android.App;
using Android.Runtime;
using Android.Views;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;
using System.Collections.Generic;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public class DeleteDialogFragment : AbstractDialogFragment<IDeleteConfig>
    {
        #region Event Handlers
        public override void OnRegisteredViewClick(string dialogElement, View view)
        {
            switch (dialogElement)
            {
                case DialogElement.ButtonPrimary:
                    Config.DeleteButtonClickAction?.Invoke();
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
                case DialogElement.ButtonPrimary:

                    if (!string.IsNullOrWhiteSpace(Config.DeleteButtonText) && dialogElement.Value.Item1.TrySetText(Config.DeleteButtonText))
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

            builder.SetPositiveButton(Config.DeleteButtonText, (s, e) => OnRegisteredViewClick(DialogElement.ButtonPrimary, s as View));
            builder.SetNegativeButton(Config.CancelButtonText, (s, e) => OnRegisteredViewClick(DialogElement.ButtonSecondary, s as View));
        }
        #endregion

        #region Constructors
        public DeleteDialogFragment()
            : base()
        {
        }

        public DeleteDialogFragment(IDeleteConfig config)
            : base(config)
        {
        }

        public DeleteDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion
    }
}
