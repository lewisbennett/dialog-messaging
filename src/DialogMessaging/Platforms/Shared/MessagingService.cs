using DialogMessaging.Infrastructure;

namespace DialogMessaging;

public static partial class MessagingService
{
    #region Properties
    /// <summary>
    ///     Gets or sets the messaging delegate, if any.
    /// </summary>
    public static IMessagingDelegate Delegate
    {
        get => MessagingServiceCore.Delegate;

        set => MessagingServiceCore.Delegate = value;
    }

    /// <summary>
    ///     Gets the messaging service instance.
    /// </summary>
    public static IMessagingService Instance => MessagingServiceCore.Instance;
    #endregion
}