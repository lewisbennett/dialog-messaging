using DialogMessaging.Core.Base;
using DialogMessaging.Core.Platforms.iOS;
using DialogMessaging.Core.Platforms.iOS.Attributes;
using DialogMessaging.Core.Platforms.iOS.Infrastructure;
using DialogMessaging.Core.Platforms.Shared.Infrastructure;
using DialogMessaging.Interactions;
using DialogMessaging.Interactions.Base;
using Foundation;
using System;
using System.Reflection;
using UIKit;

namespace DialogMessaging
{
    public class IosMessagingService : BaseMessagingService
    {
        #region Public Methods
        /// <summary>
        /// Builds the <see cref="UIView" /> for a custom dialog configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        public virtual UIView BuildCustomDialog<TConfig>(TConfig config)
            where TConfig : IBaseDialogConfig
        {
            if (config.CustomViewType == null)
                throw new InvalidOperationException("Cannot build custom dialog UIView. CustomViewType is null.");

            UIView view = null;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                // If the provided type has a DialogViewAttribute, and a NIB name is available, load the view using the app's main NSBundle.
                if (config.CustomViewType.GetCustomAttribute<DialogViewAttribute>() is DialogViewAttribute dialogViewAttribute && !string.IsNullOrWhiteSpace(dialogViewAttribute.NibName))
                    view = NSBundle.MainBundle.LoadNib(dialogViewAttribute.NibName, null, null).GetItem<UIView>(0);

                // Otherwise, use the Activator to create the view.
                else
                    view = (UIView)Activator.CreateInstance(config.CustomViewType);

                if (view == null)
                    throw new Exception($"Failed to construct custom dialog view of type {config.CustomViewType.FullName}");

                // Apply the dialog configuration.
                if (view is ICustomDialog<TConfig> customDialog)
                    customDialog.ApplyDialogConfig(config);

                else
                    throw new Exception($"Custom view type ({config.CustomViewType.FullName}) does not inherit ICustomDialog.");

                // Apply the app's full window bounds to the view and re-layout.
                view.Frame = UIApplication.SharedApplication.KeyWindow.Bounds;
                view.LayoutIfNeeded();
            });

            return view;
        }

        /// <summary>
        /// Shows a custom dialog.
        /// </summary>
        /// <param name="view">The custom dialog UIView. Must inherit <see cref="ICustomDialog{TConfig}" />.</param>
        public IDisposable ShowCustomDialog<TConfig>(UIView view)
            where TConfig : IBaseDialogConfig
        {
            if (view is not ICustomDialog<TConfig> customDialog)
                throw new Exception($"Custom view type ({view.GetType().FullName}) does not inherit ICustomDialog.");

            void showView()
            {
                UIApplication.SharedApplication.KeyWindow.AddSubview(view);

                customDialog.Show();
            }

            void dismissAndShow(UIView existingView)
            {
                existingView.RemoveFromSuperview();

                showView();
            }

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                var existingView = UIApplication.SharedApplication.KeyWindow.ViewWithTag(view.Tag);

                // Try to dismiss the existing custom dialog gracefully.
                if (existingView is ICustomDialog<TConfig> existingCustomDialog)
                    existingCustomDialog.Dismiss(() => dismissAndShow(existingView));

                // Dismiss existing view.
                else if (existingView != null)
                    dismissAndShow(existingView);

                else
                    showView();
            });

            return new DisposableAction(() => UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => customDialog.Dismiss(() => view.RemoveFromSuperview())));
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Presents an action sheet based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentActionSheet<TActionSheetItemConfig>(IActionSheetConfig<TActionSheetItemConfig> config)
        {
            if (config.CustomViewType != null)
                return ShowCustomDialog<IActionSheetConfig<TActionSheetItemConfig>>(BuildCustomDialog(config));

            UIAlertController actionSheet = null;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                actionSheet = UIAlertController.Create(config.Title, config.Message, UIAlertControllerStyle.Alert);

                // Add cancel button, if configured.
                if (!string.IsNullOrWhiteSpace(config.CancelButtonText))
                {
                    actionSheet.AddAction(UIAlertAction.Create(config.CancelButtonText, UIAlertActionStyle.Cancel, (action) =>
                    {
                        config.CancelButtonClickAction?.Invoke();
                        config.DismissedAction?.Invoke();
                    }));
                }

                // Add the items, if configured.
                foreach (var item in config.Items)
                {
                    if (!string.IsNullOrWhiteSpace(item.Message))
                    {
                        actionSheet.AddAction(UIAlertAction.Create(item.Message, UIAlertActionStyle.Default, (action) =>
                        {
                            item.ClickAction?.Invoke();

                            config.ItemClickAction?.Invoke(item);
                            config.DismissedAction?.Invoke();
                        }));
                    }
                }

                // Present the action sheet.
                UIApplication.SharedApplication.GetTopViewController().PresentViewController(actionSheet, true, null);
            });

            return new DisposableAction(() => UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => actionSheet.DismissViewController(true, null)));
        }

        /// <summary>
        /// Presents a bottom action sheet based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentActionSheetBottom<TActionSheetItemConfig>(IActionSheetConfig<TActionSheetItemConfig> config)
        {
            // iPad's don't like bottom based action sheets, so use a normal action sheet instead.
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                return PresentActionSheet(config);

            if (config.CustomViewType != null)
                return ShowCustomDialog<IActionSheetConfig<TActionSheetItemConfig>>(BuildCustomDialog(config));

            UIAlertController actionSheet = null;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                actionSheet = UIAlertController.Create(config.Title, config.Message, UIAlertControllerStyle.ActionSheet);

                // Add cancel button, if configured.
                if (!string.IsNullOrWhiteSpace(config.CancelButtonText))
                {
                    actionSheet.AddAction(UIAlertAction.Create(config.CancelButtonText, UIAlertActionStyle.Cancel, (action) =>
                    {
                        config.CancelButtonClickAction?.Invoke();
                        config.DismissedAction?.Invoke();
                    }));
                }

                // Add the items, if configured.
                foreach (var item in config.Items)
                {
                    if (!string.IsNullOrWhiteSpace(item.Message))
                    {
                        actionSheet.AddAction(UIAlertAction.Create(item.Message, UIAlertActionStyle.Default, (action) =>
                        {
                            item.ClickAction?.Invoke();

                            config.ItemClickAction?.Invoke(item);
                            config.DismissedAction?.Invoke();
                        }));
                    }
                }

                // Present the action sheet.
                UIApplication.SharedApplication.GetTopViewController().PresentViewController(actionSheet, true, null);
            });

            return new DisposableAction(() => UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => actionSheet.DismissViewController(true, null)));
        }

        /// <summary>
        /// Presents an alert dialog based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentAlert(IAlertConfig config)
        {
            if (config.CustomViewType != null)
                return ShowCustomDialog<IAlertConfig>(BuildCustomDialog(config));

            UIAlertController alert = null;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                alert = UIAlertController.Create(config.Title, config.Message, UIAlertControllerStyle.Alert);

                // Add the OK button, if configured.
                if (!string.IsNullOrWhiteSpace(config.OkButtonText))
                {
                    alert.AddAction(UIAlertAction.Create(config.OkButtonText, UIAlertActionStyle.Default, (action) =>
                    {
                        config.OkButtonClickAction?.Invoke();
                        config.DismissedAction?.Invoke();
                    }));
                }

                // Present the alert.
                UIApplication.SharedApplication.GetTopViewController().PresentViewController(alert, true, null);
            });

            return new DisposableAction(() => UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => alert.DismissViewController(true, null)));
        }

        /// <summary>
        /// Presents a confirm dialog based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentConfirm(IConfirmConfig config)
        {
            if (config.CustomViewType != null)
                return ShowCustomDialog<IConfirmConfig>(BuildCustomDialog(config));

            UIAlertController confirm = null;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                confirm = UIAlertController.Create(config.Title, config.Message, UIAlertControllerStyle.Alert);

                // Add the confirm button, if configured.
                if (!string.IsNullOrWhiteSpace(config.ConfirmButtonText))
                {
                    confirm.AddAction(UIAlertAction.Create(config.ConfirmButtonText, UIAlertActionStyle.Default, (action) =>
                    {
                        config.ConfirmButtonClickAction?.Invoke();
                        config.DismissedAction?.Invoke();
                    }));
                }

                // Add the cancel button, if configured.
                if (!string.IsNullOrWhiteSpace(config.CancelButtonText))
                {
                    confirm.AddAction(UIAlertAction.Create(config.CancelButtonText, UIAlertActionStyle.Cancel, (action) =>
                    {
                        config.CancelButtonClickAction?.Invoke();
                        config.DismissedAction?.Invoke();
                    }));
                }

                // Present the alert.
                UIApplication.SharedApplication.GetTopViewController().PresentViewController(confirm, true, null);
            });

            return new DisposableAction(() => UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => confirm.DismissViewController(true, null)));
        }

        /// <summary>
        /// Presents a delete dialog based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentDelete(IDeleteConfig config)
        {
            if (config.CustomViewType != null)
                return ShowCustomDialog<IDeleteConfig>(BuildCustomDialog(config));

            UIAlertController delete = null;

            UIDevice.CurrentDevice.SafeInvokeOnMainThread(() =>
            {
                delete = UIAlertController.Create(config.Title, config.Message, UIAlertControllerStyle.Alert);

                // Add the delete button, if configured.
                if (!string.IsNullOrWhiteSpace(config.DeleteButtonText))
                {
                    delete.AddAction(UIAlertAction.Create(config.DeleteButtonText, UIAlertActionStyle.Destructive, (action) =>
                    {
                        config.DeleteButtonClickAction?.Invoke();
                        config.DismissedAction?.Invoke();
                    }));
                }

                // Add the cancel button, if configured.
                if (!string.IsNullOrWhiteSpace(config.CancelButtonText))
                {
                    delete.AddAction(UIAlertAction.Create(config.CancelButtonText, UIAlertActionStyle.Cancel, (action) =>
                    {
                        config.CancelButtonClickAction?.Invoke();
                        config.DismissedAction?.Invoke();
                    }));
                }

                // Present the alert.
                UIApplication.SharedApplication.GetTopViewController().PresentViewController(delete, true, null);
            });

            return new DisposableAction(() => UIDevice.CurrentDevice.SafeInvokeOnMainThread(() => delete.DismissViewController(true, null)));
        }

        /// <summary>
        /// Presents a loading dialog based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentLoading(ILoadingConfig config)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Presents a login dialog based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentLogin(ILoginConfig config)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Presents a prompt dialog based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override IDisposable PresentPrompt(IPromptConfig config)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Presents a snackbar based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override void PresentSnackbar(ISnackbarConfig config)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Presents an toast based on the provided configuration.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        protected override void PresentToast(IToastConfig config)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
