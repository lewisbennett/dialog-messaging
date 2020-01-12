using Android.App;
using Android.Support.V7.App;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Platforms.Droid.DialogFragments;
using System;

namespace DialogMessaging.Platforms.Droid
{
    public class MessagingServiceImpl : AbstractMessagingService
    {
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

            return new DisposableAction(() =>
            {
                activity.SafeRunOnUiThread(dialog.Dismiss);
            });
        }

        private IDisposable ShowDialog<TDialog>(AppCompatActivity activity, IBaseConfig config)
            where TDialog : AbstractAppCompatDialogFragment
        {
            var dialog = (TDialog)Activator.CreateInstance(typeof(TDialog), config);

            activity.SafeRunOnUiThread(() =>
            {
                dialog.Show(activity.SupportFragmentManager, FragmentTag);
            });

            return new DisposableAction(() =>
            {
                activity.SafeRunOnUiThread(dialog.Dismiss);
            });
        }
        #endregion

        #region Constant Values
        public const string FragmentTag = "DialogMessaging";
        #endregion
    }
}
