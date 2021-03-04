﻿using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using DialogMessaging.Core.Platforms.Droid.Dialogs.Base;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using System;
using System.ComponentModel;

namespace DialogMessaging.Core.Platforms.Droid.Dialogs
{
    public class LoadingAppCompatDialogFragment : BaseAppCompatDialogFragment<ILoadingConfig>
    {
        #region Fields
        private ProgressBar _determinateProgress, _indeterminateProgress;
        #endregion

        #region Event Handlers
        private void Config_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Config.Progress):
                    SetProgress();
                    return;

                default:
                    return;
            }
        }
        #endregion

        #region Protected Methods
        protected override void ConfigureDialogBuilder(AlertDialog.Builder builder)
        {
            base.ConfigureDialogBuilder(builder);

            if (MessagingServiceCore.ViewManager.InflateView(Resource.Layout.dialog_default_loading, null, false, ConfigureView) is View view)
                builder.SetView(view);
        }

        protected override void ConfigureView(View view, string dialogElement, bool autoHide)
        {
            base.ConfigureView(view, dialogElement, autoHide);

            switch (view, dialogElement)
            {
                case (ProgressBar progressBar, DialogElement.ProgressDeterminate):

                    _determinateProgress = progressBar;

                    _determinateProgress.Min = 0;
                    _determinateProgress.Max = 100;

                    SetProgress();

                    Config.PropertyChanged += Config_PropertyChanged;

                    return;

                case (ProgressBar progressBar, DialogElement.ProgressIndeterminate):

                    _indeterminateProgress = progressBar;

                    SetProgress();

                    return;

                default:
                    return;
            }
        }
        #endregion

        #region Lifecycle
        public override void OnDestroy()
        {
            base.OnDestroy();

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
            // If progress has a value, and the determinate progress bar is available, set the progress.
            if (Config.Progress.HasValue)
            {
                if (_determinateProgress != null)
                {
                    if (_determinateProgress.Visibility != ViewStates.Visible)
                        _determinateProgress.Visibility = ViewStates.Visible;

                    _determinateProgress.Progress = Config.Progress.Value;
                }

                if (_indeterminateProgress != null)
                    _indeterminateProgress.Visibility = ViewStates.Gone;
            }
            // Otherwise, show the indeterminate progress bar, if available.
            else
            {
                if (_indeterminateProgress != null && _indeterminateProgress.Visibility != ViewStates.Visible)
                    _indeterminateProgress.Visibility = ViewStates.Visible;

                if (_determinateProgress != null)
                    _determinateProgress.Visibility = ViewStates.Gone;
            }
        }
        #endregion
    }
}