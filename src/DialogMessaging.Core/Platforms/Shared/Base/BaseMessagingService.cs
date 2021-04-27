using DialogMessaging.Infrastructure;
using DialogMessaging.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DialogMessaging.Core.Base
{
    public abstract class BaseMessagingService : IMessagingService
    {
        #region Fields
        private readonly Dictionary<ILoadingConfig, IDisposable> _loadingDialogs = new();
        #endregion

        #region Public Methods
        /// <summary>
        /// Display an action sheet dialog asynchronously.
        /// </summary>
        /// <param name="config">The action sheet configuration.</param>
        public IDisposable ActionSheet(ActionSheetConfig config)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate == null || MessagingServiceCore.Delegate.OnActionSheetRequested(config))
                return PresentActionSheet(config);

            return null;
        }

        /// <summary>
        /// Display an action sheet dialog asynchronously.
        /// </summary>
        /// <param name="config">The action sheet configuration.</param>
        public Task<ActionSheetItemAsyncConfig> ActionSheetAsync(ActionSheetAsyncConfig config, CancellationToken cancellationToken = default)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate != null && !MessagingServiceCore.Delegate.OnActionSheetRequested(config))
                return Task.FromResult<ActionSheetItemAsyncConfig>(null);

            var task = new TaskCompletionSource<ActionSheetItemAsyncConfig>();

            // Configure actions to complete the task.
            config.CancelButtonClickAction = () => task.TrySetResult(null);
            config.DismissedAction = () => task.TrySetResult(null);
            config.ItemClickAction = (item) => task.TrySetResult(item);

            var dialog = PresentActionSheet(config);

            // Register the disposable of the dialog with the cancellation token, then return the task.
            using (cancellationToken.Register(() => dialog?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Display an action sheet dialog from the bottom of the screen.
        /// </summary>
        /// <param name="config">The action sheet configuration.</param>
        public IDisposable ActionSheetBottom(ActionSheetBottomConfig config)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate == null || MessagingServiceCore.Delegate.OnActionSheetBottomRequested(config))
                return PresentActionSheetBottom(config);

            return null;
        }

        /// <summary>
        /// Display an action sheet dialog from the bottom of the screen asynchronously.
        /// </summary>
        /// <param name="config">The action sheet configuration.</param>
        public Task<ActionSheetItemAsyncConfig> ActionSheetBottomAsync(ActionSheetBottomAsyncConfig config, CancellationToken cancellationToken = default)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate != null && !MessagingServiceCore.Delegate.OnActionSheetBottomRequested(config))
                return Task.FromResult<ActionSheetItemAsyncConfig>(null);

            var task = new TaskCompletionSource<ActionSheetItemAsyncConfig>();

            // Configure actions to complete the task.
            config.CancelButtonClickAction = () => task.TrySetResult(null);
            config.DismissedAction = () => task.TrySetResult(null);
            config.ItemClickAction = (item) => task.TrySetResult(item);

            var dialog = PresentActionSheetBottom(config);

            // Register the disposable of the dialog with the cancellation token, then return the task.
            using (cancellationToken.Register(() => dialog?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Display an alert dialog.
        /// </summary>
        public virtual IDisposable Alert(AlertConfig config)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate == null || MessagingServiceCore.Delegate.OnAlertRequested(config))
                return PresentAlert(config);

            return null;
        }

        /// <summary>
        ///  Display an alert dialog asynchronously.
        /// </summary>
        public virtual Task<bool> AlertAsync(AlertAsyncConfig config, CancellationToken cancellationToken = default)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate != null && !MessagingServiceCore.Delegate.OnAlertRequested(config))
                return Task.FromResult(false);

            var task = new TaskCompletionSource<bool>();

            // Configure actions to complete the task.
            config.DismissedAction = () => task.TrySetResult(false);
            config.OkButtonClickAction = () => task.TrySetResult(true);

            var dialog = PresentAlert(config);

            // Register the disposable of the dialog with the cancellation token, then return the task.
            using (cancellationToken.Register(() => dialog?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Display a confirm dialog.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        public virtual IDisposable Confirm(ConfirmConfig config)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate == null || MessagingServiceCore.Delegate.OnConfirmRequested(config))
                return PresentConfirm(config);

            return null;
        }

        /// <summary>
        /// Display a confirm dialog asynchronously.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        public virtual Task<bool> ConfirmAsync(ConfirmAsyncConfig config, CancellationToken cancellationToken = default)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate != null && !MessagingServiceCore.Delegate.OnConfirmRequested(config))
                return Task.FromResult(false);

            var task = new TaskCompletionSource<bool>();

            // Configure actions to complete the task.
            config.CancelButtonClickAction = () => task.TrySetResult(false);
            config.ConfirmButtonClickAction = () => task.TrySetResult(true);
            config.DismissedAction = () => task.TrySetResult(false);

            var dialog = PresentConfirm(config);

            // Register the disposable of the dialog with the cancellation token, then return the task.
            using (cancellationToken.Register(() => dialog?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Display a delete dialog.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        public virtual IDisposable Delete(DeleteConfig config)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate == null || MessagingServiceCore.Delegate.OnDeleteRequested(config))
                return PresentDelete(config);

            return null;
        }

        /// <summary>
        /// Display a delete dialog asynchronously.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        public Task<bool> DeleteAsync(DeleteAsyncConfig config, CancellationToken cancellationToken = default)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate != null && !MessagingServiceCore.Delegate.OnDeleteRequested(config))
                return Task.FromResult(false);

            var task = new TaskCompletionSource<bool>();

            // Configure actions to complete the task.
            config.CancelButtonClickAction = () => task.TrySetResult(false);
            config.DeleteButtonClickAction = () => task.TrySetResult(true);
            config.DismissedAction = () => task.TrySetResult(false);

            var dialog = PresentDelete(config);

            // Register the disposable of the dialog with the cancellation token, then return the task.
            using (cancellationToken.Register(() => dialog?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Hide a loading dialog.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        public virtual void HideLoading(ILoadingConfig config)
        {
            if (_loadingDialogs.TryGetValue(config, out IDisposable dialog))
                dialog.Dispose();
        }

        /// <summary>
        /// Display a login dialog.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        public virtual IDisposable Login(LoginConfig config)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate == null || MessagingServiceCore.Delegate.OnLoginRequested(config))
                return PresentLogin(config);

            return null;
        }

        /// <summary>
        /// Display a login dialog asynchronously.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        public virtual Task<(string, string)> LoginAsync(LoginAsyncConfig config, CancellationToken cancellationToken = default)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate != null && !MessagingServiceCore.Delegate.OnLoginRequested(config))
                return Task.FromResult<(string, string)>((null, null));

            var task = new TaskCompletionSource<(string, string)>();

            // Configure actions to complete the task.
            config.CancelButtonClickAction = () => task.TrySetResult((null, null));
            config.DismissedAction = () => task.TrySetResult((null, null));
            config.LoginButtonClickAction = (enteredUsername, enteredPassword) => task.TrySetResult((enteredUsername, enteredPassword));

            var dialog = PresentLogin(config);

            // Register the disposable of the dialog with the cancellation token, then return the task.
            using (cancellationToken.Register(() => dialog?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Display a prompt dialog.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        public virtual IDisposable Prompt(PromptConfig config)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate == null || MessagingServiceCore.Delegate.OnPromptRequested(config))
                return PresentPrompt(config);

            return null;
        }

        /// <summary>
        /// Display a prompt dialog asynchronously.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        public virtual Task<string> PromptAsync(PromptAsyncConfig config, CancellationToken cancellationToken = default)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate != null && !MessagingServiceCore.Delegate.OnPromptRequested(config))
                return Task.FromResult<string>(null);

            var task = new TaskCompletionSource<string>();

            // Configure actions to complete the task.
            config.CancelButtonClickAction = () => task.TrySetResult(null);
            config.ConfirmButtonClickAction = (enteredText) => task.TrySetResult(enteredText);
            config.DismissedAction = () => task.TrySetResult(null);

            var dialog = PresentPrompt(config);

            // Register the disposable of the dialog with the cancellation token, then return the task.
            using (cancellationToken.Register(() => dialog?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Display a loading dialog.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        public virtual IDisposable ShowLoading(LoadingConfig config)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate == null || MessagingServiceCore.Delegate.OnLoadingRequested(config))
            {
                var dialog = PresentLoading(config);

                _loadingDialogs[config] = dialog;

                return dialog;
            }

            return null;
        }

        /// <summary>
        /// Display a loading dialog asynchronously.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        public virtual async Task ShowLoadingAsync(LoadingAsyncConfig config, Task task, CancellationToken cancellationToken = default)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate != null && !MessagingServiceCore.Delegate.OnLoadingRequested(config))
                return;

            // Register the disposable of the dialog with the cancellation token, then return the task.
            using (cancellationToken.Register(() => HideLoading(config)))
            {
                var dialog = _loadingDialogs[config] = PresentLoading(config);

                // Add a minimum delay to avoid the loading dialog getting stuck visible in the event of the task completing too quickly.
                await Task.WhenAll(task, Task.Delay(500)).ContinueWith((_) => HideLoading(config), cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Display a loading dialog asynchronously.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        public virtual async Task<T> ShowLoadingAsync<T>(LoadingAsyncConfig config, Task<T> task, CancellationToken cancellationToken = default)
        {
            // If available, call the delegate to see if presenting this dialog is allowed.
            if (MessagingServiceCore.Delegate != null && !MessagingServiceCore.Delegate.OnLoadingRequested(config))
                return default;

            await ((IMessagingService)this).ShowLoadingAsync(config, (Task)task, cancellationToken).ConfigureAwait(false);

            return task.Result;
        }

        /// <summary>
        /// Display a Snackbar.
        /// </summary>
        /// <param name="config">The Snackbar configuration.</param>
        public virtual void Snackbar(SnackbarConfig config)
        {
            // If available, call the delegate to see if presenting this Snackbar is allowed.
            if (MessagingServiceCore.Delegate == null || MessagingServiceCore.Delegate.OnSnackbarRequested(config))
                PresentSnackbar(config);
        }

        /// <summary>
        /// Display a Toast.
        /// </summary>
        /// <param name="config">The Toast configuration.</param>
        public virtual void Toast(ToastConfig config)
        {
            // If available, call the delegate to see if presenting this Snackbar is allowed.
            if (MessagingServiceCore.Delegate == null || MessagingServiceCore.Delegate.OnToastRequested(config))
                PresentToast(config);
        }
        #endregion

        #region Protected Methods
        protected abstract IDisposable PresentActionSheet<TActionSheetItemConfig>(IActionSheetConfig<TActionSheetItemConfig> config)
            where TActionSheetItemConfig : IActionSheetItemConfig;

        protected abstract IDisposable PresentActionSheetBottom<TActionSheetItemConfig>(IActionSheetBottomConfig<TActionSheetItemConfig> config)
            where TActionSheetItemConfig : IActionSheetItemConfig;

        protected abstract IDisposable PresentAlert(IAlertConfig config);

        protected abstract IDisposable PresentConfirm(IConfirmConfig config);

        protected abstract IDisposable PresentDelete(IDeleteConfig config);

        protected abstract IDisposable PresentLoading(ILoadingConfig config);

        protected abstract IDisposable PresentLogin(ILoginConfig config);

        protected abstract IDisposable PresentPrompt(IPromptConfig config);

        protected abstract void PresentSnackbar(ISnackbarConfig config);

        protected abstract void PresentToast(IToastConfig config);
        #endregion
    }
}
