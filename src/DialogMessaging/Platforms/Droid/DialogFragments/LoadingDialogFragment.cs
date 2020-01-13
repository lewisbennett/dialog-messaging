using Android.App;
using Android.Runtime;
using Android.Views;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;
using System.Collections.Generic;

namespace DialogMessaging.Platforms.Droid.DialogFragments
{
    public class LoadingDialogFragment : AbstractDialogFragment<ILoadingConfig>
    {
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

            base.AssignValue(dialogElement);
        }

        /// <summary>
        /// Assigns configuration values to the dialog builder.
        /// </summary>
        public override void CreateDialog(AlertDialog.Builder builder)
        {
            var layoutId = Config.Progress == null ? Resource.Layout.dialog_default_loading_indeterminate : Resource.Layout.dialog_default_loading_determinate;

            var view = new CustomLayoutInflater(Context, this).Inflate(layoutId, null, false);

            if (view != null)
                builder.SetView(view);
        }
        #endregion

        #region Constructors
        public LoadingDialogFragment()
            : base()
        {
        }

        public LoadingDialogFragment(ILoadingConfig config)
            : base(config)
        {
        }

        public LoadingDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion
    }
}
