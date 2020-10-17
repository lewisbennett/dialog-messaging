using DialogMessaging.Attributes;
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
            if (config.ViewType != null)
                return ShowCustomAlert(BuildCustomAlert(config.ViewType, config));

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

            if (config.ViewType != null)
                return ShowCustomAlert(BuildCustomAlert(config.ViewType, config));

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
            if (config.ViewType != null)
                return ShowCustomAlert(BuildCustomAlert(config.ViewType, config));

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
            if (config.ViewType != null)
                return ShowCustomAlert(BuildCustomAlert(config.ViewType, config));

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
            if (config.ViewType != null)
                return ShowCustomAlert(BuildCustomAlert(config.ViewType, config));

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

        internal override IDisposable PresentLogin(ILoginConfig config)
        {
            if (config.ViewType != null)
                return ShowCustomAlert(BuildCustomAlert(config.ViewType, config));

            UIAlertView alert = null;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                alert = new UIAlertView
                {
                    Title = config.Title,
                    Message = config.Message,
                    AlertViewStyle = UIAlertViewStyle.LoginAndPasswordInput
                };

                var usernameTextField = alert.GetTextField(0);

                usernameTextField.Placeholder = config.UsernameHint;
                usernameTextField.ApplyInputType(config.UsernameInputType);

                var passwordTextField = alert.GetTextField(1);

                passwordTextField.Placeholder = config.PasswordHint;

                var actions = new Dictionary<nint, Action>();

                if (!string.IsNullOrWhiteSpace(config.CancelButtonText))
                {
                    var index = alert.AddButton(config.CancelButtonText);
                    actions.Add(index, config.CancelButtonClickAction);
                }

                if (!string.IsNullOrWhiteSpace(config.LoginButtonText))
                {
                    var index = alert.AddButton(config.LoginButtonText);

                    actions.Add(index, () =>
                    {
                        config.Username = usernameTextField.Text;
                        config.Password = passwordTextField.Text;

                        config.LoginButtonClickAction?.Invoke(config.Username, config.Password);
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

        internal override IDisposable PresentPrompt(IPromptConfig config)
        {
            if (config.ViewType != null)
                return ShowCustomAlert(BuildCustomAlert(config.ViewType, config));

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
            return ShowCustomAlert(BuildCustomAlert(config.ViewType ?? typeof(DefaultLoadingAlert), config));
        }

        internal override async void PresentSnackbar(ISnackbarConfig config)
        {
            var snackbarDisposable = ShowCustomAlert(BuildCustomAlert(typeof(DefaultSnackbar), config));

            await Task.Delay(config.Duration ?? TimeSpan.FromSeconds(3)).ConfigureAwait(false);

            snackbarDisposable?.Dispose();
        }

        internal override async void PresentToast(IToastConfig config)
        {
            var toastDisposable = ShowCustomAlert(BuildCustomAlert(config.ViewType ?? typeof(DefaultToast), config));

            await Task.Delay(config.Duration ?? TimeSpan.FromSeconds(2.5)).ConfigureAwait(false);

            toastDisposable?.Dispose();
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

        private IDisposable ShowCustomAlert(UIView view)
        {
            if (view == null || !(view is IShowable showable))
                return null;

            void show()
            {
                UIApplication.SharedApplication.KeyWindow.AddSubview(view);
                showable.Show();
            }

            void hideAndShow(UIView existingView)
            {
                existingView.RemoveFromSuperview();
                show();
            }

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                var keyWindow = UIApplication.SharedApplication.KeyWindow;

                var existingView = keyWindow.ViewWithTag(view.Tag);

                if (existingView is IShowable existingShowable)
                {
                    existingShowable.Dismiss(() => hideAndShow(existingView));
                    return;
                }
                else if (existingView != null)
                {
                    hideAndShow(existingView);
                    return;
                }

                show();
            });

            return new DisposableAction(() => UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => showable?.Dismiss(() => view?.RemoveFromSuperview())));
        }
        #endregion
    }
}
