using DialogMessaging.Interactions;
using DialogMessaging.Schema;
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
        public Task<DismissalCause> AlertAsync(AlertAsyncConfig config, CancellationToken cancellationToken = default)
        {
            var task = new TaskCompletionSource<DismissalCause>();

            config.OkButtonClickAction = () => task.TrySetResult(DismissalCause.OkButton);
            config.DismissedAction = () => task.TrySetResult(DismissalCause.Dismissed);

            using (cancellationToken.Register(Alert(config).Dispose))
                return task.Task;
        }
        #endregion
    }
}
