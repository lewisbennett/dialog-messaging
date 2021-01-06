using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.CoordinatorLayout.Widget;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Platforms.Droid.Dialogs;
using System;
using System.Linq;
using Material_Snackbar = Google.Android.Material.Snackbar.Snackbar;

namespace DialogMessaging.Platforms.Droid
{
    public class MessagingServiceImpl : AbstractMessagingService
    {
        #region Internal Methods
        internal override IDisposable PresentActionSheet(IActionSheetConfig config)
        {
            return ShowDialog<ActionSheetAppCompatDialogFragment>(config);
        }

        internal override IDisposable PresentActionSheetBottom(IActionSheetBottomConfig config)
        {
            if (!(ActivityLifecycleCallbacks.CurrentActivity is AppCompatActivity appCompatActivity))
                return null;

            var dialog = new ActionSheetBottomBottomSheetDialogFragment(config);

            appCompatActivity.SafeRunOnUiThread(() => dialog.Show(appCompatActivity.SupportFragmentManager, FragmentTag));

            return new DisposableAction(() => appCompatActivity.SafeRunOnUiThread(dialog.Dismiss));
        }

        internal override IDisposable PresentAlert(IAlertConfig config)
        {
            return ShowDialog<AlertAppCompatDialogFragment>(config);
        }

        internal override IDisposable PresentConfirm(IConfirmConfig config)
        {
            return ShowDialog<ConfirmAppCompatDialogFragment>(config);
        }

        internal override IDisposable PresentDelete(IDeleteConfig config)
        {
            return ShowDialog<DeleteAppCompatDialogFragment>(config);
        }

        internal override IDisposable PresentLogin(ILoginConfig config)
        {
            return ShowDialog<LoginAppCompatDialogFragment>(config);
        }

        internal override IDisposable PresentPrompt(IPromptConfig config)
        {
            return ShowDialog<PromptAppCompatDialogFragment>(config);
        }

        internal override IDisposable PresentLoading(ILoadingConfig config)
        {
            return ShowDialog<LoadingAppCompatDialogFragment>(config);
        }

        internal override void PresentSnackbar(ISnackbarConfig config)
        {
            if (!(ActivityLifecycleCallbacks.CurrentActivity is AppCompatActivity appCompatActivity))
            {
                Log.Error("Snackbar", "Could not display snackbar - current activity is not AppCompatActivity.");
                return;
            }

            appCompatActivity.SafeRunOnUiThread(() =>
            {
                // Get the Snackbar container for the current context or try and find a CoordinatorLayout in the view stack. Default to the DecorView if not available.
                if (!ActivityLifecycleCallbacks.SnackbarContainers.TryGetValue(appCompatActivity, out View snackbarContainer))
                    snackbarContainer = appCompatActivity.Window.DecorView.Find((v) => v is CoordinatorLayout).FirstOrDefault() ?? appCompatActivity.Window.DecorView;

                using var snackbar = Material_Snackbar.Make(snackbarContainer, config.Message, config.Duration);

                snackbar.ApplyStyling(config);

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
