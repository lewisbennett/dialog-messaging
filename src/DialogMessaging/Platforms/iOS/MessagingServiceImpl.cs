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
        #region Internal Methods
        internal override IDisposable PresentActionSheet(IActionSheetConfig config)
        {
            return null;
        }

        internal override IDisposable PresentActionSheetBottom(IActionSheetBottomConfig config)
        {
            return null;
        }

        internal override IDisposable PresentAlert(IAlertConfig config)
        {
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

        internal override IDisposable PresentConfirm(IConfirmConfig config)
        {
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

                UIApplication.SharedApplication.GetTopViewController().PresentViewController(alert, true, null);
            });

            return new DisposableAction(() => UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => alert?.DismissViewController(true, null)));
        }

        internal override IDisposable PresentDelete(IDeleteConfig config)
        {
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

                UIApplication.SharedApplication.GetTopViewController().PresentViewController(alert, true, null);
            });

            return new DisposableAction(() => UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => alert?.DismissViewController(true, null)));
        }

        internal override IDisposable PresentPrompt(IPromptConfig config)
        {
            return null;
        }

        internal override IDisposable PresentLoading(ILoadingConfig config)
        {
            return ShowAlert(config.ViewType ?? typeof(DefaultLoadingAlert), config);
        }

        internal override void PresentSnackbar(ISnackbarConfig config)
        {
        }

        internal override void PresentToast(IToastConfig config)
        {
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
                    Loading = null;
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
