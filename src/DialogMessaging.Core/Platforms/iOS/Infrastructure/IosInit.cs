using DialogMessaging.Infrastructure;
using UIKit;

namespace DialogMessaging.Core.Platforms.iOS.Infrastructure;

public static class IosInit
{
    #region Public Methods
    /// <summary>
    ///     Initialize the messaging service.
    /// </summary>
    /// <param name="window">The app's primary <see cref="UIWindow" />.</param>
    /// <param name="messagingService">The messaging service.</param>
    public static void Init(UIWindow window, IMessagingService messagingService)
    {
        MessagingServiceCore.Window = window;

        MessagingServiceCore.Instance = messagingService ?? new IosMessagingService();
    }
    #endregion
}