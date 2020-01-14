using Android.Content;
using Android.Views;
using Android.Widget;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;
using System.Collections.Generic;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public class CustomToast : IValueAssigner
    {
        #region Properties
        /// <summary>
        /// Gets the config being used for the toast.
        /// </summary>
        public IToastConfig Config { get; }

        /// <summary>
        /// Gets the toast.
        /// </summary>
        public Toast Toast { get; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Assigns configuration values to UI elements.
        /// </summary>
        /// <param name="dialogElement">The dialog element extracted from the view.</param>
        public void AssignValue(KeyValuePair<string, Tuple<View, bool>> dialogElement)
        {
            if (!dialogElement.Key.Equals(DialogElement.Message) || !dialogElement.Value.Item1.TrySetText(Config.Message))
                dialogElement.HideElementIfNeeded();
        }

        /// <summary>
        /// Assigns configuration values to UI elements.
        /// </summary>
        /// <param name="dialogElements">The dialog elements that are attributed in the view.</param>
        public void AssignValues(IDictionary<string, Tuple<View, bool>> dialogElements)
        {
            if (dialogElements == null)
                return;

            foreach (var dialogElement in dialogElements)
                AssignValue(dialogElement);
        }
        #endregion

        #region Constructors
        public CustomToast(Context context, IToastConfig config)
        {
            Config = config;

            Toast = Toast.MakeText(context, config.Message, config.Duration);

            if (Config.LayoutID != null)
                Toast.View = new CustomLayoutInflater(context, this).Inflate((int)Config.LayoutID, null, false);
        }
        #endregion
    }
}
