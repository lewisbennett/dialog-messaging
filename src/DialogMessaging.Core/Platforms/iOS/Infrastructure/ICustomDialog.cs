using DialogMessaging.Interactions.Base;
using System;

namespace DialogMessaging.Core.Platforms.iOS.Infrastructure
{
    public interface ICustomDialog<TConfig>
        where TConfig : IBaseInteraction
    {
        #region Properties
        /// <summary>
        ///     Gets or sets whether the view is currently showing.
        /// </summary>
        bool IsShowing { get; set; }
        #endregion

        #region Methods
        /// <summary>
        ///     Applies the provided dialog configuration to the view.
        /// </summary>
        /// <param name="config">The dialog configuration.</param>
        void ApplyDialogConfig(TConfig config);

        /// <summary>
        ///     Dismisses the custom dialog.
        /// </summary>
        /// <param name="finishedAction">An optional action to invoke after the custom dialog has been dismissed.</param>
        void Dismiss(Action finishedAction = null);

        /// <summary>
        ///     Shows the custom dialog.
        /// </summary>
        /// <param name="finishedAction">An optional action to invoke after the custom dialog has been shown.</param>
        void Show(Action finishedAction = null);
        #endregion
    }
}