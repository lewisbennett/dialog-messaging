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
            var activity = ActivityLifecycleCallbacks.CurrentActivity;

            if (activity is AppCompatActivity appCompatActivity)
                return ShowDialogFragment<AlertAppCompatDialogFragment>(appCompatActivity, config);

            return ShowDialogFragment<AlertDialogFragment>(activity, config);
        }
        #endregion

        #region Private Methods
        private IDisposable ShowDialogFragment<TDialog>(Activity activity, IBaseConfig config)
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

        private IDisposable ShowDialogFragment<TDialog>(AppCompatActivity activity, IBaseConfig config)
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
