using System;

namespace DialogMessaging.Core.Platforms.Shared.Infrastructure
{
    public class DisposableAction : IDisposable
    {
        #region Properties
        /// <summary>
        /// Gets the action.
        /// </summary>
        public Action Action { get; }
        #endregion

        #region Methods
        void IDisposable.Dispose()
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
