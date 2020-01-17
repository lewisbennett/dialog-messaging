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
        #region Fields
        private IDisposable _loadingDialog;
        #endregion

        #region Public Methods
        /// <summary>
        /// Displays an action sheet to the user.
        /// </summary>
        /// <param name="config">The action sheet configuration.</param>
        public override IDisposable ActionSheet(IActionSheetConfig<IActionSheetItemConfig> config)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnActionSheetRequested(config);

            if (!proceed)
                return null;

            return ShowDialog<ActionSheetDialogFragment, ActionSheetAppCompatDialogFragment>(config);
        }

        /// <summary>
        /// Displays a bottom action sheet to the user.
        /// </summary>
        /// <param name="config">The bottom action sheet configuration.</param>
        public override IDisposable ActionSheetBottom(IActionSheetBottomConfig<IActionSheetItemConfig> config)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnActionSheetBottomRequested(config);

            if (!proceed)
                return null;

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
                    LayoutID = config.LayoutID,
                    Message = config.Message,
                    StyleID = config.StyleID,
                    Title = config.Title
                };

                foreach (var item in config.Items)
                    newConfig.Items.Add(item);

                return ActionSheet(newConfig);
            }

            var dialog = new ActionSheetBottomBottomSheetDialogFragment(config);

            appCompatActivity.SafeRunOnUiThread(() =>
            {
                dialog.Show(appCompatActivity.SupportFragmentManager, FragmentTag);
            });

            return new DisposableAction(() => activity.SafeRunOnUiThread(dialog.Dismiss));
        }

        /// <summary>
        /// Displays an alert to the user.
        /// </summary>
        /// <param name="config">The alert configuration.</param>
        public override IDisposable Alert(IAlertConfig config)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnAlertRequested(config);

            if (!proceed)
                return null;

            return ShowDialog<AlertDialogFragment, AlertAppCompatDialogFragment>(config);
        }

        /// <summary>
        /// Displays a confirm dialog to the user.
        /// </summary>
        /// <param name="config">The confirm configuration.</param>
        public override IDisposable Confirm(IConfirmConfig config)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnConfirmRequested(config);

            if (!proceed)
                return null;

            return ShowDialog<ConfirmDialogFragment, ConfirmAppCompatDialogFragment>(config);
        }

        /// <summary>
        /// Displays a delete dialog to the user.
        /// </summary>
        /// <param name="config">The delete configuration.</param>
        public override IDisposable Delete(IDeleteConfig config)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnDeleteRequested(config);

            if (!proceed)
                return null;

            return ShowDialog<DeleteDialogFragment, DeleteAppCompatDialogFragment>(config);
        }

        /// <summary>
        /// Hides the loading wheel from the user, if visible.
        /// </summary>
        public override void HideLoading()
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnHideLoadingRequested();

            if (!proceed)
                return;

            if (_loadingDialog != null)
                _loadingDialog.Dispose();
        }

        /// <summary>
        /// Displays a prompt to the user.
        /// </summary>
        /// <param name="config">The prompt configuration.</param>
        public override IDisposable Prompt(IPromptConfig config)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnPromptRequested(config);

            if (!proceed)
                return null;

            return ShowDialog<PromptDialogFragment, PromptAppCompatDialogFragment>(config);
        }

        /// <summary>
        /// Displays a loading wheel to the user.
        /// </summary>
        /// <param name="config">The loading configuration.</param>
        public override IDisposable ShowLoading(ILoadingConfig config)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnShowLoadingRequested(config);

            if (!proceed)
                return null;

            _loadingDialog = ShowDialog<LoadingDialogFragment, LoadingAppCompatDialogFragment>(config);

            return _loadingDialog;
        }

        /// <summary>
        /// Displays a snackbar to the user.
        /// </summary>
        /// <param name="config">The snackbar configuration.</param>
        public override void Snackbar(ISnackbarConfig config)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnSnackbarRequested(config);

            if (!proceed)
                return;

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

                snackbar.Show();
            });
        }

        /// <summary>
        /// Displays a toast to the user.
        /// </summary>
        /// <param name="config">The toast configuration.</param>
        public override void Toast(IToastConfig config)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnToastRequested(config);

            if (!proceed)
                return;

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
