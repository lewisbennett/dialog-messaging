using UIKit;

namespace DialogMessaging.Infrastructure
{
    public static partial class MessagingServiceCore
    {
        #region Properties
        /// <summary>
        /// Gets or sets the app's primary <see cref="UIWindow" />.
        /// </summary>
        public static UIWindow Window { get; internal set; }
        #endregion
    }
}
