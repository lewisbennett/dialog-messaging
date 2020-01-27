﻿using DialogMessaging.Attributes;
using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Platforms.iOS.Alerts;
using DialogMessaging.Platforms.iOS.Infrastructure;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIKit;

namespace DialogMessaging.Platforms.iOS
{
    public class MessagingServiceImpl : AbstractMessagingService
    {
        #region Internal Methods
        internal override IDisposable PresentActionSheet(IActionSheetConfig config)
        {
            UIAlertController alert = null;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                var alert = UIAlertController.Create(config.Title, config.Message, UIAlertControllerStyle.Alert);

                foreach (var item in config.Items)
                {
                    alert.AddAction(UIAlertAction.Create(item.Text, UIAlertActionStyle.Default, (a) =>
                    {
                        item.ClickAction?.Invoke();
                        config.ItemClickAction?.Invoke(item);
                        config.DismissedAction?.Invoke();
                    }));
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

        internal override IDisposable PresentActionSheetBottom(IActionSheetBottomConfig config)
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                var actionSheetConfig = new ActionSheetConfig
                {
                    CancelButtonClickAction = config.CancelButtonClickAction,
                    CancelButtonText = config.CancelButtonText,
                    Data = config.Data,
                    DismissedAction = config.CancelButtonClickAction,
                    ItemClickAction = config.ItemClickAction,
                    Items = config.Items,
                    Message = config.Message,
                    Title = config.Title
                };

                return PresentActionSheet(actionSheetConfig);
            }

            UIAlertController alert = null;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                var alert = UIAlertController.Create(config.Title, config.Message, UIAlertControllerStyle.ActionSheet);

                foreach (var item in config.Items)
                {
                    alert.AddAction(UIAlertAction.Create(item.Text, UIAlertActionStyle.Default, (a) =>
                    {
                        item.ClickAction?.Invoke();
                        config.ItemClickAction?.Invoke(item);
                        config.DismissedAction?.Invoke();
                    }));
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
            UIAlertView alert = null;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                alert = new UIAlertView
                {
                    Title = config.Title,
                    Message = config.Message,
                    AlertViewStyle = UIAlertViewStyle.PlainTextInput
                };

                var textField = alert.GetTextField(0);

                textField.Placeholder = config.Hint;
                textField.ApplyInputType(config.InputType);

                var actions = new Dictionary<nint, Action>();

                if (!string.IsNullOrWhiteSpace(config.CancelButtonText))
                {
                    var index = alert.AddButton(config.CancelButtonText);
                    actions.Add(index, config.CancelButtonClickAction);
                }

                if (!string.IsNullOrWhiteSpace(config.ConfirmButtonText))
                {
                    var index = alert.AddButton(config.ConfirmButtonText);

                    actions.Add(index, () =>
                    {
                        config.InputText = textField.Text;
                        config.ConfirmButtonClickAction?.Invoke(config.InputText);
                    });
                }

                alert.Clicked += (s, e) =>
                {
                    actions[e.ButtonIndex]?.Invoke();
                    config.DismissedAction?.Invoke();
                };

                alert.Show();
            });

            return new DisposableAction(() => UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => alert.DismissWithClickedButtonIndex(0, true)));
        }

        internal override IDisposable PresentLoading(ILoadingConfig config)
        {
            var loadingView = BuildCustomAlert(config.ViewType ?? typeof(DefaultLoadingAlert), config);

            if (loadingView == null)
                return null;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                var keyWindow = UIApplication.SharedApplication.KeyWindow;

                void showNewAlert()
                {
                    keyWindow.AddSubview(loadingView);
                    loadingView.FadeIn(0.2f);
                }

                var existingView = keyWindow.ViewWithTag(loadingView.Tag);

                if (existingView != null)
                {
                    Loading = null;
                    existingView.FadeOut(0.2f, finishedAction: showNewAlert);

                    return;
                }

                showNewAlert();
            });

            return new DisposableAction(() => UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => loadingView.FadeOut(0.2f, finishedAction: () => loadingView?.RemoveFromSuperview())));
        }

        internal override async void PresentSnackbar(ISnackbarConfig config)
        {
            var snackbarView = BuildCustomAlert(typeof(DefaultSnackbar), config);

            if (!(snackbarView is IShowable snackbarShowable))
                return;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                var existingView = UIApplication.SharedApplication.KeyWindow.ViewWithTag(snackbarView.Tag);

                if (existingView is IShowable existingShowable)
                {
                    existingShowable.Hide(() => snackbarShowable.Show());
                    return;
                }

                snackbarShowable.Show();
            });

            await Task.Delay(config.Duration ?? TimeSpan.FromSeconds(3)).ConfigureAwait(false);

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => snackbarShowable.Hide());
        }

        internal override async void PresentToast(IToastConfig config)
        {
            var toastView = BuildCustomAlert(config.ViewType ?? typeof(DefaultToast), config);

            if (!(toastView is IShowable toastShowable))
                return;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                var existingView = UIApplication.SharedApplication.KeyWindow.ViewWithTag(toastView.Tag);

                if (existingView is IShowable existingShowable)
                {
                    existingShowable.Hide(() => toastShowable.Show());
                    return;
                }

                toastShowable.Show();
            });

            await Task.Delay(config.Duration ?? TimeSpan.FromSeconds(2.5)).ConfigureAwait(false);

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => toastShowable.Hide());
        }
        #endregion

        #region Private Methods
        private UIView BuildCustomAlert(Type type, object config)
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
                    return;

                view.Frame = UIApplication.SharedApplication.KeyWindow.Bounds;
                view.LayoutIfNeeded();

                if (view is IValueAssigner valueAssigner)
                    valueAssigner.AssignValues(config);
            });

            return view;
        }
        #endregion
    }
}
