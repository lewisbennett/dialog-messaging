using DialogMessaging.Interactions;
using DialogMessaging.Schema;
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
        Task<DismissalCause> AlertAsync(AlertAsyncConfig config, CancellationToken cancellationToken = default);
        #endregion
    }
}
