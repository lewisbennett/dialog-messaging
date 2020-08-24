using AndroidX.AppCompat.App;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Platforms.Droid.Dialogs;
using System;
using Material_Snackbar = Google.Android.Material.Snackbar.Snackbar;

namespace DialogMessaging.Platforms.Droid
{
    public class MessagingServiceImpl : AbstractMessagingService
    {
        #region Internal Methods
        internal override IDisposable PresentActionSheet(IActionSheetConfig config)
            => ShowDialog<ActionSheetAppCompatDialogFragment>(config);

        internal override IDisposable PresentActionSheetBottom(IActionSheetBottomConfig config)
        {
            if (!(ActivityLifecycleCallbacks.CurrentActivity is AppCompatActivity appCompatActivity))
                return null;

            var dialog = new ActionSheetBottomBottomSheetDialogFragment(config);

            appCompatActivity.SafeRunOnUiThread(() => dialog.Show(appCompatActivity.SupportFragmentManager, FragmentTag));

            return new DisposableAction(() => appCompatActivity.SafeRunOnUiThread(dialog.Dismiss));
        }

        internal override IDisposable PresentAlert(IAlertConfig config)
            => ShowDialog<AlertAppCompatDialogFragment>(config);

        internal override IDisposable PresentConfirm(IConfirmConfig config)
            => ShowDialog<ConfirmAppCompatDialogFragment>(config);

        internal override IDisposable PresentDelete(IDeleteConfig config)
            => ShowDialog<DeleteAppCompatDialogFragment>(config);

        internal override IDisposable PresentLogin(ILoginConfig config)
            => ShowDialog<LoginAppCompatDialogFragment>(config);

        internal override IDisposable PresentPrompt(IPromptConfig config)
            => ShowDialog<PromptAppCompatDialogFragment>(config);

        internal override IDisposable PresentLoading(ILoadingConfig config)
            => ShowDialog<LoadingAppCompatDialogFragment>(config);

        internal override void PresentSnackbar(ISnackbarConfig config)
        {
            if (!(ActivityLifecycleCallbacks.CurrentActivity is AppCompatActivity appCompatActivity))
            {
                Log.Error("Snackbar", "Could not display snackbar - current activity is not AppCompatActivity.");
                return;
            }

            appCompatActivity.SafeRunOnUiThread(() =>
            {
                using var snackbar = Material_Snackbar.Make(appCompatActivity.Window.DecorView, config.Message, config.Duration);

                snackbar.ApplyStyling(config);
                snackbar.TrySetBottomMargin();

                snackbar.Show();
            });
        }

        internal override void PresentToast(IToastConfig config)
        {
            var activity = ActivityLifecycleCallbacks.CurrentActivity;

            if (!(ActivityLifecycleCallbacks.CurrentActivity is AppCompatActivity appCompatActivity))
            {
                Log.Error("Toast", "Could not display toast - current activity is not AppCompatActivity.");
                return;
            }

            activity.SafeRunOnUiThread(() =>
            {
                new CustomToast(activity, config).Toast.Show();
            });
        }
        #endregion

        #region Private Methods
        private IDisposable ShowDialog<TDialog>(IBaseConfig config)
            where TDialog : AbstractAppCompatDialogFragment
        {
            if (!(ActivityLifecycleCallbacks.CurrentActivity is AppCompatActivity appCompatActivity))
                return null;

            var dialog = (TDialog)Activator.CreateInstance(typeof(TDialog), config);

            appCompatActivity.SafeRunOnUiThread(() => dialog.Show(appCompatActivity.SupportFragmentManager, FragmentTag));

            return new DisposableAction(() => appCompatActivity.SafeRunOnUiThread(dialog.Dismiss));
        }
        #endregion

        #region Constant Values
        public const string FragmentTag = "DialogMessaging";
        #endregion
    }
}
