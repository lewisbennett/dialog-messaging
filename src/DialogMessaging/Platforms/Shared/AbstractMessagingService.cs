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
        /// <param name="config">The confirm configuration.</param>
        public Task<bool> ConfirmAsync(ConfirmAsyncConfig config, CancellationToken cancellationToken = default)
        {
            var task = new TaskCompletionSource<bool>();

            config.ConfirmButtonClickAction = () => task.TrySetResult(true);
            config.CancelButtonClickAction = () => task.TrySetResult(false);
            config.DismissedAction = () => task.TrySetResult(false);

            using (cancellationToken.Register(Confirm(config).Dispose))
                return task.Task;
        }
        #endregion
    }
}
