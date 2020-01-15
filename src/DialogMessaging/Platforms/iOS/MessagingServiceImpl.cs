using DialogMessaging.Interactions;
using System;

namespace DialogMessaging.Platforms.iOS
{
    public class MessagingServiceImpl : AbstractMessagingService
    {
        #region Public Methods
        /// <summary>
        /// Displays an alert to the user.
        /// </summary>
        /// <param name="config">The alert configuration.</param>
        public override IDisposable Alert(IAlertConfig config)
        {
            return null;
        }

        /// <summary>
        /// Displays a confirm dialog to the user.
        /// </summary>
        /// <param name="config">The confirm configuration.</param>
        public override IDisposable Confirm(IConfirmConfig config)
        {
            return null;
        }

        /// <summary>
        /// Displays a delete dialog to the user.
        /// </summary>
        /// <param name="config">The delete configuration.</param>
        public override IDisposable Delete(IDeleteConfig config)
        {
            return null;
        }

        /// <summary>
        /// Hides the loading wheel from the user, if visible.
        /// </summary>
        public override void HideLoading()
        {
        }

        /// <summary>
        /// Displays a prompt to the user.
        /// </summary>
        /// <param name="config">The prompt configuration.</param>
        public override IDisposable Prompt(IPromptConfig config)
        {
            return null;
        }

        /// <summary>
        /// Displays a loading wheel to the user.
        /// </summary>
        /// <param name="config">The loading configuration.</param>
        public override IDisposable ShowLoading(ILoadingConfig config)
        {
            return null;
        }

        /// <summary>
        /// Displays a snackbar to the user.
        /// </summary>
        /// <param name="config">The snackbar configuration.</param>
        public override void Snackbar(ISnackbarConfig config)
        {
        }

        /// <summary>
        /// Displays a toast to the user.
        /// </summary>
        /// <param name="config">The toast configuration.</param>
        public override void Toast(IToastConfig config)
        {
        }
        #endregion
    }
}
