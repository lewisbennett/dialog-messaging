using DialogMessaging.Attributes;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Platforms.iOS.Alerts;
using Foundation;
using System;
using System.Linq;
using UIKit;

namespace DialogMessaging.Platforms.iOS
{
    public class MessagingServiceImpl : AbstractMessagingService
    {
        #region Fields
        private IDisposable _loadingAlert;
        #endregion

        #region Public Methods
        /// <summary>
        /// Displays an action sheet to the user.
        /// </summary>
        /// <param name="config">The action sheet configuration.</param>
        public override IDisposable ActionSheet(IActionSheetConfig config)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnActionSheetRequested(config);

            if (!proceed)
                return null;

            return null;
        }

        /// <summary>
        /// Displays a bottom action sheet to the user.
        /// </summary>
        /// <param name="config">The bottom action sheet configuration.</param>
        public override IDisposable ActionSheetBottom(IActionSheetBottomConfig config)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnActionSheetBottomRequested(config);

            if (!proceed)
                return null;

            return null;
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

            UIAlertController alert = null;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                var alert = UIAlertController.Create(config.Title, config.Message, UIAlertControllerStyle.Alert);

                if (!string.IsNullOrWhiteSpace(config.OkButtonText))
                {
                    alert.AddAction(UIAlertAction.Create(config.OkButtonText, UIAlertActionStyle.Default, (a) =>
                    {
                        config.OkButtonClickAction?.Invoke();
                        config.DismissedAction?.Invoke();
                    }));
                }

                UIApplication.SharedApplication.GetTopViewController().PresentViewController(alert, true, null);
            });

            return new DisposableAction(() => UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => alert?.DismissViewController(true, null)));
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

            UIAlertController alert = null;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                alert = UIAlertController.Create(config.Title, config.Message, UIAlertControllerStyle.Alert);

                if (!string.IsNullOrWhiteSpace(config.ConfirmButtonText))
                {
                    var action = UIAlertAction.Create(config.ConfirmButtonText, UIAlertActionStyle.Default, (a) =>
                    {
                        config.ConfirmButtonClickAction?.Invoke();
                        config.DismissedAction?.Invoke();
                    });

                    alert.AddAction(action);
                    alert.PreferredAction = action;
                }

                if (!string.IsNullOrWhiteSpace(config.CancelButtonText))
                {
                    alert.AddAction(UIAlertAction.Create(config.CancelButtonText, UIAlertActionStyle.Cancel, (a) =>
                    {
                        config.CancelButtonClickAction?.Invoke();
                        config.DismissedAction?.Invoke();
                    }));
                }
            });

            return new DisposableAction(() => UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => alert?.DismissViewController(true, null)));
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

            UIAlertController alert = null;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                alert = UIAlertController.Create(config.Title, config.Message, UIAlertControllerStyle.Alert);

                if (!string.IsNullOrWhiteSpace(config.DeleteButtonText))
                {
                    var action = UIAlertAction.Create(config.DeleteButtonText, UIAlertActionStyle.Destructive, (a) =>
                    {
                        config.DeleteButtonClickAction?.Invoke();
                        config.DismissedAction?.Invoke();
                    });

                    alert.AddAction(action);
                    alert.PreferredAction = action;
                }

                if (!string.IsNullOrWhiteSpace(config.CancelButtonText))
                {
                    alert.AddAction(UIAlertAction.Create(config.CancelButtonText, UIAlertActionStyle.Cancel, (a) =>
                    {
                        config.CancelButtonClickAction?.Invoke();
                        config.DismissedAction?.Invoke();
                    }));
                }
            });

            return new DisposableAction(() => UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => alert?.DismissViewController(true, null)));
        }

        /// <summary>
        /// Hides the loading wheel from the user, if visible.
        /// </summary>
        public override void HideLoading()
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnHideLoadingRequested();

            if (!proceed)
                return;

            _loadingAlert?.Dispose();
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

            return null;
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

            _loadingAlert = ShowAlert(config.ViewType ?? typeof(DefaultLoadingAlert), config);

            return _loadingAlert;
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
        }
        #endregion

        #region Private Methods
        private IDisposable ShowAlert(Type type, object config)
        {
            DialogViewAttribute dialogViewAttribute = null;

            var attributes = type.GetCustomAttributes(typeof(DialogViewAttribute), true);

            if (attributes != null && attributes.Length > 0)
                dialogViewAttribute = attributes.FirstOrDefault(a => a is DialogViewAttribute) as DialogViewAttribute;

            UIView view = null;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                if (dialogViewAttribute == null || string.IsNullOrWhiteSpace(dialogViewAttribute.NibName))
                    view = (UIView)Activator.CreateInstance(type);
                else
                    view = NSBundle.MainBundle.LoadNib(dialogViewAttribute.NibName, null, null).GetItem<UIView>(0);

                if (view == null)
                    throw new ArgumentNullException("view");

                var keyWindow = UIApplication.SharedApplication.KeyWindow;

                void showNewAlert()
                {
                    if (view is IValueAssigner valueAssigner)
                        valueAssigner.AssignValues(config);

                    keyWindow.AddSubview(view);
                    view.FadeIn(0.2f);
                }

                var existingView = keyWindow.ViewWithTag(view.Tag);

                if (existingView != null)
                {
                    _loadingAlert = null;
                    existingView.FadeOut(0.2f, finishedAction: showNewAlert);

                    return;
                }

                showNewAlert();
            });

            return new DisposableAction(() => UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => view.FadeOut(0.2f, finishedAction: () => view?.RemoveFromSuperview())));
        }
        #endregion
    }
}
