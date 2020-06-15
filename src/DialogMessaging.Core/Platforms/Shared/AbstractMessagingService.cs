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
        public IDisposable ActionSheet(IActionSheetConfig config)
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnActionSheetRequested(config);

            return proceed ? PresentActionSheet(config) : null;
        }

        /// <summary>
        /// Displays an action sheet to the user asynchronously.
        /// </summary>
        /// <param name="config">The action sheet configuration.</param>
        public Task<IActionSheetItemConfig> ActionSheetAsync(ActionSheetAsyncConfig config, CancellationToken cancellationToken = default)
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnActionSheetRequested(config);

            if (!proceed)
                return Task.FromResult<IActionSheetItemConfig>(null);

            var task = new TaskCompletionSource<IActionSheetItemConfig>();

            config.ItemClickAction = (item) => task.TrySetResult(item);
            config.CancelButtonClickAction = () => task.TrySetResult(null);
            config.DismissedAction = () => task.TrySetResult(null);

            var actionSheet = PresentActionSheet(config);

            using (cancellationToken.Register(() => actionSheet?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Displays a bottom action sheet to the user.
        /// </summary>
        /// <param name="config">The bottom action sheet configuration.</param>
        public IDisposable ActionSheetBottom(IActionSheetBottomConfig config)
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnActionSheetBottomRequested(config);

            return proceed ? PresentActionSheetBottom(config) : null;
        }

        /// <summary>
        /// Displays a bottom action sheet to the user asynchronously.
        /// </summary>
        /// <param name="config">The bottom action sheet configuration.</param>
        public Task<IActionSheetItemConfig> ActionSheetBottomAsync(ActionSheetBottomAsyncConfig config, CancellationToken cancellationToken = default)
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnActionSheetBottomRequested(config);

            if (!proceed)
                return Task.FromResult<IActionSheetItemConfig>(null);

            var task = new TaskCompletionSource<IActionSheetItemConfig>();

            config.ItemClickAction = (item) => task.TrySetResult(item);
            config.CancelButtonClickAction = () => task.TrySetResult(null);
            config.DismissedAction = () => task.TrySetResult(null);

            var actionSheetBottom = PresentActionSheetBottom(config);

            using (cancellationToken.Register(() => actionSheetBottom?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Displays an alert to the user.
        /// </summary>
        /// <param name="config">The alert configuration.</param>
        public IDisposable Alert(IAlertConfig config)
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnAlertRequested(config);

            return proceed ? PresentAlert(config) : null;
        }

        /// <summary>
        /// Displays an alert to the user asynchronously.
        /// </summary>
        /// <param name="config">The alert configuration.</param>
        public Task AlertAsync(AlertAsyncConfig config, CancellationToken cancellationToken = default)
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnAlertRequested(config);

            if (!proceed)
                return Task.FromResult(false);

            var task = new TaskCompletionSource<bool>();

            config.OkButtonClickAction = () => task.TrySetResult(true);
            config.DismissedAction = () => task.TrySetResult(false);

            var alert = PresentAlert(config);

            using (cancellationToken.Register(() => alert?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Displays a confirm dialog to the user.
        /// </summary>
        /// <param name="config">The confirm configuration.</param>
        public IDisposable Confirm(IConfirmConfig config)
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnConfirmRequested(config);

            return proceed ? PresentConfirm(config) : null;
        }

        /// <summary>
        /// Displays a confirm dialog to the user asynchronously.
        /// </summary>
        /// <param name="config">The delete configuration.</param>
        public Task<bool> ConfirmAsync(ConfirmAsyncConfig config, CancellationToken cancellationToken = default)
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnConfirmRequested(config);

            if (!proceed)
                return Task.FromResult(false);

            var task = new TaskCompletionSource<bool>();

            config.ConfirmButtonClickAction = () => task.TrySetResult(true);
            config.CancelButtonClickAction = () => task.TrySetResult(false);
            config.DismissedAction = () => task.TrySetResult(false);

            var confirm = PresentConfirm(config);

            using (cancellationToken.Register(() => confirm?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Displays a delete dialog to the user.
        /// </summary>
        /// <param name="config">The delete configuration.</param>
        public IDisposable Delete(IDeleteConfig config)
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnDeleteRequested(config);

            return proceed ? PresentDelete(config) : null;
        }

        /// <summary>
        /// Displays a delete dialog to the user asynchronously.
        /// </summary>
        /// <param name="config">The delete configuration.</param>
        public Task<bool> DeleteAsync(DeleteAsyncConfig config, CancellationToken cancellationToken = default)
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnDeleteRequested(config);

            if (!proceed)
                return Task.FromResult(false);

            var task = new TaskCompletionSource<bool>();

            config.DeleteButtonClickAction = () => task.TrySetResult(true);
            config.CancelButtonClickAction = () => task.TrySetResult(false);
            config.DismissedAction = () => task.TrySetResult(false);

            var delete = PresentDelete(config);

            using (cancellationToken.Register(() => delete?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Hides the loading wheel from the user, if visible.
        /// </summary>
        public void HideLoading()
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnHideLoadingRequested();

            if (proceed && Loading != null)
                Loading.Dispose();
        }

        /// <summary>
        /// Displays a prompt to the user.
        /// </summary>
        /// <param name="config">The prompt configuration.</param>
        public IDisposable Prompt(IPromptConfig config)
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnPromptRequested(config);

            return proceed ? PresentPrompt(config) : null;
        }

        /// <summary>
        /// Displays a prompt to the user.
        /// </summary>
        /// <param name="config">The prompt configuration.</param>
        public Task<string> PromptAsync(PromptAsyncConfig config, CancellationToken cancellationToken = default)
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnPromptRequested(config);

            if (!proceed)
                return Task.FromResult(string.Empty);

            var task = new TaskCompletionSource<string>();

            config.ConfirmButtonClickAction = (inputText) => task.TrySetResult(inputText);
            config.CancelButtonClickAction = () => task.TrySetResult(string.Empty);
            config.DismissedAction = () => task.TrySetResult(string.Empty);

            var prompt = PresentPrompt(config);

            using (cancellationToken.Register(() => prompt?.Dispose()))
                return task.Task;
        }

        /// <summary>
        /// Displays a loading wheel to the user.
        /// </summary>
        /// <param name="config">The loading configuration.</param>
        public IDisposable ShowLoading(ILoadingConfig config)
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnShowLoadingRequested(config);

            if (!proceed)
                return null;

            Loading = PresentLoading(config);

            return Loading;
        }

        /// <summary>
        /// Displays a loading wheel to the user that is shown alongside execution of a task.
        /// </summary>
        /// <param name="config">The loading configuration.</param>
        /// <param name="task">The task to execute.</param>
        public TTask ShowLoadingAsync<TTask>(LoadingAsyncConfig config, TTask task, CancellationToken cancellationToken = default)
            where TTask : Task
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnShowLoadingRequested(config);

            if (!proceed)
                return default;

            task.ContinueWith((t) => HideLoading(), cancellationToken);

            Loading = PresentLoading(config);

            using (cancellationToken.Register(() => Loading?.Dispose()))
                return task;
        }

        /// <summary>
        /// Displays a snackbar to the user.
        /// </summary>
        /// <param name="config">The snackbar configuration.</param>
        public void Snackbar(ISnackbarConfig config)
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnSnackbarRequested(config);

            if (proceed && !string.IsNullOrWhiteSpace(config.Message))
                PresentSnackbar(config);
        }

        /// <summary>
        /// Displays a toast to the user.
        /// </summary>
        /// <param name="config">The toast configuration.</param>
        public void Toast(IToastConfig config)
        {
            var proceed = MessagingService.Delegate == null || MessagingService.Delegate.OnToastRequested(config);

            if (proceed && !string.IsNullOrWhiteSpace(config.Message))
                PresentToast(config);
        }
        #endregion

        #region Internal Properties
        internal IDisposable Loading { get; set; }
        #endregion

        #region Internal Methods
        internal abstract IDisposable PresentActionSheet(IActionSheetConfig config);

        internal abstract IDisposable PresentActionSheetBottom(IActionSheetBottomConfig config);

        internal abstract IDisposable PresentAlert(IAlertConfig config);

        internal abstract IDisposable PresentConfirm(IConfirmConfig config);

        internal abstract IDisposable PresentDelete(IDeleteConfig config);

        internal abstract IDisposable PresentPrompt(IPromptConfig config);

        internal abstract IDisposable PresentLoading(ILoadingConfig config);

        internal abstract void PresentSnackbar(ISnackbarConfig config);

        internal abstract void PresentToast(IToastConfig config);
        #endregion
    }
}
