using DialogMessaging.Interactions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DialogMessaging
{
    public interface IMessagingService
    {
        #region Public Methods
        /// <summary>
        /// Displays an alert to the user.
        /// </summary>
        /// <param name="config">The alert configuration.</param>
        IDisposable Alert(IAlertConfig config);

        /// <summary>
        /// Displays an alert to the user asynchronously.
        /// </summary>
        /// <param name="config">The alert configuration.</param>
        Task AlertAsync(AlertAsyncConfig config, CancellationToken cancellationToken = default);

        /// <summary>
        /// Displays a confirm dialog to the user.
        /// </summary>
        /// <param name="config">The confirm configuration.</param>
        IDisposable Confirm(IConfirmConfig config);

        /// <summary>
        /// Displays a confirm dialog to the user asynchronously.
        /// </summary>
        /// <param name="config">The confirm configuration.</param>
        Task<bool> ConfirmAsync(ConfirmAsyncConfig config, CancellationToken cancellationToken = default);

        /// <summary>
        /// Shows a delete dialog to the user.
        /// </summary>
        /// <param name="config">The delete configuration.</param>
        IDisposable Delete(IDeleteConfig config);

        /// <summary>
        /// Displays a delete dialog to the user asynchronously.
        /// </summary>
        /// <param name="config">The delete configuration.</param>
        Task<bool> DeleteAsync(DeleteAsyncConfig config, CancellationToken cancellationToken = default);
        #endregion
    }
}
