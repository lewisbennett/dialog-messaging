using Android.App;
using Android.Support.V7.App;
using Android.Views;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Platforms.Droid.Dialogs;
using System;

namespace DialogMessaging.Platforms.Droid
{
    public class MessagingServiceImpl : AbstractMessagingService
    {
        #region Fields
        private IDisposable _loadingDialog;
        #endregion

        #region Public Methods
        /// <summary>
        /// Displays an alert to the user.
        /// </summary>
        /// <param name="config">The alert configuration.</param>
        public override IDisposable Alert(IAlertConfig config)
        {
            return ShowDialog<AlertDialogFragment, AlertAppCompatDialogFragment>(config);
        }

        /// <summary>
        /// Displays a confirm dialog to the user.
        /// </summary>
        /// <param name="config">The confirm configuration.</param>
        public override IDisposable Confirm(IConfirmConfig config)
        {
            return ShowDialog<ConfirmDialogFragment, ConfirmAppCompatDialogFragment>(config);
        }

        /// <summary>
        /// Displays a delete dialog to the user.
        /// </summary>
        /// <param name="config">The delete configuration.</param>
        public override IDisposable Delete(IDeleteConfig config)
        {
            return ShowDialog<DeleteDialogFragment, DeleteAppCompatDialogFragment>(config);
        }

        /// <summary>
        /// Hides the loading wheel from the user, if visible.
        /// </summary>
        public override void HideLoading()
        {
            if (_loadingDialog != null)
                _loadingDialog.Dispose();
        }

        /// <summary>
        /// Displays a loading wheel to the user.
        /// </summary>
        /// <param name="config">The loading configuration.</param>
        public override IDisposable ShowLoading(ILoadingConfig config)
        {
            _loadingDialog = ShowDialog<LoadingDialogFragment, LoadingAppCompatDialogFragment>(config);

            return _loadingDialog;
        }

        /// <summary>
        /// Displays a toast to the user.
        /// </summary>
        /// <param name="config">The toast configuration.</param>
        public override void Toast(IToastConfig config)
        {
            var activity = ActivityLifecycleCallbacks.CurrentActivity;

            if (activity == null)
            {
                Log.Error("Toast", "Could not display toast - current activity is null.");
                return;
            }

            activity.SafeRunOnUiThread(() =>
            {
                using var toast = Android.Widget.Toast.MakeText(activity, config.Message, config.Duration);

                if (config.LayoutID != null)
                {
                    var view = LayoutInflater.From(activity).Inflate((int)config.LayoutID, null, false);

                    if (view == null)
                        Log.Error("Toast", "Could not display toast - custom layout was null after inflating.");
                    else
                        toast.View = view;
                }

                toast.Show();
            });
        }
        #endregion

        #region Private Methods
        private IDisposable ShowDialog<TDialog, TAppCompatDialog>(IBaseConfig config)
            where TDialog : AbstractDialogFragment
            where TAppCompatDialog : AbstractAppCompatDialogFragment
        {
            var activity = ActivityLifecycleCallbacks.CurrentActivity;

            if (activity is AppCompatActivity appCompatActivity)
                return ShowDialog<TAppCompatDialog>(appCompatActivity, config);
            
            return ShowDialog<TDialog>(activity, config);
        }

        private IDisposable ShowDialog<TDialog>(Activity activity, IBaseConfig config)
            where TDialog : AbstractDialogFragment
        {
            var dialog = (TDialog)Activator.CreateInstance(typeof(TDialog), config);

            activity.SafeRunOnUiThread(() =>
            {
                dialog.Show(activity.FragmentManager, FragmentTag);
            });

            return new DisposableAction(() => activity.SafeRunOnUiThread(dialog.Dismiss));
        }

        private IDisposable ShowDialog<TDialog>(AppCompatActivity activity, IBaseConfig config)
            where TDialog : AbstractAppCompatDialogFragment
        {
            var dialog = (TDialog)Activator.CreateInstance(typeof(TDialog), config);

            activity.SafeRunOnUiThread(() =>
            {
                dialog.Show(activity.SupportFragmentManager, FragmentTag);
            });

            return new DisposableAction(() => activity.SafeRunOnUiThread(dialog.Dismiss));
        }
        #endregion

        #region Constant Values
        public const string FragmentTag = "DialogMessaging";
        #endregion
    }
}
