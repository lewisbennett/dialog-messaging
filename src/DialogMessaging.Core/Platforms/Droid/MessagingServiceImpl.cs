using Android.App;
using Android.Support.V7.App;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Platforms.Droid.Dialogs;
using System;

namespace DialogMessaging.Platforms.Droid
{
    public class MessagingServiceImpl : AbstractMessagingService
    {
        #region Internal Methods
        internal override IDisposable PresentActionSheet(IActionSheetConfig config)
        {
            return ShowDialog<ActionSheetDialogFragment, ActionSheetAppCompatDialogFragment>(config);
        }

        internal override IDisposable PresentActionSheetBottom(IActionSheetBottomConfig config)
        {
            var activity = ActivityLifecycleCallbacks.CurrentActivity;

            if (!(activity is AppCompatActivity appCompatActivity))
            {
                var newConfig = new ActionSheetConfig
                {
                    Cancelable = config.Cancelable,
                    CancelButtonClickAction = config.CancelButtonClickAction,
                    CancelButtonText = config.CancelButtonText,
                    Data = config.Data,
                    DismissedAction = config.DismissedAction,
                    ItemClickAction = config.ItemClickAction,
                    ItemLayoutResID = config.ItemLayoutResID,
                    Items = config.Items,
                    Message = config.Message,
                    Title = config.Title
                };

                return PresentActionSheet(newConfig);
            }

            var dialog = new ActionSheetBottomBottomSheetDialogFragment(config);

            appCompatActivity.SafeRunOnUiThread(() =>
            {
                dialog.Show(appCompatActivity.SupportFragmentManager, FragmentTag);
            });

            return new DisposableAction(() => activity.SafeRunOnUiThread(dialog.Dismiss));
        }

        internal override IDisposable PresentAlert(IAlertConfig config)
        {
            return ShowDialog<AlertDialogFragment, AlertAppCompatDialogFragment>(config);
        }

        internal override IDisposable PresentConfirm(IConfirmConfig config)
        {
            return ShowDialog<ConfirmDialogFragment, ConfirmAppCompatDialogFragment>(config);
        }

        internal override IDisposable PresentDelete(IDeleteConfig config)
        {
            return ShowDialog<DeleteDialogFragment, DeleteAppCompatDialogFragment>(config);
        }

        internal override IDisposable PresentPrompt(IPromptConfig config)
        {
            return ShowDialog<PromptDialogFragment, PromptAppCompatDialogFragment>(config);
        }

        internal override IDisposable PresentLoading(ILoadingConfig config)
        {
            return ShowDialog<LoadingDialogFragment, LoadingAppCompatDialogFragment>(config);
        }

        internal override void PresentSnackbar(ISnackbarConfig config)
        {
            var activity = ActivityLifecycleCallbacks.CurrentActivity;

            if (activity == null)
            {
                Log.Error("Toast", "Could not display snackbar - current activity is null.");
                return;
            }

            activity.SafeRunOnUiThread(() =>
            {
                using var snackbar = Android.Support.Design.Widget.Snackbar.Make(activity.Window.DecorView, config.Message, config.Duration);

                snackbar.ApplyStyling(config);
                snackbar.TrySetBottomMargin();

                snackbar.Show();
            });
        }

        internal override void PresentToast(IToastConfig config)
        {
            var activity = ActivityLifecycleCallbacks.CurrentActivity;

            if (activity == null)
            {
                Log.Error("Toast", "Could not display toast - current activity is null.");
                return;
            }

            activity.SafeRunOnUiThread(() =>
            {
                new CustomToast(activity, config).Toast.Show();
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
