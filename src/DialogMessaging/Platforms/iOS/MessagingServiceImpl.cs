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
        #endregion
    }
}
