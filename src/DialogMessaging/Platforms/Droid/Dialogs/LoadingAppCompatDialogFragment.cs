using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DialogMessaging.Platforms.Droid.Dialogs
{
    public class LoadingAppCompatDialogFragment : AbstractAppCompatDialogFragment<ILoadingConfig>
    {
        #region Fields
        private View _progressView;
        #endregion

        #region Event Handlers
        private void Config_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(ILoadingConfig.Progress)))
                SetProgress();
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

            if (dialogElement.Key.Equals(DialogElement.Progress))
            {
                _progressView = dialogElement.Value.Item1;
                SetProgress();

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

        #region Lifecycle
        public override void OnResume()
        {
            base.OnResume();

            Config.PropertyChanged += Config_PropertyChanged;
        }

        public override void OnPause()
        {
            base.OnPause();

            Config.PropertyChanged -= Config_PropertyChanged;
        }
        #endregion

        #region Constructors
        public LoadingAppCompatDialogFragment()
            : base()
        {
        }

        public LoadingAppCompatDialogFragment(ILoadingConfig config)
            : base(config)
        {
        }

        public LoadingAppCompatDialogFragment(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
        #endregion

        #region Private Methods
        private void SetProgress()
        {
            if (!(_progressView is ProgressBar progressBar) || Config.Progress == null)
                return;

            if (progressBar.Max != 100)
                progressBar.Max = 100;

            if (progressBar.Min != 0)
                progressBar.Min = 0;

            progressBar.Progress = (int)Config.Progress;
        }
        #endregion
    }
}
