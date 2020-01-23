using System;

namespace DialogMessaging.Platforms.iOS.Infrastructure
{
    public interface IShowable
    {
        #region Properties
        /// <summary>
        /// Gets or sets whether the showable is showing.
        /// </summary>
        bool IsShowing { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Hides the showable.
        /// </summary>
        /// <param name="finishedAction">An optional action to complete when hiding has finished.</param>
        void Hide(Action finishedAction = null);

        /// <summary>
        /// Shows the showable.
        /// </summary>
        /// <param name="finishedAction">An optional action to complete when hiding has finished.</param>
        void Show(Action finishedAction = null);
        #endregion
    }
}
