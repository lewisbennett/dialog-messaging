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
using DialogMessaging.Interactions.Base;
using DialogMessaging.Schema;
using Google.Android.Material.BottomSheet;
using Google.Android.Material.Snackbar;
using System;
using System.Linq;
using Android_Toast = Android.Widget.Toast;
using Material_Snackbar = Google.Android.Material.Snackbar.Snackbar;

namespace DialogMessaging.Core.Platforms.Droid
{
    public class DroidMessagingService : BaseMessagingService
    {
        #region Public Methods
        /// <summary>
        ///     Shows a dialog.
        /// </summary>
        /// <param name="dialog">The dialog to show.</param>
        /// <param name="config">The dialog configuration.</param>
        public virtual IDisposable ShowDialog(AppCompatDialogFragment dialog, IBaseDialogConfig config)
        {
            if (MessagingServiceCore.ActivityLifecycleCallbacks.CurrentActivity is AppCompatActivity appCompatActivity)
            {
                var fragmentTag = Guid.NewGuid().ToString();

                appCompatActivity.SafeRunOnUIThread(() => dialog.Show(appCompatActivity.SupportFragmentManager, fragmentTag));

                return new DisposableAction(() => FindAndDismissDialog(fragmentTag));
            }

            return null;
        }
        #endregion

        #region Protected Methods
        /// <summary>
        ///     Constructs the internal bottom action sheet dialog.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected virtual BottomSheetDialogFragment ConstructActionSheetBottomDialog<TActionSheetItemConfig>(IActionSheetBottomConfig<TActionSheetItemConfig> config)
            where TActionSheetItemConfig : IActionSheetItemConfig
        {
            return new ActionSheetBottomSheetDialogFragment<TActionSheetItemConfig>(config);
        }

        /// <summary>
        ///     Constructs the internal action sheet dialog.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected virtual AppCompatDialogFragment ConstructActionSheetDialog<TActionSheetItemConfig>(IActionSheetConfig<TActionSheetItemConfig> config)
            where TActionSheetItemConfig : IActionSheetItemConfig
        {
            return new ActionSheetAppCompatDialogFragment<TActionSheetItemConfig>(config);
        }

        /// <summary>
        ///     Constructs the internal alert dialog.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected virtual AppCompatDialogFragment ConstructAlertDialog(IAlertConfig config)
        {
            return new AlertAppCompatDialogFragment(config);
        }

        /// <summary>
        ///     Constructs the internal confirm dialog.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected virtual AppCompatDialogFragment ConstructConfirmDialog(IConfirmConfig config)
        {
            return new ConfirmAppCompatDialogFragment(config);
        }

        /// <summary>
        ///     Constructs the internal delete dialog.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected virtual AppCompatDialogFragment ConstructDeleteDialog(IDeleteConfig config)
        {
            return new DeleteAppCompatDialogFragment(config);
        }

        /// <summary>
        ///     Constructs the internal loading dialog.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected virtual AppCompatDialogFragment ConstructLoadingDialog(ILoadingConfig config)
        {
            return new LoadingAppCompatDialogFragment(config);
        }

        /// <summary>
        ///     Constructs the internal login dialog.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected virtual AppCompatDialogFragment ConstructLoginDialog(ILoginConfig config)
        {
            return new LoginAppCompatDialogFragment(config);
        }

        /// <summary>
        ///     Constructs the internal prompt dialog.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected virtual AppCompatDialogFragment ConstructPromptDialog(IPromptConfig config)
        {
            return new PromptAppCompatDialogFragment(config);
        }

        /// <summary>
        ///     Constructs the internal snackbar.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected virtual Material_Snackbar ConstructSnackbar(AppCompatActivity appCompatActivity, ISnackbarConfig config)
        {
            var snackbar = Material_Snackbar.Make(FindSnackbarContainerView(appCompatActivity), config.Message, config.Duration ?? BaseTransientBottomBar.LengthLong);

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

        /// <summary>
        ///     Finds the view best suited to contain a Snackbar, within the view hierarchy of an Activity.
        /// </summary>
        /// <param name="appCompatActivity">The Activity to look for the view within.</param>
        protected virtual View FindSnackbarContainerView(AppCompatActivity appCompatActivity)
        {
            if (MessagingServiceCore.ViewManager.SnackbarContainers.TryGetValue(appCompatActivity, out View snackbarContainer))
                return snackbarContainer;

            return appCompatActivity.Window.DecorView.Find(v => v is CoordinatorLayout).FirstOrDefault() ?? appCompatActivity.Window.DecorView;
        }

        /// <summary>
        ///     Presents an action sheet based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentActionSheet<TActionSheetItemConfig>(IActionSheetConfig<TActionSheetItemConfig> config)
        {
            return ShowDialog(ConstructActionSheetDialog(config), config);
        }

        /// <summary>
        ///     Presents a bottom action sheet based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentActionSheetBottom<TActionSheetItemConfig>(IActionSheetBottomConfig<TActionSheetItemConfig> config)
        {
            return ShowDialog(ConstructActionSheetBottomDialog(config), config);
        }

        /// <summary>
        ///     Presents an alert dialog based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentAlert(IAlertConfig config)
        {
            return ShowDialog(ConstructAlertDialog(config), config);
        }

        /// <summary>
        ///     Presents a confirm dialog based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentConfirm(IConfirmConfig config)
        {
            return ShowDialog(ConstructConfirmDialog(config), config);
        }

        /// <summary>
        ///     Presents a delete dialog based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentDelete(IDeleteConfig config)
        {
            return ShowDialog(ConstructDeleteDialog(config), config);
        }

        /// <summary>
        ///     Presents a loading dialog based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentLoading(ILoadingConfig config)
        {
            return ShowDialog(ConstructLoadingDialog(config), config);
        }

        /// <summary>
        ///     Presents a login dialog based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentLogin(ILoginConfig config)
        {
            return ShowDialog(ConstructLoginDialog(config), config);
        }

        /// <summary>
        ///     Presents a prompt dialog based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentPrompt(IPromptConfig config)
        {
            return ShowDialog(ConstructPromptDialog(config), config);
        }

        /// <summary>
        ///     Presents a snackbar based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override void PresentSnackbar(ISnackbarConfig config)
        {
            if (MessagingServiceCore.ActivityLifecycleCallbacks.CurrentActivity is AppCompatActivity appCompatActivity)
            {
                appCompatActivity.SafeRunOnUIThread(() =>
                {
                    using var snackbar = ConstructSnackbar(appCompatActivity, config);

                    snackbar.Show();
                });
            }
        }

        /// <summary>
        ///     Presents an toast based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override void PresentToast(IToastConfig config)
        {
            if (MessagingServiceCore.ActivityLifecycleCallbacks.CurrentActivity is AppCompatActivity appCompatActivity)
            {
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
        }
        #endregion

        #region Private Methods
        /// <summary>
        ///     Finds an <see cref="AppCompatDialogFragment" /> from within the current Activity and dismisses it, if available.
        /// </summary>
        /// <param name="dialogFragmentTag"></param>
        private void FindAndDismissDialog(string dialogFragmentTag)
        {
            if (MessagingServiceCore.ActivityLifecycleCallbacks.CurrentActivity is AppCompatActivity appCompatActivity)
            {
                appCompatActivity.SafeRunOnUIThread(() =>
                {
                    if (appCompatActivity.SupportFragmentManager.FindFragmentByTag(dialogFragmentTag) is AppCompatDialogFragment dialog)
                        dialog.Dismiss();
                });
            }
        }
        #endregion

        #region Constant Values
        public const string FragmentTag = "dialog_messaging_dialog_fragment";
        #endregion
    }
}