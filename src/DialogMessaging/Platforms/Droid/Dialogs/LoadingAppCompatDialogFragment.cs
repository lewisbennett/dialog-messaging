﻿using Android.Runtime;
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
        private View _determinateProgressView;
        private View _indeterminateProgressView;
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
            switch (dialogElement.Key)
            {
                case DialogElement.ProgressDeterminate:

                    _determinateProgressView = dialogElement.Value.Item1;
                    SetProgress();

                    return;

                case DialogElement.ProgressIndeterminate:

                    _indeterminateProgressView = dialogElement.Value.Item1;
                    SetProgress();

                    return;

                default:
                    base.AssignValue(dialogElement);
                    return;
            }
        }

        /// <summary>
        /// Assigns configuration values to the dialog builder.
        /// </summary>
        public override void CreateDialog(AlertDialog.Builder builder)
        {
            var view = new CustomLayoutInflater(Context, this).Inflate(Resource.Layout.dialog_default_loading, null, false);

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
            var determinateProgress = _determinateProgressView as ProgressBar;
            var indeterminateProgress = _indeterminateProgressView as ProgressBar;

            if (Config.Progress == null)
            {
                if (determinateProgress != null)
                    determinateProgress.Visibility = ViewStates.Gone;

                if (indeterminateProgress != null)
                    indeterminateProgress.Visibility = ViewStates.Visible;

                return;
            }

            if (determinateProgress != null)
            {
                if (determinateProgress.Max != 100)
                    determinateProgress.Max = 100;

                if (determinateProgress.Min != 0)
                    determinateProgress.Min = 0;

                determinateProgress.Visibility = ViewStates.Visible;
                determinateProgress.Progress = (int)Config.Progress;
            }

            if (indeterminateProgress != null)
                indeterminateProgress.Visibility = ViewStates.Gone;
        }
        #endregion
    }
}
