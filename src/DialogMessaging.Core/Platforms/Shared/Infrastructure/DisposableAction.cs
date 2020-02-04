using System;

namespace DialogMessaging.Infrastructure
{
    public sealed class DisposableAction : IDisposable
    {
        #region Properties
        /// <summary>
        /// Gets the action.
        /// </summary>
        public Action Action { get; }
        #endregion

        #region Public Methods
        public void Dispose()
        {
            Action?.Invoke();
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Constructors
        public DisposableAction(Action action)
        {
            Action = action;
        }
        #endregion
    }
}
