using Android.Widget;

namespace DialogMessaging.Interactions;

public static partial class ToastConfigDefaults
{
    #region Properties
    /// <summary>
    ///     Gets or sets the default value for the duration of the Toast.
    /// </summary>
    public static ToastLength Duration { get; set; }

    /// <summary>
    ///     Gets or sets the default value for the resource ID of the layout to use.
    /// </summary>
    public static int? LayoutResID { get; set; }
    #endregion
}

public partial interface IToastConfig
{
    #region Properties
    /// <summary>
    ///     Gets or sets the duration of the Toast.
    /// </summary>
    ToastLength Duration { get; set; }
    #endregion
}

public partial class ToastConfig
{
    #region Properties
    /// <summary>
    ///     Gets or sets the duration of the Toast.
    /// </summary>
    public ToastLength Duration { get; set; }
    #endregion

    #region Constructors
    public ToastConfig()
    {
        Duration = ToastConfigDefaults.Duration;
        LayoutResID = ToastConfigDefaults.LayoutResID;
    }
    #endregion
}