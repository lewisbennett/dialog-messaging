namespace DialogMessaging.Infrastructure;

public static partial class MessagingServiceCore
{
    #region Properties
    /// <summary>
    ///     Gets or sets the messaging delegate, if any.
    /// </summary>
    public static IMessagingDelegate Delegate { get; set; }

    /// <summary>
    ///     Gets the messaging service instance.
    /// </summary>
    public static IMessagingService Instance { get; internal set; }
    #endregion
}