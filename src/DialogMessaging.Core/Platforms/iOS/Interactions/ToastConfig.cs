using System;

namespace DialogMessaging.Interactions;

public static partial class ToastConfigDefaults
{
    #region Properties
    /// <summary>
    ///     Gets or sets the default value for the duration of the Toast.
    /// </summary>
    public static TimeSpan? Duration { get; set; }
    #endregion
}

public partial interface IToastConfig
{
    #region Properties
    /// <summary>
    ///     Gets or sets the duration of the toast.
    /// </summary>
    TimeSpan? Duration { get; set; }
    #endregion
}

public partial class ToastConfig
{
    #region Properties
    /// <summary>
    ///     Gets or sets the duration of the toast.
    /// </summary>
    public TimeSpan? Duration { get; set; }
    #endregion

    #region Constructors
    public ToastConfig()
        : base()
    {
        Duration = ToastConfigDefaults.Duration;
    }
    #endregion
}