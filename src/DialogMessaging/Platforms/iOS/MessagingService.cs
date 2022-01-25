using DialogMessaging.Core.Platforms.iOS.Infrastructure;
using UIKit;

namespace DialogMessaging;

public static partial class MessagingService
{
    #region Public Methods
    /// <summary>
    ///     Initialize the messaging service.
    /// </summary>
    /// <param name="window">The app's primary <see cref="UIWindow" />.</param>
    public static void Init(UIWindow window)
    {
        Init(window, null);
    }

    /// <summary>
    ///     Initialize the messaging service.
    /// </summary>
    /// <param name="window">The app's primary <see cref="UIWindow" />.</param>
    /// <param name="messagingService">A custom messaging service.</param>
    public static void Init(UIWindow window, IMessagingService messagingService)
    {
        IosInit.Init(window, messagingService);
    }
    #endregion
}