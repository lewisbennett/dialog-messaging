using Android.Content.Res;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.CoordinatorLayout.Widget;
using DialogMessaging.Core.Base;
using DialogMessaging.Core.Platforms.Droid.Dialogs;
using DialogMessaging.Core.Platforms.Shared.Infrastructure;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Schema;
using Google.Android.Material.BottomSheet;
using System;
using System.Linq;
using Android_Toast = Android.Widget.Toast;
using Material_Snackbar = Google.Android.Material.Snackbar.Snackbar;

namespace DialogMessaging.Core.Platforms.Droid
{
    public class DroidMessagingService : BaseMessagingService
    {
        #region Public Methods
        public IDisposable ShowDialog(AppCompatDialogFragment dialog)
        {
            if (MessagingServiceCore.ActivityLifecycleCallbacks.CurrentActivity is AppCompatActivity appCompatActivity)
            {
                appCompatActivity.SafeRunOnUIThread(() => dialog.Show(appCompatActivity.SupportFragmentManager, FragmentTag));

                return new DisposableAction(() => appCompatActivity.SafeRunOnUIThread(dialog.Dismiss));
            }

            return null;
        }
        #endregion

        #region Protected Methods
        protected virtual BottomSheetDialogFragment ConstructActionSheetBottomDialog<TActionSheetItemConfig>(IActionSheetBottomConfig<TActionSheetItemConfig> config)
            where TActionSheetItemConfig : IActionSheetItemConfig
        {
            return new ActionSheetBottomSheetDialogFragment<TActionSheetItemConfig>(config);
        }

        protected virtual AppCompatDialogFragment ConstructActionSheetDialog<TActionSheetItemConfig>(IActionSheetConfig<TActionSheetItemConfig> config)
            where TActionSheetItemConfig : IActionSheetItemConfig
        {
            return new ActionSheetAppCompatDialogFragment<TActionSheetItemConfig>(config);
        }

        protected virtual AppCompatDialogFragment ConstructAlertDialog(IAlertConfig config)
        {
            return new AlertAppCompatDialogFragment(config);
        }

        protected virtual AppCompatDialogFragment ConstructConfirmDialog(IConfirmConfig config)
        {
            return new ConfirmAppCompatDialogFragment(config);
        }

        protected virtual AppCompatDialogFragment ConstructDeleteDialog(IDeleteConfig config)
        {
            return new DeleteAppCompatDialogFragment(config);
        }

        protected virtual AppCompatDialogFragment ConstructLoadingDialog(ILoadingConfig config)
        {
            return new LoadingAppCompatDialogFragment(config);
        }

        protected virtual AppCompatDialogFragment ConstructLoginDialog(ILoginConfig config)
        {
            return new LoginAppCompatDialogFragment(config);
        }

        protected virtual AppCompatDialogFragment ConstructPromptDialog(IPromptConfig config)
        {
            return new PromptAppCompatDialogFragment(config);
        }

        protected virtual Material_Snackbar ConstructSnackbar(AppCompatActivity appCompatActivity, ISnackbarConfig config)
        {
            var snackbar = Material_Snackbar.Make(FindSnackbarContainerView(appCompatActivity), config.Message, config.Duration);

            // Configure the animation mode, if provided.
            if (config.AnimationMode.HasValue)
                snackbar.SetAnimationMode(config.AnimationMode.Value);

            // Configure the anchor view, if available.
            if (config.AnchorView == null)
            {
                if (MessagingServiceCore.ViewManager.SnackbarAnchorViews.TryGetValue(appCompatActivity, out View snackbarAnchorView))
                    snackbar.SetAnchorView(snackbarAnchorView);
            }
            else
                snackbar.SetAnchorView(config.AnchorView);

            // Configure the background, if provided.
            if (config.BackgroundColor.HasValue)
            {
                // Without this, setting the background tint removes rounded corners.
                snackbar.View.BackgroundTintMode = PorterDuff.Mode.SrcAtop;

                snackbar.View.BackgroundTintList = ColorStateList.ValueOf(config.BackgroundColor.Value);
            }

            // Configure the Snackbar action, if any.
            if (!string.IsNullOrWhiteSpace(config.ActionButtonText))
            {
                snackbar = snackbar.SetAction(config.ActionButtonText, (view) => config.ActionButtonClickAction?.Invoke());

                if (config.ActionButtonTextColor.HasValue)
                    snackbar = snackbar.SetActionTextColor(config.ActionButtonTextColor.Value);
            }

            // Find the Snackbar action TextView and configure it, if avaialble.
            if (snackbar.View.FindViewById<TextView>(Resource.Id.snackbar_action) is TextView snackbarActionTextView)
            {
                if (config.ActionButtonTypeface != null)
                    snackbarActionTextView.SetTypeface(config.ActionButtonTypeface, config.ActionButtonTypefaceStyle);
            }

            // Find the Snackbar message TextView and configure it, if available.
            if (snackbar.View.FindViewById<TextView>(Resource.Id.snackbar_text) is TextView snackbarMessageTextView)
            {
                if (config.MessageTextColor.HasValue)
                    snackbarMessageTextView.SetTextColor(config.MessageTextColor.Value);

                if (config.MessageTypeface != null)
                    snackbarMessageTextView.SetTypeface(config.MessageTypeface, config.MessageTypefaceStyle);
            }

            return snackbar;
        }

        protected virtual View FindSnackbarContainerView(AppCompatActivity appCompatActivity)
        {
            if (MessagingServiceCore.ViewManager.SnackbarContainers.TryGetValue(appCompatActivity, out View snackbarContainer))
                return snackbarContainer;

            return appCompatActivity.Window.DecorView.Find(v => v is CoordinatorLayout).FirstOrDefault() ?? appCompatActivity.Window.DecorView;
        }

        protected override IDisposable PresentActionSheet<TActionSheetItemConfig>(IActionSheetConfig<TActionSheetItemConfig> config)
        {
            return ShowDialog(ConstructActionSheetDialog(config));
        }

        protected override IDisposable PresentActionSheetBottom<TActionSheetItemConfig>(IActionSheetBottomConfig<TActionSheetItemConfig> config)
        {
            return ShowDialog(ConstructActionSheetBottomDialog(config));
        }

        protected override IDisposable PresentAlert(IAlertConfig config)
        {
            return ShowDialog(ConstructAlertDialog(config));
        }

        protected override IDisposable PresentConfirm(IConfirmConfig config)
        {
            return ShowDialog(ConstructConfirmDialog(config));
        }

        protected override IDisposable PresentDelete(IDeleteConfig config)
        {
            return ShowDialog(ConstructDeleteDialog(config));
        }

        protected override IDisposable PresentLoading(ILoadingConfig config)
        {
            return ShowDialog(ConstructLoadingDialog(config));
        }

        protected override IDisposable PresentLogin(ILoginConfig config)
        {
            return ShowDialog(ConstructLoginDialog(config));
        }

        protected override IDisposable PresentPrompt(IPromptConfig config)
        {
            return ShowDialog(ConstructPromptDialog(config));
        }

        protected override void PresentSnackbar(ISnackbarConfig config)
        {
            if (!(MessagingServiceCore.ActivityLifecycleCallbacks.CurrentActivity is AppCompatActivity appCompatActivity))
                return;

            appCompatActivity.SafeRunOnUIThread(() =>
            {
                using var snackbar = ConstructSnackbar(appCompatActivity, config);

                snackbar.Show();
            });
        }

        protected override void PresentToast(IToastConfig config)
        {
            if (!(MessagingServiceCore.ActivityLifecycleCallbacks.CurrentActivity is AppCompatActivity appCompatActivity))
                return;

            appCompatActivity.SafeRunOnUIThread(() =>
            {
                var toast = Android_Toast.MakeText(MessagingServiceCore.ActivityLifecycleCallbacks.CurrentActivity, config.Message, config.Duration);

                // If a layout resource ID has been provided, create the view with the view manager.
                if (config.LayoutResID.HasValue)
                {
                    // Inflate the custom Toast view and configure any subviews.
                    toast.View = MessagingServiceCore.ViewManager.InflateView(config.LayoutResID.Value, null, false, (view, dialogElement, autoHide) =>
                    {
                        switch (view, dialogElement)
                        {
                            case (TextView textView, DialogElement.Message):

                                if (string.IsNullOrWhiteSpace(config.Message) && autoHide)
                                    textView.Visibility = ViewStates.Gone;
                                else
                                    textView.Text = config.Message;

                                return;

                            default:
                                return;
                        }
                    });
                }

                toast.Show();
            });
        }
        #endregion

        #region Constant Values
        public const string FragmentTag = "dialog_messaging_dialog_fragment";
        #endregion
    }
}
