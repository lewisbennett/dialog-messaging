namespace DialogMessaging.Interactions.Base;

public partial interface IBaseInteraction
{
    #region Properties
    /// <summary>
    ///     Gets or sets an optional data payload. Can be used to store a payload that will be intercepted in the
    ///     <see cref="IMessagingDelegate" />.
    /// </summary>
    object Data { get; set; }

    /// <summary>
    ///     Gets or sets the message.
    /// </summary>
    string Message { get; set; }
    #endregion
}

public partial class BaseInteraction : IBaseInteraction
{
    #region Properties
    /// <summary>
    ///     Gets or sets an optional data payload. Can be used to store a payload that will be intercepted in the
    ///     <see cref="IMessagingDelegate" />.
    /// </summary>
    public object Data { get; set; }

    /// <summary>
    ///     Gets or sets the message.
    /// </summary>
    public string Message { get; set; }
    #endregion
}

public partial class BaseAsyncInteraction : IBaseInteraction
{
    #region Properties
    /// <summary>
    ///     Gets or sets an optional data payload. Can be used to store a payload that will be intercepted in the
    ///     <see cref="IMessagingDelegate" />.
    /// </summary>
    public object Data { get; set; }

    /// <summary>
    ///     Gets or sets the message.
    /// </summary>
    public string Message { get; set; }
    #endregion
}