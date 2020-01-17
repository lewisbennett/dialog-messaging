using DialogMessaging.Interactions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DialogMessaging
{
    public abstract class AbstractMessagingService : IMessagingService
    {
        #region Public Methods
        /// <summary>
        /// Displays an action sheet to the user.
        /// </summary>
        /// <param name="config">The action sheet configuration.</param>
        public abstract IDisposable ActionSheet(IActionSheetConfig config);

        /// <summary>
        /// Displays an action sheet to the user asynchronously.
        /// </summary>
        /// <param name="config">The action sheet configuration.</param>
        public Task<IActionSheetItemConfig> ActionSheetAsync(ActionSheetAsyncConfig config, CancellationToken cancellationToken = default)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnActionSheetRequested(config);

            if (!proceed)
                return Task.FromResult<IActionSheetItemConfig>(null);

            var task = new TaskCompletionSource<IActionSheetItemConfig>();

            config.ItemClickAction = (item) => task.TrySetResult(item);
            config.CancelButtonClickAction = () => task.TrySetResult(null);
            config.DismissedAction = () => task.TrySetResult(null);

            using (cancellationToken.Register(() => ActionSheet(config)?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Displays a bottom action sheet to the user.
        /// </summary>
        /// <param name="config">The bottom action sheet configuration.</param>
        public abstract IDisposable ActionSheetBottom(IActionSheetBottomConfig config);

        /// <summary>
        /// Displays a bottom action sheet to the user asynchronously.
        /// </summary>
        /// <param name="config">The bottom action sheet configuration.</param>
        public Task<IActionSheetItemConfig> ActionSheetBottomAsync(ActionSheetBottomAsyncConfig config, CancellationToken cancellationToken = default)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnActionSheetBottomRequested(config);

            if (!proceed)
                return Task.FromResult<IActionSheetItemConfig>(null);

            var task = new TaskCompletionSource<IActionSheetItemConfig>();

            config.ItemClickAction = (item) => task.TrySetResult(item);
            config.CancelButtonClickAction = () => task.TrySetResult(null);
            config.DismissedAction = () => task.TrySetResult(null);

            using (cancellationToken.Register(() => ActionSheetBottom(config)?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Displays an alert to the user.
        /// </summary>
        /// <param name="config">The alert configuration.</param>
        public abstract IDisposable Alert(IAlertConfig config);

        /// <summary>
        /// Displays an alert to the user asynchronously.
        /// </summary>
        /// <param name="config">The alert configuration.</param>
        public Task AlertAsync(AlertAsyncConfig config, CancellationToken cancellationToken = default)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnAlertRequested(config);

            if (!proceed)
                return Task.FromResult(false);

            var task = new TaskCompletionSource<bool>();

            config.OkButtonClickAction = () => task.TrySetResult(true);
            config.DismissedAction = () => task.TrySetResult(false);

            using (cancellationToken.Register(() => Alert(config)?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Displays a confirm dialog to the user.
        /// </summary>
        /// <param name="config">The confirm configuration.</param>
        public abstract IDisposable Confirm(IConfirmConfig config);

        /// <summary>
        /// Displays a confirm dialog to the user asynchronously.
        /// </summary>
        /// <param name="config">The delete configuration.</param>
        public Task<bool> ConfirmAsync(ConfirmAsyncConfig config, CancellationToken cancellationToken = default)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnConfirmRequested(config);

            if (!proceed)
                return Task.FromResult(false);

            var task = new TaskCompletionSource<bool>();

            config.ConfirmButtonClickAction = () => task.TrySetResult(true);
            config.CancelButtonClickAction = () => task.TrySetResult(false);
            config.DismissedAction = () => task.TrySetResult(false);

            using (cancellationToken.Register(() => Confirm(config)?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Displays a delete dialog to the user.
        /// </summary>
        /// <param name="config">The delete configuration.</param>
        public abstract IDisposable Delete(IDeleteConfig config);

        /// <summary>
        /// Displays a delete dialog to the user asynchronously.
        /// </summary>
        /// <param name="config">The delete configuration.</param>
        public Task<bool> DeleteAsync(DeleteAsyncConfig config, CancellationToken cancellationToken = default)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnDeleteRequested(config);

            if (!proceed)
                return Task.FromResult(false);

            var task = new TaskCompletionSource<bool>();

            config.DeleteButtonClickAction = () => task.TrySetResult(true);
            config.CancelButtonClickAction = () => task.TrySetResult(false);
            config.DismissedAction = () => task.TrySetResult(false);

            using (cancellationToken.Register(() => Delete(config)?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Hides the loading wheel from the user, if visible.
        /// </summary>
        public abstract void HideLoading();

        /// <summary>
        /// Displays a prompt to the user.
        /// </summary>
        /// <param name="config">The prompt configuration.</param>
        public abstract IDisposable Prompt(IPromptConfig config);

        /// <summary>
        /// Displays a prompt to the user.
        /// </summary>
        /// <param name="config">The prompt configuration.</param>
        public Task<string> PromptAsync(PromptAsyncConfig config, CancellationToken cancellationToken = default)
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnPromptRequested(config);

            if (!proceed)
                return Task.FromResult(string.Empty);

            var task = new TaskCompletionSource<string>();

            config.ConfirmButtonClickAction = (inputText) => task.TrySetResult(inputText);
            config.CancelButtonClickAction = () => task.TrySetResult(string.Empty);
            config.DismissedAction = () => task.TrySetResult(string.Empty);

            using (cancellationToken.Register(() => Prompt(config)?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Displays a loading wheel to the user.
        /// </summary>
        /// <param name="config">The loading configuration.</param>
        public abstract IDisposable ShowLoading(ILoadingConfig config);

        /// <summary>
        /// Displays a loading wheel to the user that is shown alongside execution of a task.
        /// </summary>
        /// <param name="config">The loading configuration.</param>
        /// <param name="task">The task to execute.</param>
        public TTask ShowLoading<TTask>(LoadingAsyncConfig config, TTask task, CancellationToken cancellationToken = default)
            where TTask : Task
        {
            var proceed = MessagingService.Delegate == null ? true : MessagingService.Delegate.OnShowLoadingRequested(config);

            if (!proceed)
                return default;

            task.ContinueWith((t) => HideLoading(), cancellationToken);

            using(cancellationToken.Register(() => ShowLoading(config)?.Dispose()))
                return task;
        }

        /// <summary>
        /// Displays a snackbar to the user.
        /// </summary>
        /// <param name="config">The snackbar configuration.</param>
        public abstract void Snackbar(ISnackbarConfig config);

        /// <summary>
        /// Displays a toast to the user.
        /// </summary>
        /// <param name="config">The toast configuration.</param>
        public abstract void Toast(IToastConfig config);
        #endregion
    }
}
