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
            var task = new TaskCompletionSource<bool>();

            config.OkButtonClickAction = () => task.TrySetResult(true);
            config.DismissedAction = () => task.TrySetResult(false);

            using (cancellationToken.Register(Alert(config).Dispose))
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
            var task = new TaskCompletionSource<bool>();

            config.ConfirmButtonClickAction = () => task.TrySetResult(true);
            config.CancelButtonClickAction = () => task.TrySetResult(false);
            config.DismissedAction = () => task.TrySetResult(false);

            using (cancellationToken.Register(Confirm(config).Dispose))
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
            var task = new TaskCompletionSource<bool>();

            config.DeleteButtonClickAction = () => task.TrySetResult(true);
            config.CancelButtonClickAction = () => task.TrySetResult(false);
            config.DismissedAction = () => task.TrySetResult(false);

            using (cancellationToken.Register(Delete(config).Dispose))
                return task.Task;
        }

        /// <summary>
        /// Hides the loading wheel from the user, if visible.
        /// </summary>
        public abstract void HideLoading();

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
            task.ContinueWith((t) => HideLoading(), cancellationToken);

            using(cancellationToken.Register(ShowLoading(config).Dispose))
                return task;
        }
        #endregion
    }
}
